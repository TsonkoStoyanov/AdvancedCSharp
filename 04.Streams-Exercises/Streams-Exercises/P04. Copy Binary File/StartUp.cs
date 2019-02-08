using System;
using System.IO;

namespace P04._Copy_Binary_File
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string source = "../../../../files/copyMe.png";
            string destination = "../../../../files/copyMe-copy.png";

            using (FileStream readFile = new FileStream(source, FileMode.Open))
            {
                using (FileStream writeFile = new FileStream(destination, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    int byteCount = 1;

                    while (byteCount != 0)
                    {
                        byteCount = readFile.Read(buffer, 0, buffer.Length);
                        writeFile.Write(buffer, 0, byteCount);
                    }
                }
            }
        }
    }
}
