using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            var filesDictonary = new Dictionary<string, List<FileInfo>>();
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!filesDictonary.ContainsKey(extension))
                {
                    filesDictonary[extension] = new List<FileInfo>();
                }
                filesDictonary[extension].Add(fileInfo);
            }
            filesDictonary = filesDictonary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fileName))
            {
                foreach (var pair in filesDictonary)
                {
                    string extension = pair.Key;

                    writer.WriteLine(extension);

                    var fileInfos = pair.Value.OrderByDescending(x=>x.Length);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024; 
                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }

        }
    }
}
