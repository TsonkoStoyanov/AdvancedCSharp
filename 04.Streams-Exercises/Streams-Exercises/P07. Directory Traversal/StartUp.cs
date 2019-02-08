using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P07._Directory_Traversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string source = "../../../../files/";

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//report.txt";

            var info = new Dictionary<string, Dictionary<string, decimal>>();

            string[] files = Directory.GetFiles(source, "*.*", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                var currentFile = File.Open(file, FileMode.Open);

                var fullName = Path.GetFileName(file);
                var extension = Path.GetExtension(file);
                var fileSize = Decimal.Divide(currentFile.Length, 1024);

                if (!info.ContainsKey(extension))
                {
                    info.Add(extension, new Dictionary<string, decimal>());
                }

                if (!info[extension].ContainsKey(fullName))
                {
                    info[extension].Add(fullName, fileSize);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (var kvp in info.OrderByDescending(x=>x.Value.Count).ThenBy(k=>k.Key))
                {
                    streamWriter.WriteLine($".{kvp.Key}");

                    foreach (var fileInfo in kvp.Value.OrderBy(x=>x.Value))
                    {
                        streamWriter.WriteLine($"--{fileInfo.Key} - {fileInfo.Value:f2}kb");

                    }
                }
            }
        }
    }
}
