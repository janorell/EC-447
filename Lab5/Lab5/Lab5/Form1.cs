using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        OpenFileDialog myfile = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            this.Text = "File Encrypt/Decrypt by Jenni Norell";
            this.Size = new System.Drawing.Size(450, 275);
            this.CenterToScreen();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // browse
        {
            if (myfile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = myfile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e) // encrypt
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter A Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (File.Exists(textBox1.Text) == false)
            {
                MessageBox.Show("Could not open source or destination file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (File.Exists(textBox1.Text + ".enc") == true)
            {
                DialogResult DialogResult = MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.No)
                {
                    return;
                }
                EncryptAlgo();
            }
            else
            {
                EncryptAlgo();
            }
        }

        private void button3_Click(object sender, EventArgs e) // decrypt
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter A Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text.EndsWith(".enc") == false)
            {
                MessageBox.Show("Not an .enc file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (File.Exists(textBox1.Text) == false)
            {
                MessageBox.Show("Could not open source or destination file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (File.Exists(textBox1.Text) == true)
            {
                DialogResult DialogResult = MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo);
                    if (DialogResult == DialogResult.No)
                    {
                        return;
                    }
                DecryptAlgo();
            }
            else
            {
                DecryptAlgo();
            }
        }

        private void EncryptAlgo()
        {
            string myfile2 = @textBox1.Text;
            string myfile3 = myfile2 + ".enc";
            FileStream fin = new FileStream(myfile2, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(myfile3, FileMode.Create, FileAccess.Write);

            int rbyte;
            int pos = 0;    //position in key string
            int length = textBox2.Text.Length; //length of key
            byte kbyte, ebyte; //encrypted byte

            while ((rbyte = fin.ReadByte()) != -1)
            {
                kbyte = (byte)textBox2.Text[pos];
                ebyte = (byte)(rbyte ^ kbyte);
                fout.WriteByte(ebyte);
                ++pos;
                if (pos == length)
                    pos = 0;
            }

            fin.Close();
            fout.Close();
            MessageBox.Show("Operation Completed Successfully");
        }

        private void DecryptAlgo()
        {
            string myfile4 = @textBox1.Text;
            string myfile5 = myfile4.Substring(0, (myfile4.Length - 4)); // remove .enc
            FileStream fin = new FileStream(myfile4, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(myfile5, FileMode.Create, FileAccess.Write);

            int rbyte;
            int pos = 0;    //position in key string
            int length = textBox2.Text.Length; //length of key
            byte kbyte, ebyte; //encrypted byte

            while ((rbyte = fin.ReadByte()) != -1)
            {
                kbyte = (byte)textBox2.Text[pos];
                ebyte = (byte)(rbyte ^ kbyte);
                fout.WriteByte(ebyte);
                ++pos;
                if (pos == length)
                    pos = 0;
            }

            fin.Close();
            fout.Close();
            MessageBox.Show("Operation Completed Successfully");
        }
    }
}
