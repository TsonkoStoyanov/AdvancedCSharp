using System;

namespace _02._Knights_of_Honor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine($"Sir {x}");

            string[] names = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
