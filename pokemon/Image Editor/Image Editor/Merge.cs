using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Editor
{
    public partial class Merge : Form
    {
        Bitmap current_image_sent;
        public Merge()
        {
            InitializeComponent();
        }

        private void Merge_Load(object sender, EventArgs e)
        {
            Image_Editor image_get = new Image_Editor();
            image_get.Image_Data_Send += Get_Image;
        }

        public void Get_Image(Bitmap image_sent)
        {
            Console.WriteLine("enter here");
            current_image_sent = image_sent;
            this.image_current.Size = new System.Drawing.Size(current_image_sent.Width, current_image_sent.Height);
            this.ClientSize = new System.Drawing.Size(current_image_sent.Width + 24, current_image_sent.Height + 24);
            this.image_current.Image = current_image_sent;
            MessageBox.Show("pause");
        }
    }
}
