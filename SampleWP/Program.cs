using System;
using System.Collections.Generic;
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
            wordProcessor.DisplayWordsWithCount();

            Console.ReadKey();
        }
    }
}
