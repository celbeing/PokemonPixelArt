﻿using System;
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
        int merge_row = 1;
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
            string image_piece_path = string.Empty;
            FolderBrowserDialog image_directory = new FolderBrowserDialog();
            image_directory.Description = "병합할 이미지가 있는 폴더";
            if (image_directory.ShowDialog() == DialogResult.OK)
                image_piece_path = image_directory.SelectedPath;
            else
            {
                MessageBox.Show("폴더가 선택되지 않았습니다.");
                return;
            }
            Arrange Arrange_Set = new Arrange();
            Arrange_Set.Arrange_Data_Send += Get_Arrange_Data;
            Arrange_Set.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            Arrange_Set.ShowDialog();
            if (merge_row < 1)
            {
                MessageBox.Show("잘못된 입력입니다.");
                return;
            }
            // 이미지 합치기
        }
        private void Button_separate_Click(object sender, EventArgs e)
        {
            Size Size_Editor = new Size();
            Size_Editor.Size_Data_Send += Get_Image_Size;
            Size_Editor.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            Size_Editor.ShowDialog();
            if (separate_width * separate_height <= 0)
            {
                MessageBox.Show("잘못된 입력입니다.");
                return;
            }
            // bool 값으로 "확인" 눌러서 값 전달 된건지 확인

            string image_origin_path = string.Empty;
            OpenFileDialog image_directory = new OpenFileDialog();
            image_directory.Title = "분리할 이미지 불러오기";
            image_directory.InitialDirectory = @"C:";
            image_directory.Filter = 
                "png files (*.png)|*.png|jpg files (*.jpg)|(*.jpg)|" +
                "jpeg files (*.jpeg)|*.jpeg|bmp files (*.bmp)|*bmp|" +
                "gif files (*.gif)|*.gif|all files (*.*)|*.*";
            if (image_directory.ShowDialog() == DialogResult.OK)
                image_origin_path = image_directory.FileName;
            else
            {
                MessageBox.Show("이미지 불러오기를 취소했습니다.");
                return;
            }
            Bitmap image_origin = new Bitmap(image_origin_path);

            string image_save_path = string.Empty;
            FolderBrowserDialog save_directory = new FolderBrowserDialog();
            save_directory.Description = "분리된 이미지를 저장할 폴더";
            if (save_directory.ShowDialog() == DialogResult.OK)
                image_save_path = save_directory.SelectedPath;
            else
            {
                MessageBox.Show("저장 폴더 지정을 취소했습니다.");
                return;
            }

            int origin_width = image_origin.Width;
            int origin_height = image_origin.Height;

            int file_count = 0;
            for (int set_row = 0; set_row < origin_height / separate_height; set_row++)
            {
                for(int set_column = 0; set_column < origin_width / separate_width; set_column++)
                {
                    file_count++;
                    Bitmap image_piece = new Bitmap(separate_width, separate_height);
                    for(int piece_row = 0; piece_row < separate_height; piece_row++)
                    {
                        for(int piece_column = 0; piece_column < separate_width; piece_column++)
                        {
                            image_piece.SetPixel
                                (piece_column, piece_row, 
                                    image_origin.GetPixel
                                        (set_column * separate_width + piece_column, 
                                        set_row * separate_height + piece_row)
                                );
                        }
                    }
                    image_piece.Save(image_save_path + $"\\No.{file_count:D3}.bmp");
                }
            }
            MessageBox.Show($"이미지가 분리되었습니다.\n파일저장위치:{image_save_path}\n분리된 이미지:{file_count}개");
        }
        public void Get_Image_Size(int w, int h)
        {
            separate_width = w;
            separate_height = h;
        }

        public void Get_Arrange_Data(int r)
        {
            merge_row = r;
        }
    }
}