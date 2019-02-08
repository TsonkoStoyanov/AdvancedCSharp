using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace P06._Slicing_File
{
    class StartUp
    {
        private static List<string> files;

        static void Main(string[] args)
        {
            files = new List<string>();

            string sourceFile = "../../../../files/sliceMe.mp4";
            string destination = "../../../../files/";
            string assembled = "../../../../files/assembled.mp4";
            int parts = 4;

            Slice(sourceFile, destination, parts);
            Assemble(files, assembled);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                long totalLength = readFile.Length;

                byte[] buffer = new byte[totalLength / parts];

                for (int i = 0; i < parts; i++)
                {
                    int readedBytes = 0;

                    string destinationPath = destinationDirectory + $"sliceMe - part{i}.mp4";

                    files.Add(destinationPath);

                    using (FileStream writeFile = new FileStream(destinationPath, FileMode.Create))
                    {
                        int bytesCount = readFile.Read(buffer, 0, buffer.Length);

                        writeFile.Write(buffer, 0, buffer.Length);
                    }

                    using (GZipStream gz = new GZipStream(new FileStream(destinationPath + ".gz", FileMode.Create), CompressionMode.Compress, false))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            byte[] buffer = new byte[4096];

            using (FileStream writeFile = new FileStream(destinationDirectory, FileMode.Create))
            {

                foreach (var file in files)
                {
                    using (GZipStream readFile = new GZipStream(new FileStream(file+".gz", FileMode.Open), CompressionMode.Decompress))
                    {
                        while (true)
                        {
                            int bytesCount = readFile.Read(buffer, 0, buffer.Length);

                            if (bytesCount == 0)
                            {
                                break;
                            }
                            writeFile.Write(buffer, 0, bytesCount);
                        }

                    }
                }
            }
        }
    }
}
