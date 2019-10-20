using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwitchScript
{
    class Program
    {
        static List<string> CSV = new List<string>();
        static void Main(string[] args)
        {
            var csvs = Directory.GetFiles("CSV\\Attack\\", "*.csv");
            foreach(var file in csvs)
            {
                if (File.Exists(file.Replace(".csv", ".txt")))
                {
                    CSV.Add(file);
                }
            }
            int x = 0;
            do
            {
                Console.WriteLine("Changing Script Drop Points for " + x + " times");
                foreach (var file in CSV)
                {
                    string[] original, temp;
                    original = File.ReadAllLines(file);
                    temp = File.ReadAllLines(file.Replace(",csv", ".txt"));
                    File.WriteAllLines(file, temp);
                    File.WriteAllLines(file.Replace(".csv", ".txt"), original);
                    Console.WriteLine("Swaping " + file.Remove(0,file.LastIndexOf('\\')).Replace(".csv", ""));
                }
                x++;
                Thread.Sleep(new TimeSpan(1,0,0));
            }
            while (true);
        }
    }
}
