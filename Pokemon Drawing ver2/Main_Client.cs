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
        const int all_pokemon_count = 1344;     // 전체 포켓몬 이미지 수
        const int gen9pokemon_count = 124;      // 9세대포켓몬 이미지 수
        const int last_pokemon_number = 1010;   // 마지막 포켓몬 번호
        const double shiny_rate = 5;            // % 단위

        int gen_select = 9;                     // 선택된 세대 수
        int pokemon_number = 0;                 // 뽑으려는 포켓몬 번호
        int current_search_pokemon_number = 0;  // 찾은 포켓몬 번호 저장
        int current_random_pokemon_number = 0;  // 뽑은 포켓몬 번호 저장

        int sample_order_front = 0;             // 이미지 샘플 첫번째 순서
        int sample_order_back = 0;              // 이미지 샘플 마지막 순서
        int search_order_front = 0;
        int search_order_back = 0;
        int random_order_front = 0;
        int random_order_back = 0;

        bool shiny = false;                 // 색이 다른 포켓몬
        bool shiny_search = false;
        bool shiny_random = false;

        bool check_all_event = false;       // 모두 선택 옵션
        bool check_box_event = false;       // 개별 선택 옵션

        string pokemon_name_kor = string.Empty; // 포켓몬 한글 이름
        string pokemon_name_eng = string.Empty; // 포켓몬 영문 이름
        string file_path = string.Empty;        // 파일 경로
        string directory_path = string.Empty;   // 디렉토리

        List<int[]> number_dot = new List<int[]>();
        List<string> pokemon_form = new List<string>();

        Bitmap image_sample = new Bitmap(68, 56);
        Bitmap image_search = new Bitmap(68, 56);
        Bitmap image_random = new Bitmap(68, 56);
        Bitmap pixelart = new Bitmap(1600, 1100);

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

            List<string> number_dot_loc = new List<string>();
            number_dot_loc.Add("01,02,03,04,05,06,07,08,10,19,20,29,30,39,40,49,51,52,53,54,55,56,57,58");          // 0
            number_dot_loc.Add("11,20,21,22,23,24,25,26,27,28,29");                                                 // 1
            number_dot_loc.Add("01,02,07,08,09,10,16,19,20,25,29,30,35,39,40,44,49,51,52,53,59");                   // 2
            number_dot_loc.Add("01,02,07,08,10,19,20,24,29,30,34,39,40,44,49,51,52,53,55,56,57,58");                // 3
            number_dot_loc.Add("06,07,14,15,17,22,23,27,30,31,37,40,41,42,43,44,45,46,47,48,49,57");                // 4
            number_dot_loc.Add("00,01,02,03,04,05,08,10,14,19,20,24,29,30,34,39,40,44,49,50,55,56,57,58");          // 5
            number_dot_loc.Add("01,02,03,04,05,06,07,08,10,14,19,20,24,29,30,34,39,40,44,49,51,55,56,57,58");       // 6
            number_dot_loc.Add("00,01,02,10,20,30,36,37,38,39,40,43,44,45,50,51,52");                               // 7
            number_dot_loc.Add("01,02,03,05,06,07,08,10,14,19,20,24,29,30,34,39,40,44,49,51,52,53,55,56,57,58");    // 8
            number_dot_loc.Add("01,02,03,04,08,10,15,19,20,25,29,30,35,39,40,45,49,51,52,53,54,55,56,57,58");       // 9
            for (int i = 0; i < 10; i++)
            {
                string[] str_arr = number_dot_loc[i].Split(',');
                int[] int_arr = new int[str_arr.Length];
                for (int j = 0; j < str_arr.Length; j++)
                    int_arr[j] = int.Parse(str_arr[j]);
                number_dot.Add(int_arr);
            }

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
        private void get_pixelart(Bitmap pokemon)
        {
            // 색상 확인
            Color[,] color_pokemon = new Color[68, 56];
            Dictionary<Color, int> color_chart = new Dictionary<Color, int>();
            Dictionary<int, Color> color_chart_r = new Dictionary<int, Color>();
            int color_count = 1;
            int[,] color_table = new int[68, 56];
            Graphics field = Graphics.FromImage(pixelart);
            field.Clear(Color.White);
            color_chart.Add(Color.FromArgb(255,255,255,255), 0);
            color_chart_r.Add(0, Color.FromArgb(255,255,255,255));

            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    color_pokemon[col, row] = pokemon.GetPixel(col, row);
                    if (!color_chart.ContainsKey(color_pokemon[col, row]))
                    {
                        color_chart.Add(color_pokemon[col, row], color_count);
                        color_chart_r.Add(color_count, color_pokemon[col, row]);
                        color_count++;
                    }
                    color_table[col, row] = color_chart[color_pokemon[col, row]];
                }
            }

            // 그리기
            int cursor_x = 30;
            int cursor_y = 30;
            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    draw_blank(col * 18 + cursor_x, row * 18 + cursor_y);
                    draw_number(color_table[col, row], col * 18 + cursor_x, row * 18 + cursor_y);
                }
            }

            // 샘플 붙이기
            cursor_x = 1280;
            cursor_y = 30;
            int[] dx = { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
            int[] dy = { 0, 1, 2, 0, 1, 2, 0, 1, 2 };
            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    for (int i = 0; i < 9; i++)
                        pixelart.SetPixel
                                (cursor_x + dx[i] + col * 3, cursor_y + dy[i] + row * 3, color_pokemon[col, row]);
                }
            }

            string pokemon_name = string.Empty;
            if (tab_control.SelectedIndex == 0)
                pokemon_name = label_search_pokemon_data.Text;
            else
                pokemon_name = label_random_pokemon_data.Text;
            Graphics text = Graphics.FromImage(pixelart);
            cursor_x = 1280;
            cursor_y = 208;
            Brush black = new SolidBrush(Color.Black);
            Brush yellow = new SolidBrush(Color.Yellow);
            FontFamily _font = new FontFamily("굴림체");
            Font myFont = new Font(_font, 15, FontStyle.Regular, GraphicsUnit.Pixel);
            PointF startPoint = new PointF(cursor_x, cursor_y);
            text.DrawString(pokemon_name, myFont, black, startPoint);
            if (shiny)
            {
                startPoint.X -= 1;
                startPoint.Y -= 1;
                text.DrawString(pokemon_name, myFont, yellow, startPoint);
            }

            // 색상 표 그리기
            cursor_x = 1280;
            cursor_y = 253;
            startPoint.X = cursor_x;
            startPoint.Y = cursor_y;
            Pen pen = new Pen(Color.Black, 15);
            for(int i = 1; i < color_count; i++)
            {
                pen.Color = color_chart_r[i];
                text.DrawString(i.ToString(), myFont, black, startPoint);
                text.DrawLine(pen, startPoint.X + 20, startPoint.Y + 7, startPoint.X + 50, startPoint.Y + 7);
                if (i >= color_count / 2 && startPoint.X == cursor_x)
                {
                    startPoint.X = cursor_x + 70;
                    startPoint.Y = cursor_y;
                }
                else startPoint.Y += 21;
            }
        }
        private void get_file_name()
        {
            string path_ex = ".png";
            string path_sh = string.Empty;
            string path_check = string.Empty;
            int file_number_count = 1;
            if (shiny) path_sh = "_shiny";
            else path_sh = "";
            if(!File.Exists(file_path + path_sh + path_ex))
            {
                file_path += path_sh + path_ex;
                return;
            }
            while (File.Exists(file_path + path_sh + $"({file_number_count})" + path_ex))
                file_number_count++;
            file_path += path_sh + $"({file_number_count})" + path_ex;
        }
        private void draw_blank(int x, int y)
        {
            for (int i = 0; i < 19; i++)
            {
                pixelart.SetPixel(x + i, y, Color.FromArgb(255, 175, 175, 175));
                pixelart.SetPixel(x, y + i, Color.FromArgb(255, 175, 175, 175));
                pixelart.SetPixel(x + i, y + 18, Color.FromArgb(255, 175, 175, 175));
                pixelart.SetPixel(x + 18, y + i, Color.FromArgb(255, 175, 175, 175));
            }
        }
        private void draw_number(int number, int x, int y)
        {
            x += 2; y += 2;
            Stack<int> draw_this = new Stack<int>();
            while (number > 0)
            {
                draw_this.Push(number % 10);
                number /= 10;
            }
            while (draw_this.Count > 0)
            {
                foreach (int location in number_dot[draw_this.Pop()])
                {
                    int dx = location / 10;
                    int dy = location % 10;

                    if (check_number_style.Checked)
                        pixelart.SetPixel
                            (x + dx, y + dy, Color.FromArgb(255, 92, 92, 92));
                    else
                        pixelart.SetPixel
                            (x + dx, y + dy, Color.FromArgb(255, 175, 175, 175));
                }
                x += 7;
            }
        }

        private void tab_index_Changed(object sender, EventArgs e)
        {
            if(tab_control.SelectedIndex == 0)
            {
                pokemon_number = current_search_pokemon_number;
                sample_order_front = search_order_front;
                sample_order_back = search_order_back;
                shiny = shiny_search;
            }
            else
            {
                pokemon_number = current_random_pokemon_number;
                sample_order_front = random_order_front;
                sample_order_back = random_order_back;
                shiny = shiny_random;
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
                    current_search_pokemon_number = pokemon_number;
                    if (pokemon_number < 1 || pokemon_number > 1010)
                    {
                        MessageBox.Show("범위를 벗어났습니다.\n\r1~1010 사이의 숫자를 입력해주세요.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("입력이 잘못되었습니다.\n\r1~1010 사이의 숫자를 입력해주세요.");
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
            shiny_search = this.shiny;

            // 포켓몬 이름 찾기
            get_pokemon_name();

            // 이미지 샘플에서 포켓몬 위치 찾기
            get_pokemon_index();
            search_order_front = sample_order_front;
            search_order_back = sample_order_back;

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
            string pokemon_label = $"No.{int.Parse(textbox_number.Text):D3} {pokemon_name_kor}";
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
            get_pixelart(image_search);
            if (check_desktop.Checked)
            {
                file_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    + $"\\No{pokemon_number:D3}";
            }
            else
            {
                FolderBrowserDialog select_save_path = new FolderBrowserDialog();
                if (select_save_path.ShowDialog() == DialogResult.OK)
                {
                    directory_path = select_save_path.SelectedPath;
                    file_path = directory_path + $"\\No{pokemon_number:D3}";
                }
                else
                {
                    MessageBox.Show("폴더가 선택되지 않았습니다.");
                    return;
                }
            }
            get_file_name();
            pixelart.Save(file_path);
            MessageBox.Show("저장되었습니다.");
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
                else if (pokemon_number < 1011) { if (check_gen8.Checked) break; }
                else { if (check_gen9.Checked) break; }
            }
            pokemon_number++;
            current_random_pokemon_number = pokemon_number;

            // 이로치 뽑기
            Random shiny = new Random();
            if (shiny.Next(1000) < shiny_rate * 10) this.shiny = true;
            shiny_random = this.shiny;

            // 포켓몬 이름 찾기
            get_pokemon_name();

            // 이미지 샘플에서 포켓몬 위치 찾기
            get_pokemon_index();
            random_order_front = sample_order_front;
            random_order_back = sample_order_back;

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
            get_pixelart(image_random);

            if (check_desktop.Checked)
            {
                file_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    + $"\\No{pokemon_number:D3}";
            }
            else
            {
                FolderBrowserDialog select_save_path = new FolderBrowserDialog();
                if (select_save_path.ShowDialog() == DialogResult.OK)
                {
                    directory_path = select_save_path.SelectedPath;
                    file_path = directory_path + $"\\No{pokemon_number:D3}";
                }
                else
                {
                    MessageBox.Show("폴더가 선택되지 않았습니다.");
                    return;
                }
            }
            get_file_name();
            pixelart.Save(file_path);
            MessageBox.Show("저장되었습니다.");
        }
        private void check_all_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_event) return;
            check_all_event = true;
            if (check_all.Checked)
            {
                check_gen1.Checked = true;
                check_gen2.Checked = true;
                check_gen3.Checked = true;
                check_gen4.Checked = true;
                check_gen5.Checked = true;
                check_gen6.Checked = true;
                check_gen7.Checked = true;
                check_gen8.Checked = true;
                check_gen9.Checked = true;
                gen_select = 9;
                button_random_pokemon.Visible = true;
            }
            else
            {
                check_gen1.Checked = false;
                check_gen2.Checked = false;
                check_gen3.Checked = false;
                check_gen4.Checked = false;
                check_gen5.Checked = false;
                check_gen6.Checked = false;
                check_gen7.Checked = false;
                check_gen8.Checked = false;
                check_gen9.Checked = false;
                gen_select = 0;
                button_random_pokemon.Visible = false;
            }
            check_all_event = false;
        }
        private void check_gen1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen1.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }
        private void check_gen2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen2.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }
        private void check_gen3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen3.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }
        private void check_gen4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen4.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }
        private void check_gen5_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen5.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }
        private void check_gen6_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen6.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }
        private void check_gen7_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen7.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }
        private void check_gen8_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen8.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }

        private void check_gen9_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all_event) return;
            check_box_event = true;
            if (check_gen9.Checked) gen_select++;
            else gen_select--;
            if (gen_select == 0) button_random_pokemon.Visible = false;
            else button_random_pokemon.Visible = true;
            if (gen_select == 9) check_all.Checked = true;
            else check_all.Checked = false;
            check_box_event = false;
        }
    }
}