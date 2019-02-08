using System;
using System.IO;

namespace P01_Odd_Lines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string source = "../../../../files/text.txt";
            using (StreamReader sr = new StreamReader(source))
            {
                string line;
                int counter = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                }
            }

        }
    }
}
