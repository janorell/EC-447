using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Jenni Norell - Lab 3";
            this.Size = new System.Drawing.Size(650, 400);
            this.BackColor = Color.Yellow;
            textBox2.ReadOnly = true;
            this.CenterToScreen();
            double num1;
            double num2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                if (!double.TryParse(textBox1.Text, out double ans) || textBox1.Text == String.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
                }
                else
                {
                    //num1 = Convert.ToDouble
                    textBox2.Text = Convert.ToString(Convert.ToDouble(textBox1.Text));
                    textBox1.Text = String.Empty;
                }
            }   
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
            if (!double.TryParse(textBox1.Text, out double ans) || textBox1.Text == String.Empty)
            {
                System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
            }
            else
            {
                textBox2.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text));
                textBox1.Text = String.Empty;
            }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(textBox1.Text, out double ans) || textBox1.Text == String.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
                }
                else
                {
                    textBox2.Text = Convert.ToString(Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text));
                    textBox1.Text = String.Empty;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(textBox1.Text, out double ans) || textBox1.Text == String.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
                }
                else
                {
                    textBox2.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text));
                    textBox1.Text = String.Empty;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(textBox1.Text, out double ans) || textBox1.Text == String.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
                }
                else
                {
                    textBox2.Text = Convert.ToString(Convert.ToDouble(textBox2.Text) / Convert.ToDouble(textBox1.Text));
                    textBox1.Text = String.Empty;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid or Missing Value!");
            }
        }
    }
}
