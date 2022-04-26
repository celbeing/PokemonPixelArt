using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemon_pixelart_maker
{
    public partial class pokemon_pick : Form
    {
        public pokemon_pick()
        {
            InitializeComponent();
        }

        private void pokemon_Click(object sender, EventArgs e)
        {

        }

        private void create_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int img_row = r.Next(54);
            int img_column = r.Next(15)*2;
            if (r.Next() % 10 == 0) img_column++;
            int pokemon_no = img_row * 32 + img_column;
            img_row *= 30; img_column *= 40;

            Bitmap pokemon_img = new Bitmap(40,30);
            Bitmap pokemon_set =
                new Bitmap(pokemon_pixelart_maker.Properties.Resources.pokemon_sample_gen8);
            Color[,] pokemon_color = new Color[pokemon_set.Width, pokemon_set.Height];
            for (int j = 0; j < pokemon_set.Height; j++)
            {
                for (int i = 0; i < pokemon_set.Width; i++)
                {
                    pokemon_color[i, j] = pokemon_set.GetPixel(i, j);
                }
            }
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 40; j++)
                    pokemon_img.SetPixel(j, i, pokemon_color[img_column + j, img_row + i]);
            }
            pokemon.Image = new Bitmap(pokemon_img);

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

        private void pokemon_pick_Load(object sender, EventArgs e)
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
