using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.Word_Count
{
    class WordCount
    {
        static void Main()
        {
            List<string> wordsList = new List<string>();
            ReadWords(wordsList);
            List<string> textList = new List<string>();
            ReadText(textList);

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in wordsList)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount[word] = 0;
                }
            }
            foreach (var text in textList)
            {
                if (wordsCount.ContainsKey(text))
                {
                    wordsCount[text]++;
                }
            }

            PrintResult(wordsCount);

        }

        private static void PrintResult(Dictionary<string, int> wordsCount)
        {
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                foreach (var word in wordsCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }

        public static void ReadText(List<string> textList)
        {
            using (StreamReader textReader = new StreamReader("../Resources/text.txt"))
            {
                string line = String.Empty;

                while ((line = textReader.ReadLine()) != null)
                {
                    string[] text = line.ToLower()
                        .Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

                    textList.AddRange(text);
                }
            }
        }

        public static void ReadWords(List<string> wordsList)
        {
            using (StreamReader wordsReader = new StreamReader("../Resources/words.txt"))
            {
                string line = String.Empty;

                while ((line = wordsReader.ReadLine()) != null)
                {
                    string[] words = line.ToLower()
                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    wordsList.AddRange(words);
                }
            }
        }
    }
}
