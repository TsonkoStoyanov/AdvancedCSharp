using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _06.Zipping_Sliced_Files
{
    class ZippingSlicedFiles
    {
        static void Main()
        {
            string sourceFile = "../Resources/sliceMe.mp4";
            string destination = "";
            int parts = 5;
            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));


            Slice(sourceFile, destination, parts, extension);

            var files = new List<string>
            {
                "Part - 0.mp4.gz",
                "Part - 1.mp4.gz",
                "Part - 2.mp4.gz",
                "Part - 3.mp4.gz",
                "Part - 4.mp4.gz",
            };

            Assemble(files, destination, extension);
        }
        static void Slice(string sourceFile, string destination, int parts, string extension)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {

                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long curentPieceSize = 0;

                    if (destination == String.Empty)
                    {
                        destination = "./";
                    }
                    string currentPart = destination + $"Part - {i}{extension}.gz";
                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
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
        static void Assemble(List<string> files, string destination, string extension)
        {
            
            string fileOutputPath = destination + "assembled"  + extension;

            if (destination == String.Empty)
            {
                destination = "./";
            }
            if (!destination.EndsWith("/"))
            {
                destination += "/";
            }

            var fsSource = new FileStream(fileOutputPath, FileMode.Create);

            fsSource.Close();
            using (fsSource = new FileStream(fileOutputPath, FileMode.Append))
            {
                foreach (var file in files)
                {
                    using (var partSource = new FileStream(file, FileMode.Open))
                    {
                        using (var compressionStream = new GZipStream(partSource, CompressionMode.Decompress, false))
                        {
                            Byte[] bytePart = new byte[4096];
                            while (true)
                            {
                                int readBytes = compressionStream.Read(bytePart, 0, bytePart.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }

                                fsSource.Write(bytePart, 0, readBytes);
                            }
                        }
                    }
                }
            }
        }

    }
}

