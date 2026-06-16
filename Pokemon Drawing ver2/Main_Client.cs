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
using System.Diagnostics;

namespace Pokemon_Drawing_ver2
{
    public partial class Main_Client : Form
    {
        const int all_pokemon_count = 1464;     // 전체 포켓몬 이미지 수
        const int last_pokemon_number = 1025;   // 마지막 포켓몬 번호
        const double shiny_rate = 5;            // % 단위

        const int gen8width = 68;               // 이미지 가로
        const int gen8height = 56;              // 이미지 세로
        const int gen8blanksize = 18;           // 픽셀 칸 크기
        const string indischool_url = "https://indischool.com/@celbeing";
        const string tistory_url = "https://celbeing.tistory.com/";

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

        bool shiny = false;                     // 색이 다른 포켓몬
        bool shiny_search = false;
        bool shiny_random = false;
        bool hide_search_image = false;
        bool hide_random_image = false;
        bool hide_search_name = false;
        bool hide_random_name = false;

        bool check_all_event = false;           // 모두 선택 옵션
        bool check_box_event = false;           // 개별 선택 옵션

        string pokemon_name_kor = string.Empty; // 포켓몬 한글 이름
        string pokemon_name_eng = string.Empty; // 포켓몬 영문 이름
        string search_pokemon_label = string.Empty;
        string random_pokemon_label = string.Empty;
        string file_path = string.Empty;        // 파일 경로
        string directory_path = string.Empty;   // 디렉토리

        List<int[]> number_dot = new List<int[]>();
        List<string> pokemon_form = new List<string>();

        Bitmap image_sample = new Bitmap(68, 56);
        Bitmap image_search = new Bitmap(68, 56);
        Bitmap image_random = new Bitmap(68, 56);

        Bitmap pixelart = new Bitmap(1600, 1100);       // 한칸 크기 18*18

        Assembly _assembly;
        StreamReader pokemon_name_search;

        private class ColorGroup
        {
            public string Name { get; private set; }
            public Color DisplayColor { get; private set; }
            private long red;
            private long green;
            private long blue;
            private int count;

            public ColorGroup(string name, Color displayColor)
            {
                Name = name;
                DisplayColor = displayColor;
            }

            public void Add(Color color)
            {
                red += color.R;
                green += color.G;
                blue += color.B;
                count++;
            }

            public Color GetAverageColor()
            {
                if (count == 0) return DisplayColor;
                return Color.FromArgb(
                    255,
                    (int)Math.Round(red / (double)count),
                    (int)Math.Round(green / (double)count),
                    (int)Math.Round(blue / (double)count));
            }
        }

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
            int count_sample = 0;                                                                       // 이미지 샘플 개수
            int count_order = 0;                                                                        // 확인하려는 image_name 번호
            int first = -1;                                                                             // 이미지 샘플 첫 번호
            int last = 0;                                                                               // 이미지 샘플 마지막 번호
            StreamReader pokemon_locate_find =
                new StreamReader(_assembly.GetManifestResourceStream
                ("Pokemon_Drawing_ver2.Resources.image_name.csv"), Encoding.UTF8);
            while (true)
            {
                if (count_order == all_pokemon_count)                                                   // 1~9세대 번호 전부 확인한 경우
                {
                    last = count_order - 1;                                                             // outofrange exception 방지
                    break;
                }
                string[] image_name = pokemon_locate_find.ReadLine().Split(',');                        // Image_name에서 StreamReader 한줄 읽어오고 ',' 기준으로 문자열 분리
                string[] image_no_name_form = image_name[1].Replace(".png", "").Split('-');             // .png 제거하고 '-' 기준으로 문자열 분리
                string[] image_kor_name = image_no_name_form[0].Split();                                // 공백기준으로 문자열 분리
                if (image_kor_name[1] == pokemon_name_kor)                                              // 한글이름이 일치하는 경우
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

        private ColorGroup get_color_group(Color color)
        {
            if (color.A < 20 || (color.R >= 250 && color.G >= 250 && color.B >= 250))
                return new ColorGroup("흰색", Color.White);

            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));
            double brightness = max / 255.0;
            double saturation = max == 0 ? 0 : (max - min) / (double)max;

            if (brightness < 0.12)
                return new ColorGroup("검정", Color.Black);

            if (saturation < 0.12)
            {
                if (brightness < 0.35) return new ColorGroup("진회색", Color.DimGray);
                if (brightness < 0.70) return new ColorGroup("회색", Color.Gray);
                return new ColorGroup("연회색", Color.LightGray);
            }

            float hue = color.GetHue();

            if (hue >= 18 && hue < 50 && brightness < 0.62 && saturation > 0.25)
                return new ColorGroup("갈색", Color.SaddleBrown);

            if (hue >= 25 && hue < 65 && brightness >= 0.62 && saturation < 0.55)
                return new ColorGroup("베이지", Color.BurlyWood);

            string name;
            Color displayColor;
            if (hue < 15 || hue >= 345)
            {
                name = "빨강";
                displayColor = Color.Red;
            }
            else if (hue < 35)
            {
                name = "주황";
                displayColor = Color.Orange;
            }
            else if (hue < 65)
            {
                name = "노랑";
                displayColor = Color.Gold;
            }
            else if (hue < 90)
            {
                name = "연두";
                displayColor = Color.YellowGreen;
            }
            else if (hue < 155)
            {
                name = "초록";
                displayColor = Color.Green;
            }
            else if (hue < 185)
            {
                name = "청록";
                displayColor = Color.Teal;
            }
            else if (hue < 210)
            {
                name = "하늘색";
                displayColor = Color.SkyBlue;
            }
            else if (hue < 245)
            {
                name = "파랑";
                displayColor = Color.Blue;
            }
            else if (hue < 270)
            {
                name = "남색";
                displayColor = Color.Navy;
            }
            else if (hue < 305)
            {
                name = "보라";
                displayColor = Color.Purple;
            }
            else if (hue < 330)
            {
                name = "자주";
                displayColor = Color.MediumVioletRed;
            }
            else
            {
                name = "분홍";
                displayColor = Color.Pink;
            }

            name = get_color_tone_name(name, brightness, saturation);

            return new ColorGroup(name, displayColor);
        }

        private string get_color_tone_name(string name, double brightness, double saturation)
        {
            if (brightness < 0.32)
                return "진한 " + name;

            if (saturation < 0.25)
                return brightness > 0.72 ? "연한 " + name : "탁한 " + name;

            if (brightness < 0.72)
                return is_warm_color(name) ? "탁한 " + name : "어두운 " + name;

            if (brightness > 0.92)
                return "밝은 " + name;

            if (saturation < 0.45)
                return "탁한 " + name;

            if (brightness > 0.84 && saturation < 0.65)
                return "연한 " + name;

            return name;
        }

        private bool is_warm_color(string name)
        {
            return name == "빨강"
                || name == "주황"
                || name == "노랑"
                || name == "연두"
                || name == "초록"
                || name == "분홍";
        }

        // 번호로 이름 찾기
        private void get_pokemon_name()
        {
            // 한영 이름 불러오기
            pokemon_name_search =
                new StreamReader(_assembly.GetManifestResourceStream
                ("Pokemon_Drawing_ver2.Resources.pokemon_no_kor_eng.csv"), Encoding.Default);
            while (true)
            {
                string[] no_kor_eng = pokemon_name_search.ReadLine().Split(',');// 한줄씩 불러오고 ',' 기준으로 문자열 분리
                if (int.Parse(no_kor_eng[0]) == pokemon_number)                 // StreamReader에서 불러온 번호가 일치하는 경우
                {
                    pokemon_name_kor = no_kor_eng[1];                           // 한글 이름 저장
                    pokemon_name_eng = no_kor_eng[2].ToLower();                 // 영문 이름 저장(소문자)
                    break;
                }
            }
            pokemon_name_search.Close();                                        // StreamReader 닫기
        }
        private void get_pokemon_image(int index, int difficulty, bool shiny)   // 샘플 이미지 만들기
        {
            Bitmap image_origin;
            Bitmap image_enlarge = new Bitmap(136, 112);
            Bitmap image_enlarge_gen9 = new Bitmap(97, 97);
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
            Color[,] image_color_gen9 = new Color[97, 97];
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
                image_search = new Bitmap(image_sample);
                update_search_image_view(image_enlarge);
            }
            else
            {
                image_random = new Bitmap(image_sample);
                update_random_image_view(image_enlarge);
            }
        }

        private Bitmap get_enlarged_pokemon_image(Bitmap pokemon)
        {
            Bitmap image_enlarge = new Bitmap(136, 112);
            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    Color color = pokemon.GetPixel(col, row);
                    image_enlarge.SetPixel(col * 2, row * 2, color);
                    image_enlarge.SetPixel(col * 2, row * 2 + 1, color);
                    image_enlarge.SetPixel(col * 2 + 1, row * 2, color);
                    image_enlarge.SetPixel(col * 2 + 1, row * 2 + 1, color);
                }
            }
            return image_enlarge;
        }

        private Bitmap get_hidden_pokemon_image(int width, int height)
        {
            Stream unknown_stream =
                _assembly.GetManifestResourceStream("Pokemon_Drawing_ver2.Resources.unknown.png");
            if (unknown_stream == null)
                return new Bitmap(width, height);

            Bitmap unknown = new Bitmap(unknown_stream);
            Bitmap hidden_image = get_scaled_bitmap(unknown, width, height);
            unknown.Dispose();
            unknown_stream.Dispose();
            return hidden_image;
        }

        private Bitmap get_scaled_bitmap(Bitmap source, int width, int height)
        {
            Bitmap scaled = new Bitmap(width, height);
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    scaled.SetPixel(
                        col,
                        row,
                        source.GetPixel(col * source.Width / width, row * source.Height / height));
                }
            }
            return scaled;
        }

        private void update_search_image_view()
        {
            if (hide_search_image)
                image_search_pokemon.Image = get_hidden_pokemon_image(136, 112);
            else
                image_search_pokemon.Image = get_enlarged_pokemon_image(image_search);
        }

        private void update_search_image_view(Bitmap image_enlarge)
        {
            if (hide_search_image)
                image_search_pokemon.Image = get_hidden_pokemon_image(136, 112);
            else
                image_search_pokemon.Image = image_enlarge;
        }

        private void update_random_image_view()
        {
            if (hide_random_image)
                image_random_pokemon.Image = get_hidden_pokemon_image(136, 112);
            else
                image_random_pokemon.Image = get_enlarged_pokemon_image(image_random);
        }

        private void update_random_image_view(Bitmap image_enlarge)
        {
            if (hide_random_image)
                image_random_pokemon.Image = get_hidden_pokemon_image(136, 112);
            else
                image_random_pokemon.Image = image_enlarge;
        }

        private string get_hidden_pokemon_label(bool is_shiny)
        {
            string hidden_label = "No.??? ???";
            if (is_shiny) hidden_label += "\n\r색이 다른 포켓몬!!!";
            return hidden_label;
        }

        private void update_search_name_view()
        {
            label_search_pokemon_data.Text = hide_search_name
                ? get_hidden_pokemon_label(shiny_search)
                : search_pokemon_label;
        }

        private void update_random_name_view()
        {
            label_random_pokemon_data.Text = hide_random_name
                ? get_hidden_pokemon_label(shiny_random)
                : random_pokemon_label;
        }

        private bool get_current_image_hidden()
        {
            return tab_control.SelectedIndex == 0 ? hide_search_image : hide_random_image;
        }

        private string get_current_pokemon_label()
        {
            if (tab_control.SelectedIndex == 0)
                return hide_search_name ? get_hidden_pokemon_label(shiny_search) : search_pokemon_label;
            return hide_random_name ? get_hidden_pokemon_label(shiny_random) : random_pokemon_label;
        }

        // 픽셀아트 만들기
        private void get_pixelart(Bitmap pokemon)
        {
            // 색상 확인
            Color[,] color_pokemon = new Color[68, 56];
            Dictionary<string, int> color_chart = new Dictionary<string, int>();
            Dictionary<int, ColorGroup> color_chart_r = new Dictionary<int, ColorGroup>();
            int color_count = 1;
            int[,] color_table = new int[68, 56];
            bool show_color_name = check_color_name.Checked;
            bool show_white_zero = check_white_zero.Checked && !check_painted.Checked;
            Graphics field = Graphics.FromImage(pixelart);
            field.Clear(Color.White);
            ColorGroup white = new ColorGroup("흰색", Color.White);
            color_chart.Add(get_color_chart_key(Color.White, white, show_color_name), 0);
            color_chart_r.Add(0, white);

            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    color_pokemon[col, row] = pokemon.GetPixel(col, row);
                    ColorGroup color_group = show_color_name
                        ? get_color_group(color_pokemon[col, row])
                        : new ColorGroup(string.Empty, color_pokemon[col, row]);
                    string color_key = get_color_chart_key(color_pokemon[col, row], color_group, show_color_name);
                    if (!color_chart.ContainsKey(color_key))
                    {
                        color_chart.Add(color_key, color_count);
                        color_chart_r.Add(color_count, color_group);
                        color_count++;
                    }
                    color_table[col, row] = color_chart[color_key];
                    color_chart_r[color_table[col, row]].Add(color_pokemon[col, row]);
                }
            }

            // 그리기
            int cursor_x = 30;
            int cursor_y = 30;
            for (int row = 0; row < 56; row++)
            {
                for (int col = 0; col < 68; col++)
                {
                    int x = col * 18 + cursor_x;
                    int y = row * 18 + cursor_y;

                    if (check_painted.Checked)
                        draw_painted_blank(x, y, color_chart_r[color_table[col, row]].GetAverageColor());

                    draw_blank(x, y);

                    if (!check_painted.Checked && (color_table[col, row] != 0 || show_white_zero))
                        draw_number(color_table[col, row], x, y);
                }
            }

            // 샘플 붙이기
            cursor_x = 1280;
            cursor_y = 30;
            if (get_current_image_hidden())
            {
                draw_hidden_pokemon_sample(cursor_x, cursor_y);
            }
            else
            {
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
            }

            string pokemon_name = get_current_pokemon_label();
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
            Font legendFont = new Font(_font, 13, FontStyle.Regular, GraphicsUnit.Pixel);
            Pen pen = new Pen(Color.Black, 15);
            for(int i = 1; i < color_count; i++)
            {
                pen.Color = color_chart_r[i].GetAverageColor();
                text.DrawLine(pen, startPoint.X, startPoint.Y + 7, startPoint.X + 24, startPoint.Y + 7);
                string color_name;
                if (show_color_name)
                    color_name = check_painted.Checked
                        ? color_chart_r[i].Name
                        : i.ToString() + " " + color_chart_r[i].Name;
                else
                    color_name = i.ToString();
                text.DrawString(color_name, legendFont, black, new PointF(startPoint.X + 34, startPoint.Y));
                if (i >= color_count / 2 && startPoint.X == cursor_x)
                {
                    startPoint.X = cursor_x + 155;
                    startPoint.Y = cursor_y;
                }
                else startPoint.Y += 21;
            }
        }

        private string get_color_chart_key(Color color, ColorGroup color_group, bool show_color_name)
        {
            return show_color_name ? color_group.Name : color.ToArgb().ToString();
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
        private void draw_painted_blank(int x, int y, Color color)
        {
            for (int row = 1; row < 18; row++)
                for (int col = 1; col < 18; col++)
                    pixelart.SetPixel(x + col, y + row, color);
        }
        private void draw_hidden_pokemon_sample(int x, int y)
        {
            Bitmap hidden_image = get_hidden_pokemon_image(204, 168);
            Graphics hidden = Graphics.FromImage(pixelart);
            hidden.DrawImage(hidden_image, x, y);
            hidden.Dispose();
            hidden_image.Dispose();
        }
        private void draw_number(int number, int x, int y)
        {
            x += 2; y += 2;
            Stack<int> draw_this = new Stack<int>();
            if (number == 0)
                draw_this.Push(0);
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

        // 번호로 포켓몬 뽑기
        private void button_search_pokemon_Click(object sender, EventArgs e)
        {
            pokemon_form.Clear();
            this.shiny = false;
            hide_search_image = false;
            hide_search_name = false;

            // 번호 입력
            if (textbox_number.Text != string.Empty)
            {
                try
                {
                    pokemon_number = int.Parse(textbox_number.Text);
                    current_search_pokemon_number = pokemon_number;
                    if (pokemon_number < 1 || pokemon_number > 1025)
                    {
                        MessageBox.Show("범위를 벗어났습니다.\n\r1~1025 사이의 숫자를 입력해주세요.");
                        return;
                    }
                    if (pokemon_number > 1008)
                    {
                        MessageBox.Show("1009번부터의 포켓몬은 아직 이미지가 없어요... 다음 업데이트를 기다려주세요.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("입력이 잘못되었습니다.\n\r1~1025 사이의 숫자를 입력해주세요.");
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
            search_pokemon_label = pokemon_label;
            update_search_name_view();

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

        // 랜덤 포켓몬 뽑기
        private void button_random_pokemon_Click(object sender, EventArgs e)
        {
            pokemon_form.Clear(); 
            this.shiny = false;
            hide_random_image = false;
            hide_random_name = false;

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
                else if (pokemon_number < 905) { if (check_gen8.Checked) break; }
                else if (pokemon_number < 1008){ if (check_gen9.Checked) break; }
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
            random_pokemon_label = pokemon_label;
            update_random_name_view();

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

        private void image_search_pokemon_Click(object sender, EventArgs e)
        {
            if (!button_search_out.Visible) return;
            hide_search_image = !hide_search_image;
            update_search_image_view();
        }
        private void image_random_pokemon_Click(object sender, EventArgs e)
        {
            if (!button_random_out.Visible) return;
            hide_random_image = !hide_random_image;
            update_random_image_view();
        }
        private void label_search_pokemon_data_Click(object sender, EventArgs e)
        {
            if (!label_search_pokemon_data.Visible) return;
            hide_search_name = !hide_search_name;
            update_search_name_view();
        }
        private void label_random_pokemon_data_Click(object sender, EventArgs e)
        {
            if (!label_random_pokemon_data.Visible) return;
            hide_random_name = !hide_random_name;
            update_random_name_view();
        }

        // 각 세대 체크박스 확인
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

        private void Main_Client_Load(object sender, EventArgs e)
        {
            set_signature_links(label_signature);
            set_signature_links(label1);
        }

        private void set_signature_links(LinkLabel signature)
        {
            string[] lines = signature.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (lines.Length < 2) return;

            signature.Links.Clear();
            signature.Links.Add(0, lines[0].Length, indischool_url);
            signature.Links.Add(lines[0].Length + 2, lines[1].Length, tistory_url);
        }

        private void signature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.LinkData == null) return;

            string url = e.Link.LinkData.ToString();
            e.Link.Visited = true;

            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch
            {
                MessageBox.Show("링크를 열 수 없습니다.\n\r" + url);
            }
        }
    }
}
