using System;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form2 : Form
    {
        public int pencolor;
        public int penwidth;
        public int fillcolor;
        public Form2()
        {
            InitializeComponent();
            this.Text = "Settings";
            this.Size = new System.Drawing.Size(500, 500);
            this.CenterToScreen();
            this.listBox1.SelectedIndex = 0;
            this.listBox2.SelectedIndex = 0;
            this.listBox3.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listBox1.SelectedIndex = this.pencolor;
            this.listBox2.SelectedIndex = this.fillcolor;
            this.listBox3.SelectedIndex = this.penwidth;

            this.DialogResult = DialogResult.Cancel;

        }

        protected override void OnShown(EventArgs e)
        {
            this.pencolor = this.listBox1.SelectedIndex;
            this.fillcolor = this.listBox2.SelectedIndex;
            this.penwidth = this.listBox3.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pencolor = this.listBox1.SelectedIndex;
            this.fillcolor = this.listBox2.SelectedIndex;
            this.penwidth = this.listBox3.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

    }
}
