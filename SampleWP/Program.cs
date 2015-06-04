using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWP
{
    class Program
    {
        static void Main(string[] args)
        {
            WordProcessor wordProcessor = new WordProcessor();

            var sw = new Stopwatch();

            sw.Start();
            wordProcessor.DisplayWordsWithCount();
            sw.Stop();
            var one = sw.ElapsedMilliseconds;

            sw.Restart();
            wordProcessor.DisplayWordsWithCountDictionary();
            sw.Stop();
            var two = sw.ElapsedMilliseconds;

            Console.WriteLine(string.Format(" Time : DisplayWordsWithCount {0} DisplayWordsWithCountDictionary {1} ", one.ToString(), two.ToString()));

            Console.ReadKey();
        }
    }
}
