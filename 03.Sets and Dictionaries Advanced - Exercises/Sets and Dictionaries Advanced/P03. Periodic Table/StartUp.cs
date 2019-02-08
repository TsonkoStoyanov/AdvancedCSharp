using System;
using System.Collections.Generic;

namespace P03._Periodic_Table
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemicals = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] inputChemicals = Console.ReadLine().Split();

                foreach (var chemical in inputChemicals)
                {
                    chemicals.Add(chemical);

                }

            }

            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}
