using Lab6.Properties;
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
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private ArrayList drawnshapes = new ArrayList();
        private bool whichclick = true;
        private Point clickone;
        private Point clicktwo;
        private Form2 settingsbox = new Form2();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Lab 6 - Jenni Norell";
            this.Size = new System.Drawing.Size(700, 700);
            this.CenterToScreen();
            settingsbox.listBox1.SelectedIndex = 0;
            settingsbox.listBox2.SelectedIndex = 0;
            settingsbox.listBox3.SelectedIndex = 0;
            radioButton1.Checked = true;
        }


        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawnshapes.Count != 0)
            {
                drawnshapes.RemoveAt(drawnshapes.Count - 1);
            }
            this.panel2.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawnshapes.Count != 0)
            {
                drawnshapes.Clear();
            }
            this.panel2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e) //settings
        {
            settingsbox.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = Width;
            panel1.Height = Height;
        }


        public class MyShapes
        {
            public virtual void draw(Graphics g)
            {

            }
        }
        public class Linez : MyShapes
        {
            private Point begin;
            private Point end;
            private Pen pen;
            
            public Linez (Point begin, Point end, Pen pen)
            {
                this.begin = begin;
                this.end = end;
                this.pen = pen;
            }
            public override void draw(Graphics g)
            {
                g.DrawLine(this.pen, this.begin, this.end);
            }
        }

        public class Rects : MyShapes
        {
            private Point begin;
            private Point end;
            private Pen pen;
            private Brush brush;

            public Rects(Point begin, Point end, Pen pen, Brush brush)
            {
                this.begin = begin;
                this.end = end;
                this.pen = pen;
                this.brush = brush;
            }
            public override void draw(Graphics g)
            {
                int width = Math.Abs(end.X - begin.X);
                int length = Math.Abs(end.Y - begin.Y);
                int x = Math.Min(end.X, begin.X);
                int y = Math.Min(end.Y, begin.Y);

                if (this.pen != null)
                {
                    g.DrawRectangle(this.pen, x, y, width, length);
                }

                if (this.brush != null)
                {
                    g.FillRectangle(this.brush, x, y, width, length);
                }
            }
        }

        public class Elps : MyShapes
        {
            private Point begin;
            private Point end;
            private Pen pen;
            private Brush brush;

            public Elps(Point begin, Point end, Pen pen, Brush brush)
            {
                this.begin = begin;
                this.end = end;
                this.pen = pen;
                this.brush = brush;
            }
            public override void draw(Graphics g)
            {
                int width = Math.Abs(end.X - begin.X);
                int length = Math.Abs(end.Y - begin.Y);
                int x = Math.Min(end.X, begin.X);
                int y = Math.Min(end.Y, begin.Y);

                if (this.pen != null)
                {
                    g.DrawEllipse(this.pen, x, y, width, length);
                }
                if (this.brush != null)
                {
                    g.FillEllipse(this.brush, x, y, width, length);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Width = Width;
            panel2.Height = Height;
            Graphics g = e.Graphics;

            foreach (MyShapes shapes in this.drawnshapes)
            {
                shapes.draw(g);
            }
            this.Invalidate();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

            if (whichclick == true)
            {
                clickone = e.Location;
                Point circlept = new Point(e.X +6, e.Y + 6);
                whichclick = false;
                drawnshapes.Add(new Elps(clickone, circlept, new Pen(Brushes.Black), Brushes.Black));
                panel2.Refresh();
                return;
            }

            Point circlept2 = new Point(e.X + 6, e.Y + 6);
            clicktwo = e.Location;
            whichclick = true;
            drawnshapes.RemoveAt(drawnshapes.Count - 1);
            Brush penbrush = null;
            Brush fillbrush = null;
            panel2.Refresh();

            int width = settingsbox.listBox3.SelectedIndex;

            if (settingsbox.listBox1.SelectedIndex == 1) // pencolor
            {
                penbrush = Brushes.Black;
            }
            else if (settingsbox.listBox1.SelectedIndex == 2)
            {
                penbrush = Brushes.Red;
            }
            else if (settingsbox.listBox1.SelectedIndex == 3)
            {
                penbrush = Brushes.Blue;
            }
            else if (settingsbox.listBox1.SelectedIndex == 4)
            {
                penbrush = Brushes.Green;
            }

            if (settingsbox.listBox2.SelectedIndex == 1) // fillcolor
            {
                fillbrush = Brushes.Black;
            }
            else if (settingsbox.listBox2.SelectedIndex == 2)
            {
                fillbrush = Brushes.Red;
            }
            else if (settingsbox.listBox2.SelectedIndex == 3)
            {
                fillbrush = Brushes.Blue;
            }
            else if (settingsbox.listBox2.SelectedIndex == 4)
            {
                fillbrush = Brushes.Green;
            }
            try
            {
                if (radioButton1.Checked == true && penbrush != null)
                {
                    drawnshapes.Add(new Linez(clickone, clicktwo, new Pen(penbrush, width)));
                    panel2.Refresh();
                }
                else if (radioButton2.Checked == true && penbrush != null || radioButton2.Checked == true && fillbrush != null || radioButton2.Checked == true && fillbrush != null && penbrush != null)
                {
                    drawnshapes.Add(new Rects(clickone, clicktwo, new Pen(penbrush, width), fillbrush));
                    panel2.Refresh();
                }
                else if (radioButton3.Checked == true && penbrush != null || radioButton3.Checked == true && fillbrush != null || radioButton3.Checked == true && fillbrush != null && penbrush != null)
                {
                    drawnshapes.Add(new Elps(clickone, clicktwo, new Pen(penbrush, width), fillbrush));
                    panel2.Refresh();
                }
                else
                {
                    MessageBox.Show("Fill and/or outline must be checked");
                }
            }
            catch
            {
                MessageBox.Show("Fill and/or outline must be checked");
            }
        }
    }
}