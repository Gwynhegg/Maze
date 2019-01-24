namespace Maze
{
    partial class Maze
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreate = new System.Windows.Forms.Button();
            this.textHeight = new System.Windows.Forms.TextBox();
            this.textWidth = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(713, 32);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(688, 61);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(100, 20);
            this.textHeight.TabIndex = 1;
            this.textHeight.Text = "Height";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(688, 87);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(100, 20);
            this.textWidth.TabIndex = 2;
            this.textWidth.Text = "Width";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 3;
            // 
            // Maze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textWidth);
            this.Controls.Add(this.textHeight);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.panel1);
            this.Name = "Maze";
            this.Text = "Maze";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textHeight;
        private System.Windows.Forms.TextBox textWidth;
        private System.Windows.Forms.Panel panel1;
    }
}

