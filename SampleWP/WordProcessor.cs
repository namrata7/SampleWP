using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWP
{
    public class WordProcessor
    {
        // get the words with count from string list
        public IEnumerable<IGrouping<string, string>> WordsWithCount(List<string> words)
        {
            return words.Cast<string>().GroupBy(w => w, StringComparer.CurrentCultureIgnoreCase);
        }

        public void DisplayWordsWithCount()
        {
            //TODO : read from file
            //TODO : Ignore punctuation
            var words = new List<string>() { "aaa", "bbb", "aaa", "ccc", "ddd", "bbb", "aaa" };

            var result = WordsWithCount(words);

            foreach (var word in result)
            {
                Console.WriteLine("{0} => {1}", word.Key, word.Count());
            }
        }
    }
}
