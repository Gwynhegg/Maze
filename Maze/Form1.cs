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
        bool isPath = false;
        int width, height, randomFactor=3, drawX;
        Random fact = new Random();
        Graphics g;
        Pen pen1 = new Pen(Color.Black, 2);
        Pen pen2 = new Pen(Color.Red, 1);
        int X, Y;
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
            int exit = fact.Next(width*3/8,width*5/8);
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPath)
            {
                g.DrawLine(pen2,X, Y, e.X, e.Y);
                X = e.X;
                Y = e.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isPath && e.Y>=height*drawX-drawX/2)
            {
                X = e.X;
                Y = e.Y;
                isPath = true;
            } else
            {
                isPath = false;
            }
        }

        private void createLastRow(int[,] quant, byte[,] walls)
        {

            int numQuant = quant[height-1, 0];
            for (int i = height-1; i >0; i--)
            {
                if (quant[height - 1, i] != quant[height - 1, i - 1]) walls[height - 1, i - 1] = 0;
            }
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
                        walls[numofRow, i-1] = 1;
                        numQuant=quant[numofRow,i];
                    }
                    else
                    {
                        quant[numofRow, i] = numQuant;
                    }
                } else
                {
                    walls[numofRow, i - 1] = 1;
                }
            }
        }
        private void createLowCorner(int[,] quant, byte[,] walls, int numOfRow)
        {
            int leftCorner = 0,rightCorner;
            int checkQuant = quant[numOfRow, leftCorner];
            int noWall;
            for (int i = 0; i < width; i++)
            {
                if (quant[numOfRow, i] != checkQuant || i == width - 1)
                {
                        noWall = fact.Next(leftCorner, i);
                        if (i == width - 1 && quant[numOfRow, i] == checkQuant) rightCorner = i + 1; else rightCorner = i;
                        for (int j = leftCorner; j < rightCorner; j++)
                        {
                            if (j != noWall)
                            {
                                if (walls[numOfRow, j] == 0) walls[numOfRow, j] = 2; else walls[numOfRow, j] = 3;
                            } 
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
                    walls[0, j] = 1;
                    i++;
                } else
                {
                    quant[0, j] = i;
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
