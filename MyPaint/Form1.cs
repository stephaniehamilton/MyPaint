using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        //Set standard resolution for new instance of Bitmap
        Bitmap bmp = new Bitmap(1024, 768);
        //Represents the pen color
        Pen p = new Pen(Color.Black, 5);
        //Variable for whether or not left mouse button is held down
        bool drawing = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(drawing)
            {
                drawing = false;
            }
            else
            {
                drawing = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drawing)
            {
                //Create drawing surface, call variable bmp created earlier
                Graphics g = Graphics.FromImage(bmp);
                //Draw ellipse. p is pen, e for ellipse, 3 and 1 for positioning
                g.DrawEllipse(p, e.X, e.Y, 3, 1);
                //Reference picture box, attach image bmp bitmap variable
                pictureBox1.Image = bmp;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Access Pen variable p and set color to red
            p.Color = Color.Red;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Access Pen variable p and set color to blue
            p.Color = Color.Blue;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Access Pen variable p and set color to green
            p.Color = Color.Green;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Access Pen variable p and set color to purple
            p.Color = Color.Purple;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //Access Pen variable p and set color to gold
            p.Color = Color.Gold;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create variable to initialize new instance of Save File Dialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify types of files that can be saved
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image *.bmp|";
            //Text to display when Save As is clicked
            saveFileDialog1.Title = "Save an Image File";
            //ShowDialog method will bring up dialog box
            saveFileDialog1.ShowDialog();

        //if the file name is not blank, run this code
            if(saveFileDialog1.FileName !="")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                //Check for correct image format conditions before executing the code
                switch(saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
            }
        }
    }
}
