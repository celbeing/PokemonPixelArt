using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pixel_map_editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void load_image_Click(object sender, EventArgs e)
        {
            string pokemon_image = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pokemon_image = dialog.FileName;
            }
            else return;
            pokemon.Image = Bitmap.FromFile(pokemon_image);
        }
        private void random_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string path = dialog.SelectedPath;
            Random r = new Random();
            int image_num = r.Next() % 1024 + 1;
            path += $"\\image{image_num}.bmp";
            pokemon.Image = Bitmap.FromFile(path);
        }

        private void pokemon_Click(object sender, EventArgs e)
        {

        }

        private void create_Click(object sender, EventArgs e)
        {
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            Color[,] map = new Color[40, 30];
            Bitmap pic = new Bitmap(pokemon.Image);
            Dictionary<Color, int> color_code = new Dictionary<Color, int>();
            int color_count = 0;

            int[,] table = new int[40, 30];

            color_table.Columns.Add("숫자", "숫자");
            color_table.Columns.Add("색깔", "색깔");
            for (int j = 0; j < 30; j++)
            {
                for(int i = 0; i < 40; i++)
                {
                    map[i, j] = pic.GetPixel(i, j);
                    if (!color_code.ContainsKey(map[i, j]))
                    {
                        color_code.Add(map[i, j], color_count);
                        color_table.Rows.Add($"{color_count}"," ");
                        Color key = color_code.FindFirstKeyByValue(color_count);
                        color_table[1, color_count].Style.BackColor = key;
                        color_count++;
                    }
                    table[i, j] = color_code[map[i,j]];
                }
            }
            for (int i = 0; i < 40; i++)
                pixel_table.Columns.Add(" "," ");
            for(int i = 0; i < 30; i++)
            {
                
                string[] row = new string[40];
                for (int j = 0; j < 40; j++)
                {
                    row[j] = table[j, i] == 0 ? " " : table[j,i].ToString();
                }
                pixel_table.Rows.Add(row);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public static class Ext
    {
        public static K FindFirstKeyByValue<K, V>(this Dictionary<K, V> dict, V val)
        {
            return dict.FirstOrDefault(entry =>
                EqualityComparer<V>.Default.Equals(entry.Value, val)).Key;
        }
    }
}
