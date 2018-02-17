using System;
using System.Collections.Generic;
using System.IO;

namespace _05.SlicingFile
{
    class SliceFile
    {
        static void Main()
        {
            string sourceFile = "../Resources/sliceMe.mp4";
            string destination = "";
            int parts = 5;

            Slice(sourceFile, destination, parts);

            var files = new List<string>
            {
                "Part - 0.mp4",
                "Part - 1.mp4",
                "Part - 2.mp4",
                "Part - 3.mp4",
                "Part - 4.mp4",
            };

            Assemble(files, destination);
        }
        static void Slice(string sourceFile, string destination, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));

                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long curentPieceSize = 0;

                    if (destination == String.Empty)
                    {
                        destination = "./";
                    }
                    string currentPart = destination + $"Part - {i}{extension}";
                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                            curentPieceSize += 4096;
                            if (curentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        static void Assemble(List<string> files, string destination)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.'));

            if (destination == String.Empty)
            {
                destination = "./";
            }
            if (!destination.EndsWith("/"))
            {
                destination += "/";
            }
            string assembledFile = $"{destination}Assembled{extension}";

            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
