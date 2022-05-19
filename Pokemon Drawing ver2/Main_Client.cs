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
using System.Reflection;

namespace Pokemon_Drawing_ver2
{
    public partial class Main_Client : Form
    {
        byte gen_select = 8;                // 선택된 세대 수
        int pokemon_number = 0;             // 뽑으려는 포켓몬 번호
        int sample_order_front = 0;         // 이미지 샘플 첫번째 순서
        int sample_order_back = 0;          // 이미지 샘플 마지막 순서
        bool shiny = false;                 // 색이 다른 포켓몬
        const int all_pokemon_count = 1344; // 전체 포켓몬 이미지 수
        const int last_pokemon_number = 905;// 마지막 포켓몬 번호
        const double shiny_rate = 1;        // % 단위

        string pokemon_name_kor = string.Empty;
        string pokemon_name_eng = string.Empty;
        string file_path = string.Empty;
        string directory_path = string.Empty;

        List<string> pokemon_form = new List<string>();
        Bitmap image_sample = new Bitmap(68, 56);
        Bitmap image_search = new Bitmap(68, 56);
        Bitmap image_random = new Bitmap(68, 56);

        Assembly _assembly;
        StreamReader pokemon_name_search;
        public Main_Client()
        {
            InitializeComponent();
            combo_random_pokemon_difficulty.Items.Add("쉬움");
            combo_random_pokemon_difficulty.Items.Add("보통");
            combo_random_pokemon_difficulty.Items.Add("어려움");
            combo_search_pokemon_difficulty.Items.Add("쉬움");
            combo_search_pokemon_difficulty.Items.Add("보통");
            combo_search_pokemon_difficulty.Items.Add("어려움");

            _assembly = Assembly.GetExecutingAssembly();
        }

        private void get_pokemon_index()
        {
            int count_sample = 0;
            int count_order = 0;
            int first = -1;
            int last = 0;
            StreamReader pokemon_locate_find =
                new StreamReader(_assembly.GetManifestResourceStream
                ("Pokemon_Drawing_ver2.Resources.image_name.csv"));
            while (true)
            {
                if (count_order == all_pokemon_count)
                {
                    last = count_order - 1;
                    break;
                }
                string[] image_name = pokemon_locate_find.ReadLine().Split(',');
                string[] image_no_name_form = image_name[1].Replace(".png", "").Split('-');
                string[] image_kor_name = image_no_name_form[0].Split();
                if (image_kor_name[1] == pokemon_name_kor)
                {
                    if (first == -1) first = count_order;
                    count_sample++;
                    pokemon_form.Add(image_name[1].Substring(6).Replace("-", " ").Replace("_", "-"));
                }
                else if (first != -1)
                {
                    last = count_order - 1;
                    break;
                }
                count_order++;
            }
            sample_order_front = first;
            sample_order_back = last;
            pokemon_locate_find.Close();
        }
        private void get_pokemon_name()
        {
            pokemon_name_search =
                new StreamReader(_assembly.GetManifestResourceStream
                ("Pokemon_Drawing_ver2.Resources.pokemon_no_kor_eng.csv"));
            while (true)
            {
                string[] no_kor_eng = pokemon_name_search.ReadLine().Split(',');
                if (int.Parse(no_kor_eng[0]) == pokemon_number)
                {
                    pokemon_name_kor = no_kor_eng[1];
                    pokemon_name_eng = no_kor_eng[2].ToLower();
                    break;
                }
            }
            pokemon_name_search.Close();
        }
        private void get_pokemon_image(int index, int difficulty, bool shiny)
        {
            Bitmap image_enlarge = new Bitmap(136, 112);
            Bitmap image_origin;
            if (shiny)
            {
                if (difficulty == 0)
                {
                    image_origin =
                        new Bitmap(Pokemon_Drawing_ver2.Properties.Resources.image_shiny_easy);
                }
                else if (difficulty == 1)
                {
                    image_origin =
                        new Bitmap(Pokemon_Drawing_ver2.Properties.Resources.image_shiny_normal);
                }
                else
                {
                    image_origin =
                        new Bitmap(Pokemon_Drawing_ver2.Properties.Resources.image_shiny_hard);
                }
            }
            else
            {
                if (difficulty == 0)
                {
                    image_origin =
                        new Bitmap(Pokemon_Drawing_ver2.Properties.Resources.image_regular_easy);
                }
                else if (difficulty == 1)
                {
                    image_origin =
                        new Bitmap(Pokemon_Drawing_ver2.Properties.Resources.image_regular_normal);
                }
                else
                {
                    image_origin =
                        new Bitmap(Pokemon_Drawing_ver2.Properties.Resources.image_regular_hard);
                }
            }

            Color[,] image_color = new Color[68, 56];
            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    image_color[col, row] = image_origin.GetPixel
                        ((index % 32) * 68 + col, (index / 32) * 56 + row);
                }
            }
            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    image_sample.SetPixel(col, row, image_color[col, row]);
                    image_enlarge.SetPixel(col * 2, row * 2, image_color[col, row]);
                    image_enlarge.SetPixel(col * 2, row * 2 + 1, image_color[col, row]);
                    image_enlarge.SetPixel(col * 2 + 1, row * 2, image_color[col, row]);
                    image_enlarge.SetPixel(col * 2 + 1, row * 2 + 1, image_color[col, row]);
                }
            }
            if (tab_control.SelectedIndex == 0)
            {
                image_search = image_sample;
                image_search_pokemon.Image = image_enlarge;
            }
            else
            {
                image_random = image_sample;
                image_random_pokemon.Image = image_enlarge;
            }
        }

        private void button_search_pokemon_Click(object sender, EventArgs e)
        {
            pokemon_form.Clear();
            this.shiny = false;

            // 번호 입력
            if (textbox_number.Text != string.Empty)
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

            // 이로치 뽑기
            Random shiny = new Random();
            if (shiny.Next(1000) < shiny_rate * 10) this.shiny = true;

            // 포켓몬 이름 찾기
            get_pokemon_name();

            // 이미지 샘플에서 포켓몬 위치 찾기
            get_pokemon_index();

            // 콤보박스 초기화
            combo_search_pokemon_form.Items.Clear();
            foreach (string pokemon_forms in pokemon_form)
                combo_search_pokemon_form.Items.Add(pokemon_forms.Replace(".png", ""));
            combo_search_pokemon_form.SelectedIndex = pokemon_form.Count - 1;
            combo_search_pokemon_difficulty.SelectedIndex = 1;

            // 폼 숨김 해제
            button_search_out.Visible = true;
            combo_search_pokemon_difficulty.Visible = true;
            combo_search_pokemon_form.Visible = true;
            label_search_pokemon_data.Visible = true;
            string pokemon_label = $"No.{textbox_number.Text} {pokemon_name_kor}";
            if (this.shiny) pokemon_label += "\n\r색이 다른 포켓몬!!!";
            label_search_pokemon_data.Text = pokemon_label;

            // 포켓몬 이미지 출력
            get_pokemon_image(sample_order_back, combo_search_pokemon_difficulty.SelectedIndex, this.shiny);
        }
        private void combo_search_pokemon_form_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_pokemon_image
                (sample_order_front + combo_search_pokemon_form.SelectedIndex,
                combo_search_pokemon_difficulty.SelectedIndex, this.shiny);
        }
        private void combo_search_pokemon_difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_pokemon_image
                (sample_order_front + combo_search_pokemon_form.SelectedIndex,
                combo_search_pokemon_difficulty.SelectedIndex, this.shiny);
        }
        private void button_search_out_Click(object sender, EventArgs e)
        {
            Print_Page print = new Print_Page(image_search);
        }
        private void button_random_pokemon_Click(object sender, EventArgs e)
        {
            pokemon_form.Clear();
            this.shiny = false;

            // 포켓몬 번호 뽑기
            Random number = new Random();
            while (true)
            {
                pokemon_number = number.Next(last_pokemon_number);
                if (pokemon_number < 151) { if (check_gen1.Checked) break; }
                else if (pokemon_number < 251) { if (check_gen2.Checked) break; }
                else if (pokemon_number < 386) { if (check_gen3.Checked) break; }
                else if (pokemon_number < 493) { if (check_gen4.Checked) break; }
                else if (pokemon_number < 649) { if (check_gen5.Checked) break; }
                else if (pokemon_number < 721) { if (check_gen6.Checked) break; }
                else if (pokemon_number < 807) { if (check_gen7.Checked) break; }
                else { if (check_gen8.Checked) break; }
            }
            pokemon_number++;

            // 이로치 뽑기
            Random shiny = new Random();
            if (shiny.Next(1000) < shiny_rate * 10) this.shiny = true;

            // 포켓몬 이름 찾기
            get_pokemon_name();

            // 이미지 샘플에서 포켓몬 위치 찾기
            get_pokemon_index();

            button_random_out.Visible = true;
            combo_random_pokemon_difficulty.Visible = true;
            combo_random_pokemon_form.Visible = true;
            label_random_pokemon_data.Visible = true;
            string pokemon_label = $"No.{pokemon_number:D3} {pokemon_name_kor}";
            if (this.shiny) pokemon_label += "\n\r색이 다른 포켓몬!!!";
            label_random_pokemon_data.Text = pokemon_label;

            // 콤보박스 초기화
            combo_random_pokemon_form.Items.Clear();
            foreach (string pokemon_forms in pokemon_form)
                combo_random_pokemon_form.Items.Add(pokemon_forms.Replace(".png", ""));
            combo_random_pokemon_form.SelectedIndex = pokemon_form.Count - 1;
            combo_random_pokemon_difficulty.SelectedIndex = 1;

            // 포켓몬 이미지 출력
            get_pokemon_image(sample_order_back, combo_random_pokemon_difficulty.SelectedIndex, this.shiny);
        }
        private void combo_random_pokemon_form_SelectedIndexChanged(object sender, EventArgs e)
        {
             get_pokemon_image
                (sample_order_front + combo_random_pokemon_form.SelectedIndex,
                combo_random_pokemon_difficulty.SelectedIndex, this.shiny);
        }
        private void combo_random_pokemon_difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_pokemon_image
                (sample_order_front + combo_random_pokemon_form.SelectedIndex,
                combo_random_pokemon_difficulty.SelectedIndex, this.shiny);
        }
        private void button_random_out_Click(object sender, EventArgs e)
        {
            Print_Page print = new Print_Page(image_random);
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
