using System;
using System.IO;

namespace P02_Line_Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("../../../../files/text.txt"))
            {
                using (StreamWriter sw = new StreamWriter("../../../../files/output.txt"))
                {


                    string line;
                    int counter = 1;

                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine($"Line {counter}: {line}");
                        counter++;
                    }
                }
            }

        }
    }
}
