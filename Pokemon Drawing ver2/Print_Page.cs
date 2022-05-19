using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_Drawing_ver2
{
    public partial class Print_Page : Form
    {
        Bitmap pokemon;
        public Print_Page(Bitmap pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
        }
        private void get_pokemon_pixelart()
        {
            Color[,] color_pokemon = new Color[68, 56];
            Dictionary<Color, int> color_chart = new Dictionary<Color, int>();
            int color_count = 0;
            int[,] color_table = new int[68, 56];

            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    color_pokemon[col, row] = pokemon.GetPixel(col, row);
                    if (!color_chart.ContainsKey(color_pokemon[col, row]))
                    {
                        color_chart.Add(color_pokemon[col, row], color_count);
                        color_count++;
                    }
                    color_table[col, row] = color_chart[color_pokemon[col, row]];
                }
            }
        }
        private void Print_Page_Load(object sender, EventArgs e)
        {
            get_pokemon_pixelart();
        }
        
    }
}
