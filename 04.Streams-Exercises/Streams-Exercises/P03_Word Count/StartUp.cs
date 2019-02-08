using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03_Word_Count
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string wordsSource = "../../../../files/words.txt";

            string source = "../../../../files/text.txt";

            string result = "../../../../files/result.txt";

            var words = new Dictionary<string, int>();

            using (StreamReader sr = new StreamReader(wordsSource))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToLower();

                    if (!words.ContainsKey(line))
                    {
                        words.Add(line, 0);
                    }
                }
            }

            using (StreamReader sr = new StreamReader(source))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToLower();

                    Regex regex = new Regex("[A-Za-z]+");

                    foreach (Match item in regex.Matches(line))
                    {
                        if (words.ContainsKey(item.Value))
                        {
                            words[item.Value]++;
                        }
                    }

                }
            }

            using (StreamWriter sw = new StreamWriter(result))
            {
                foreach (var word in words.OrderByDescending(x=>x.Value))
                {
                    sw.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
