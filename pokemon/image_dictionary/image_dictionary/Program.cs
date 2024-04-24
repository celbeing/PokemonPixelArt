using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace image_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] check = new bool[1010];
            Dictionary<string, string> pokemon_dic = new Dictionary<string, string>();  // 번역기
            Dictionary<string, int> pokemon_num = new Dictionary<string, int>();        // 번호
            string pokemon_list_path = Environment.CurrentDirectory;
            pokemon_list_path = Path.GetDirectoryName(pokemon_list_path);
            pokemon_list_path = Path.GetDirectoryName(pokemon_list_path);
            pokemon_list_path = Path.GetDirectoryName(pokemon_list_path);

            // 이름 번역 파일 불러오기
            StreamReader pokemon_dic_sr = 
                new StreamReader(Path.Combine(Path.Combine(pokemon_list_path,"resources"),"pokemon_dictionary.csv"));
            string sr_line = string.Empty;
            while((sr_line = pokemon_dic_sr.ReadLine()) != null)
            {
                string[] pokemon_set = sr_line.Split(',');
                pokemon_dic.Add(pokemon_set[0], pokemon_set[1]);
            }
            pokemon_dic_sr.Close();

            // 포켓몬 번호 불러오기
            StreamReader pokemon_num_sr =
                new StreamReader(Path.Combine(Path.Combine(pokemon_list_path, "resources"), "pokemon_no_kor_eng.csv"));
            while((sr_line = pokemon_num_sr.ReadLine()) != null)
            {
                string[] pokemon_no = sr_line.Split(',');
                pokemon_num.Add(pokemon_no[1], int.Parse(pokemon_no[0]));
            }
            pokemon_num_sr.Close();

            pokemon_list_path = Path.GetDirectoryName(pokemon_list_path);
            pokemon_list_path = Path.GetDirectoryName(pokemon_list_path);

            DirectoryInfo image_name = new DirectoryInfo(pokemon_list_path + @"\\pokemon-gen9\\regular");
            StreamWriter image_name_list = new StreamWriter(pokemon_list_path + @"\\image_name.csv");
            foreach (FileInfo name in image_name.GetFiles())
            {
                if(name.Extension.ToLower().CompareTo(".png") == 0)
                {
                    int pokemon_number = 0;
                    string old_file_name = name.Name;
                    string new_file_name = string.Empty;
                    string file_name = name.Name.Substring(0, name.Name.Length - 4);
                    List<string> file_name_split = new List<string>(file_name.ToLower().Split('-'));
                    if (file_name_split[0].Length == 0) file_name_split.RemoveAt(0);
                    if (pokemon_dic.ContainsKey(file_name_split[0]))
                    {
                        file_name_split[0] = pokemon_dic[file_name_split[0]];
                        pokemon_number = pokemon_num[file_name_split[0]];
                        check[pokemon_number - 1] = true;
                        new_file_name = $"no{pokemon_number:D3} ";
                    }
                    else
                    {
                        int index = 1;
                        while (true)
                        {
                            file_name_split[index] = file_name_split[index - 1] + '-' + file_name_split[index];
                            file_name_split[index - 1] = string.Empty;
                            if (pokemon_dic.ContainsKey(file_name_split[index]))
                            {
                                file_name_split[index] = pokemon_dic[file_name_split[index]];
                                pokemon_number = pokemon_num[file_name_split[index]];
                                check[pokemon_number - 1] = true;
                                new_file_name = $"no{pokemon_number:D3} ";
                                break;
                            }
                            index++;
                        }
                    }
                    for(int i = 0; i < file_name_split.Count; i++)
                    {
                        if (pokemon_dic.TryGetValue(file_name_split[i], out string value))
                            file_name_split[i] = value;
                    }

                    if (file_name_split[0] == "마휘핑" && file_name_split.Count > 2)
                    {
                        if (file_name_split[2] == "밀키")
                        {
                            file_name_split[1] = file_name_split[2] + file_name_split[1];
                            file_name_split[2] = string.Empty;
                        }
                        else
                        {
                            file_name_split[1] += file_name_split[2];
                            file_name_split[2] = string.Empty;
                        }
                        file_name_split[1] = "(" + file_name_split[1] + "_" + file_name_split[3] + ")";
                        file_name_split[3] = string.Empty;
                    }
                    else if(file_name_split[0] == "배쓰나이" && file_name_split.Count > 1)
                    {
                        if (file_name_split.Count < 2) { }
                        else
                        {
                            file_name_split[1] = "(" + file_name_split[1] + file_name_split[2] + ")";
                            file_name_split[2] = string.Empty;
                        }
                    }
                    else if((file_name_split[0] == "플라베베" 
                        || file_name_split[0] == "플라엣테" 
                        || file_name_split[0] == "플라제스") 
                        && file_name_split.Count > 1)
                        file_name_split[1] = "(" + file_name_split[1] + ")";
                    foreach (string file_name_piece in file_name_split)
                    {
                        if (file_name_piece == String.Empty) continue;
                        new_file_name += file_name_piece + '-';
                    }
                    image_name_list.WriteLine($"{old_file_name},{new_file_name.Substring(0, new_file_name.Length - 1) + ".png"}");
                }
            }
            image_name_list.Close();
            Console.WriteLine("Finished");
            for(int i = 0; i < 905; i++)
                if (!check[i]) Console.WriteLine($"No.{i + 1:D3} is not found.");
        }
    }
}
