using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pokemon_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_path = 
                @"C:\\Users\\kimsd\\source\\repos\\Csharp_Study\\pokemon";
            StreamReader file_stream = 
                new StreamReader(file_path + "\\pokemon_global_name.txt");
            List<string> file_read = new List<string>();
            List<string[]> pokemon_dictionary = new List<string[]>();
            string readline;
            while((readline = file_stream.ReadLine()) != null)
            {
                if (readline == "-") continue;
                else
                {
                    string[] current = readline.Split(',');
                    string[] pokemon = { current[0], current[1], current[3] };
                    pokemon_dictionary.Add(pokemon);
                }
            }
            using (StreamWriter file = 
                new StreamWriter(file_path + "\\pokemon_translate.csv", 
                false, Encoding.GetEncoding("utf-8")))
            {
                file.WriteLine("영어,한글");
                foreach (string[] pokemon in pokemon_dictionary)
                    file.WriteLine($"{pokemon[2].ToLower()},{pokemon[1]}");
            }
        }
    }
}
