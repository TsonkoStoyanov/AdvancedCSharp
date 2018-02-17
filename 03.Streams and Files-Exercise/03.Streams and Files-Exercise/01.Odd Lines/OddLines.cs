using System;
using System.IO;

namespace _01.Odd_Lines
{
    class OddLines
    {
        static void Main()
        {
            using (var reader = new StreamReader("../Resources/text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    string line;

                    int lineNum = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNum % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }
                        lineNum++;
                    }
                }
            }
        }
    }
}
