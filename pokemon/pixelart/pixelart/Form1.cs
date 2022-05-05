using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pixelart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string image_file = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "bmp files (*.bmp)|*.bmp|gif files (*.gif)|*.gif|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
            }
            else
            {
                return;
            }

            pic.Image = Bitmap.FromFile(image_file);
        }
        private void btnSeparate_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath + "\\partition";
            }
            else
            {
                return;
            }
            int filenumber = 1;
            int x = pic.Image.Width / 40;
            int y = pic.Image.Height / 30;
            Color[,] Pixel = new Color[pic.Width, pic.Height];
            Bitmap bitpic = new Bitmap(pic.Image);
            for(int j = 0; j < pic.Height; j++)
            {
                for(int i = 0; i < pic.Width; i++)
                {
                    Pixel[i, j] = bitpic.GetPixel(i, j);
                }
            }
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    Bitmap partition = new Bitmap(40, 30);
                    for(int c = 0; c < 30; c++)
                    {
                        for(int r = 0; r < 40; r++)
                        {
                            partition.SetPixel(r, c, Pixel[i * 40 + r, j * 30 + c]);
                        }
                    }
                    partition.Save(path + $"\\image{filenumber}.bmp");
                    filenumber++;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pic_Click(object sender, EventArgs e)
        {

        }
    }
}
