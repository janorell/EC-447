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

namespace Lab2
{
    public partial class Form1 : Form
    {
        private ArrayList coords = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Jenni Norell - Lab 2";
            this.Size = new System.Drawing.Size(750, 500);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                this.coords.Add(p);
                this.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                this.coords.Clear();
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            const int width = 15;
            const int height = 15;
            Graphics g = e.Graphics;
            Pen blackpen = new Pen(Brushes.Black);
            Pen whitepen = new Pen(Brushes.Transparent);
            SolidBrush redbrush = new SolidBrush(Color.Red);
            for (int i = 0; i < coords.Count - 1; ++i)
            {
                Point p1 = (Point)coords[i];
                Point p2 = (Point)coords[i + 1];
                if (this.button1.Text == "Show Lines")
                {
                    g.DrawLine(whitepen, p1.X, p1.Y, (p2).X, (p2).Y);
                }
                else if (this.button1.Text == "Hide Lines")
                {
                    g.DrawLine(blackpen, p1.X, p1.Y, (p2).X, (p2).Y);
                }

            }
            foreach (Point p in this.coords)
            {
                g.FillEllipse(redbrush, p.X - width / 2, p.Y - height / 2, width, height);
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Show Lines")
            {
                this.button1.Text = "Hide Lines";
                this.Invalidate();
            }
            else if (this.button1.Text == "Hide Lines")
            {
                this.button1.Text = "Show Lines";
                this.Invalidate();
            }

        }
    }
}
