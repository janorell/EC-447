using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int fibval(int n)
        {
            if (n==0) return 0;   
            if (n==1) return 1;    
            return fibval(n - 1) + fibval(n - 2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            int num = 1;
            //int fib =1 ;
            g.DrawString("Jennifer Norell", Font, Brushes.Black, 100, 20);

            for(num = 1; num <= 30; num++)
            {
                g.DrawString(num.ToString(), Font, Brushes.Black, 100, 20 + num * 15);
                g.DrawString(fibval(num).ToString(), Font, Brushes.Black, 120, 20 + num * 15);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(500, 600);
        }
    }
}
