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
    public partial class Image_Editor : Form
    {
        int separate_width = 0;
        int separate_height = 0;
        public Image_Editor()
        {
            InitializeComponent();
        }
        private void Size_Change(object sender, EventArgs e) // 클라이언트 크기 조정
        {
            int ClientWidth = this.ClientSize.Width;
            int ClientHeight = this.ClientSize.Height;
            if (ClientWidth < 384) ClientWidth = 384;
            if (ClientHeight < 276) ClientHeight = 276;
            this.Button_merge.Width = ClientWidth - 24;
            this.Button_separate.Width = ClientWidth - 24;
            this.Button_merge.Height = (ClientHeight - 36) / 2;
            this.Button_separate.Height = (ClientHeight - 36) / 2;
            this.Button_separate.Location = new System.Drawing.Point(12, Button_merge.Location.Y + (ClientHeight - 36) / 2 + 12);
        }

        private void Image_Editor_Load(object sender, EventArgs e)
        {

        }
        private void Button_merge_Click(object sender, EventArgs e)
        {

        }
        private void Button_separate_Click(object sender, EventArgs e)
        {
            Size Size_Editor = new Size();
            Size_Editor.Size_Data_Send += Get_Image_Size;
            Size_Editor.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            Size_Editor.ShowDialog();

            string Image_Origin_Path = string.Empty;
            OpenFileDialog Image_directory = new OpenFileDialog();
            Image_directory.Title = "분리할 이미지 불러오기";
            Image_directory.InitialDirectory = @"C:";
            if(Image_directory.ShowDialog() == DialogResult.OK)
                Image_Origin_Path = Image_directory.FileName;
            Bitmap Image_Origin = new Bitmap(Image_Origin_Path);
            // 이미지 불러오기

            FolderBrowserDialog Save_directory = new FolderBrowserDialog();
            Save_directory.Description = "분리된 이미지를 저장";
            // 분리하고 저장하기까지

        }
        public void Get_Image_Size(int w, int h)
        {
            separate_width = w;
            separate_height = h;
        }
    }
}
