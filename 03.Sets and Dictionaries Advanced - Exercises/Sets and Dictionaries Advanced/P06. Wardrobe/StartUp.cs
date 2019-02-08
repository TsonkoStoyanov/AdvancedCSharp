using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Wardrobe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                //Blue -> dress,jeans,hat

                string[] input = Console.ReadLine().Split(new[]
                {
                   "->", ",", " "
                }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string color = input[0];
                string[] typeOfdress = input.Skip(1).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < typeOfdress.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(typeOfdress[j]))
                    {
                        wardrobe[color].Add(typeOfdress[j], 0);
                    }

                    wardrobe[color][typeOfdress[j]]++;
                }

            }

            string[] searched = Console.ReadLine().Split();

            string searchedColor = searched[0];
            string searchedType = searched[1];



            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var type in item.Value)
                {
                    if (searchedColor == item.Key && searchedType == type.Key)
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value}");

                    }
                }
            }
        }
    }
}
