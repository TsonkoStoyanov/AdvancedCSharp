using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Regeh
    {
        static void Main()
        {
            var pattern = @"\[[A-Za-z]+<([0-9]+)+REGEH([0-9]+)+>[a-zA-Z]+\]";

            var input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            List<int> indexes = new List<int>();

            foreach (Match match in matches)
            {
                indexes.Add(int.Parse(match.Groups[1].Value));
                indexes.Add(int.Parse(match.Groups[2].Value));

            }

            var current = 0;

            foreach (var index in indexes)
            {
                current += index;
                int charIndex = current % (input.Length - 1);
                Console.Write(input[charIndex]);
            }
        }
    }
}
