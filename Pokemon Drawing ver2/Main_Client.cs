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

namespace Pokemon_Drawing_ver2
{
    public partial class Main_Client : Form
    {
        int pokemon_number = 0;
        byte gen_select = 8;
        string file_path = string.Empty;
        string directory_path = string.Empty;
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
                    if(pokemon_number < 1 || pokemon_number > 905)
                    {
                        MessageBox.Show("범위를 벗어났습니다.\n\r1~905 사이의 숫자를 입력해주세요.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("입력이 잘못되었습니다.\n\r1~905 사이의 숫자를 입력해주세요.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("포켓몬 번호를 입력해주세요.");
                return;
            }
            button_search_out.Visible = true;
            combo_search_pokemon_difficulty.Visible = true;
            combo_search_pokemon_form.Visible = true;
        }
        private void button_random_pokemon_Click(object sender, EventArgs e)
        {
            button_random_out.Visible = true;
            combo_random_pokemon_difficulty.Visible = true;
            combo_random_pokemon_form.Visible = true;
        }

        private void check_gen1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_gen1.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
        }

        private void check_gen2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_gen2.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
        }

        private void check_gen3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_gen3.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
        }

        private void check_gen4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_gen4.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
        }

        private void check_gen5_CheckedChanged(object sender, EventArgs e)
        {
            if (check_gen5.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
        }

        private void check_gen6_CheckedChanged(object sender, EventArgs e)
        {
            if (check_gen6.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
        }

        private void check_gen7_CheckedChanged(object sender, EventArgs e)
        {
            if (check_gen7.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
        }

        private void check_gen8_CheckedChanged(object sender, EventArgs e)
        {
            if (check_gen8.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
        }
    }
}
