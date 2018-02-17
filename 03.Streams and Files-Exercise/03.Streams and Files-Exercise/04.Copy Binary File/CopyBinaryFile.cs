using System;
using System.IO;

namespace _04.Copy_Binary_File
{
    class CopyBinaryFile
    {
        static void Main()
        {
            using (var source = new FileStream("../Resources/copyMe.png", FileMode.Open))
            {
                using (var destination =
                    new FileStream("copyMeCopy.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                            break;
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
