using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class Maze : Form
    {
        int width, height, randomFactor=2, drawX;
        Random fact = new Random();
        Random numofPaths = new Random();
        Graphics g;
        Pen pen1 = new Pen(Color.Black, 2);
        Pen pen2 = new Pen(Color.Red, 1);
        public Maze()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            g.Clear(Color.White);       
            height = Int32.Parse(textHeight.Text);
            width = Int32.Parse(textWidth.Text);
            drawX = (panel1.Height-50) / height;
            int exit = 0;
            g.DrawLine(pen1, 10, 10, 10+exit * drawX, 10);
            g.DrawLine(pen1, 10 + exit * drawX+drawX, 10, 10 + width * drawX, 10);
            g.DrawLine(pen1, 10, 10, 10, 10+height*drawX);
            g.DrawLine(pen1, 10+width*drawX, 10, 10+width*drawX, 10+height*drawX);
            int[,] mazeQuantity = new int[height, width];
            byte[,] mazeWalls = new byte[height, width];
            // 0 - проход, 1 -стена справа, 2 - стена снизу, 3 - стены снизу и справа
            createFirstRow(mazeQuantity, mazeWalls);
            createLowCorner(mazeQuantity, mazeWalls, 0);
            for (int i = 1; i < height - 1; i++)
            {
                createAnotherRow(mazeQuantity, mazeWalls, i);
                createLowCorner(mazeQuantity, mazeWalls, i);
            }
            createAnotherRow(mazeQuantity, mazeWalls, height - 1);
            createLastRow(mazeQuantity, mazeWalls);
            printMaze(mazeWalls);
        }
        private void createLastRow(int[,] quant, byte[,] walls)
        {
            int numQuant = quant[height-1, 0];
            for (int i = height-1; i >0; i--)
            {
                if (quant[height - 1, i] != quant[height - 1, i - 1]) walls[height - 1, i - 1] = 2;
            }
            walls[height - 1, width - 1] = 1;
        }
        private void createAnotherRow(int[,] quant, byte[,] walls,int numofRow)
        {
            int numQuant = numofRow*width;
            for (int i = 0; i < width; i++)
            {
                if (walls[numofRow - 1, i] != 2 && walls[numofRow - 1, i] != 3)
                {
                    quant[numofRow, i] = quant[numofRow - 1, i];
                } else
                {
                    quant[numofRow, i] = numQuant;
                    numQuant++;
                }
            }
            numQuant = quant[numofRow, 0];
            for (int i = 1; i < width; i++)
            {
                if (quant[numofRow, i] != quant[numofRow, i - 1])
                {
                    if (fact.Next(randomFactor) == 1)
                    {
                        walls[numofRow, i-1] = 3;
                        numQuant=quant[numofRow,i];
                    }
                    else
                    {
                        quant[numofRow, i] = numQuant;
                        walls[numofRow, i - 1] = 2;
                        if (i == width - 1 && walls[numofRow-1,i]!=2 && walls[numofRow-1,i]!=3) walls[numofRow, i] = 3;
                    }
                } else
                {
                    walls[numofRow, i - 1] = 3;
                }
            }
        }
        private void createLowCorner(int[,] quant, byte[,] walls, int numOfRow)
        {
            int leftCorner = 0,rightCorner;
            int checkQuant = quant[numOfRow, leftCorner];
            for (int i = 0; i < width; i++)
            {
                if (quant[numOfRow, i] != checkQuant || i==width-1)
                {
                    if (i == width - 1 && quant[numOfRow, i] == checkQuant) rightCorner = i+1; else
                    {
                        rightCorner = i;
                        if (numOfRow == 0) walls[0, i] = 0;
                    }
                    int numofEntries = numofPaths.Next(1, rightCorner-leftCorner);
                    while (numofEntries != 0)
                    {
                        int j = numofPaths.Next(leftCorner, rightCorner);
                        if (walls[numOfRow, j] == 2)
                        {
                            walls[numOfRow, j] = 0;
                        } else if (walls[numOfRow, j] == 3)
                        {
                            walls[numOfRow, j] = 1;
                        }
                        numofEntries--;
                    }                    
                    checkQuant = quant[numOfRow, i];
                    leftCorner = i;
                
                }             
            }
            
        }    
        private void createFirstRow(int[,] quant, byte[,] walls)
        {
            int i = 1;
            for (int j = 0; j < width; j++)
            {
                if (fact.Next(randomFactor)==1)
                {
                    quant[0, j] = i;
                    walls[0, j] = 3;
                    i++;
                } else
                {
                    quant[0, j] = i;
                    walls[0, j] = 2;
                }
            }
        }
        private void printMaze(byte[,] a)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (a[i, j] == 1)
                    {
                        g.DrawLine(pen1, 10 + (j + 1) * drawX, 10 + i * drawX, 10 + (j + 1) * drawX, 10 + (i + 1) * drawX);
                    } else if (a[i, j] == 2)
                    {
                        g.DrawLine(pen1, 10 + j * drawX, 10 + (i + 1) * drawX, 10 + (j + 1) * drawX, 10 + (i + 1) * drawX);
                    }
                    else if (a[i, j] == 3)
                    {
                        g.DrawLine(pen1, 10 + (j + 1) * drawX, 10 + i * drawX, 10 + (j + 1) * drawX, 10 + (i + 1) * drawX);
                        g.DrawLine(pen1, 10 + j * drawX, 10 + (i + 1) * drawX, 10 + (j + 1) * drawX, 10 + (i + 1) * drawX);
                    }
                    Console.Write(a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
