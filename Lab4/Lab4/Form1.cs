using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Drawing.Text;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private bool[,] squaretaken = new bool[8, 8]; // 8x8 board
        private int queencount = 0; // queen counter
        public Form1()
        {
            InitializeComponent();
            this.Text = "Eight Queens by Jenni Norell";
            this.Size = new System.Drawing.Size(650, 650);
            this.CenterToScreen();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    // draw board
                    if ((col + row) % 2 == 0)
                    {
                        g.FillRectangle(Brushes.White, 100 + col * 50, 100 + row * 50, 50, 50);
                        g.DrawRectangle(Pens.Black, 100 + col * 50, 100 + row * 50, 50, 50);
                        if (this.checkBox1.Checked == true && Check_valid(col, row) == false )
                        {
                            g.FillRectangle(Brushes.Red, 100 + col * 50, 100 + row * 50, 50, 50);
                            g.DrawRectangle(Pens.Black, 100 + col * 50, 100 + row * 50, 50, 50);
                        }
                    }
                    else if ((col + row) % 2 == 1)
                    {
                        g.FillRectangle(Brushes.Black, 100 + col * 50, 100 + row * 50, 50, 50);
                        g.DrawRectangle(Pens.Black, 100 + col * 50, 100 + row * 50, 50, 50);
                        if (this.checkBox1.Checked == true && Check_valid(col, row) == false)
                        {
                            g.FillRectangle(Brushes.Red, 100 + col * 50, 100 + row * 50, 50, 50);
                            g.DrawRectangle(Pens.Black, 100 + col * 50, 100 + row * 50, 50, 50);
                        }
                    } // end draw board
                    if (squaretaken[col,row] == true) // draw Q if valid
                    {
                        Rectangle boxq = new Rectangle(100 + col * 50, 100 + row * 50, 50, 50);
                      if ((row + col) % 2 == 0)
                        {
                            g.DrawString("Q", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, boxq);
                        }
                      else
                        {
                            g.DrawString("Q", new Font("Arial", 30, FontStyle.Bold), Brushes.White, boxq);
                        }
                        if (this.checkBox1.Checked == true)
                        {
                            g.DrawString("Q", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, boxq);
                        }

                    }
                }
            }
            g.DrawString("You have " + queencount + " queens on the board", Font, Brushes.Black, 250, 50);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if ((x >= 100 && y >= 100) && (y < 500 && x < 500))
            {
                x = (x - 100) / 50;
                y = (y - 100) / 50;
                if (e.Button == MouseButtons.Right)
                {
                    if (squaretaken[x, y] == true)
                    {
                        squaretaken[x, y] = false;
                        queencount = queencount - 1;
                        this.Invalidate();
                    }
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (Check_valid(x, y) == true) // valid placement
                    {
                        squaretaken[x, y] = true;
                        queencount = queencount + 1;

                        this.Invalidate();

                        if (queencount == 8)
                        {
                            MessageBox.Show("You did it!");
                        }
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                    }
                }    
            }
        }
        private bool Check_valid (int x, int y) // checks if square clicked is valid
        {
            for (int i = 0; i < 8; i++) // cols
            {
                if (squaretaken[x, i] == true)
                {
                    return false;
                }
            }

            for (int i = 0; i < 8; i++) // checking rows to invalidate if necessary 
            {
                if (squaretaken[i,y] == true)
                {
                    return false;
                }
            }

            for (int i = y, j = x; j >= 8 && i < 8; i++, j--) // diags 
            {
                if (squaretaken[j, i] == true)
                {
                    return false;
                }
            }

            for (int i = y, j = x; j >= 0 && i >= 0; i--, j--) // diags
            {
                if (squaretaken[j, i] == true)
                {
                    return false;
                }
            }

            for (int i = y, j = x; j < 8 && i < 8; i++,j++) // diags
            {
                if (squaretaken[j, i] == true)
                {
                    return false;
                }
            }

            for (int i = y, j = x; j < 8 && i >= 0; i--, j++) // diags
            {
                if (squaretaken[j, i] == true)
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e) // clear board
        {
            squaretaken = new bool[8, 8]; // erases the prev array
            queencount = 0; // resets count
            this.Invalidate();
        }
    }
}
