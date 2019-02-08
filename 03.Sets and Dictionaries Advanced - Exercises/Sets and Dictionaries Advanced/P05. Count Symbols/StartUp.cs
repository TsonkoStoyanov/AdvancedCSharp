using System;
using System.Collections.Generic;

namespace P05._Count_Symbols
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> countSymbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                if (!countSymbols.ContainsKey(ch))
                {
                    countSymbols.Add(ch, 0);
                }

                countSymbols[ch]++;
            }

            foreach (var symbol in countSymbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
