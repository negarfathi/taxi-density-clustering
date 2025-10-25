using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sampling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dest = @"C:\Users\hamed\Desktop\sample.txt";
            var folderPath = @"C:\Users\hamed\Desktop\T-drive Taxi Trajectories\release\taxi_log_2008_by_id";
            var allFiles = Directory.GetFiles(folderPath);
            var allData = new List<string>();
            foreach (var file in allFiles.Take(500))
            {
                var lines = File.ReadAllLines(file);
                var length = lines.Length;
                int percent = Convert.ToInt32(0.01 * length);
                lines.Shuffle();
                var newList = lines.Take(percent).ToList();
                allData.AddRange(newList);
                Console.WriteLine(Path.GetFileNameWithoutExtension(file));
            }
            allData.Shuffle();
            File.WriteAllLines(dest, allData);
        }
    }
}
