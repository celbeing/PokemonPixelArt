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
    public partial class Size : Form
    {
        int width = 40; int height = 30;
        public delegate void SizeDataHandler(int w, int h);
        public event SizeDataHandler Size_Data_Send;
        public Size()
        {
            InitializeComponent();
            this.Textbox_width.Text = width.ToString();
            this.Textbox_height.Text = height.ToString();
        }

        private void Textbox_width_input(object sender, EventArgs e)
        {

        }

        private void Textbox_height_input(object sender, EventArgs e)
        {

        }

        private void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                width = int.Parse(Textbox_width.Text);
                height = int.Parse(Textbox_height.Text);
                if (width > 0 && height > 0)
                {
                    this.Size_Data_Send(width, height);
                    this.Close();
                }
                else MessageBox.Show("0 이상의 자연수 값을 입력하세요.");
            }
            catch
            {
                MessageBox.Show("0 이상의 자연수 값을 입력하세요.");
            }
        }
    }
}
