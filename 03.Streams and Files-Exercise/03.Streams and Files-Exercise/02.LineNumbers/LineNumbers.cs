using System;
using System.IO;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main()
        {
            using (var reader = new StreamReader("../Resources/text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    string line;
                    int lineNum = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {lineNum}: {line}");
                        lineNum++;
                    }
                }
            }


        }
    }
}
