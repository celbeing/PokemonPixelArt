using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pokemon_Drawing_v2
{
    public partial class Main_Client : Form
    {
        int pokemon_number = 0;
        string path = string.Empty;
        public Main_Client()
        {
            InitializeComponent();
        }

        private void button_search_pokemon_Click(object sender, EventArgs e)
        {
            if(textbox_number.Text != string.Empty)
            {
                try
                {
                    pokemon_number = int.Parse(textbox_number.Text);
                }
                catch
                {
                    MessageBox.Show("잘못된 값을 입력했습니다.");
                    return;
                }
                if(pokemon_number < 1 || pokemon_number > 905)
                {
                    MessageBox.Show("잘못된 값을 입력했습니다.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("입력된 값이 없습니다.");
            }
            path = Directory.GetCurrentDirectory();
            path = 
        }
    }
}
