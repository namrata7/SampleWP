using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWP
{
    public class WordProcessor
    {
        public void DisplayWordsWithCount()
        {
            var words = GetFileContents("book.txt");

            var result = WordsWithCount(words);

            foreach (var word in result)
            {
                Console.WriteLine("{0} => {1}", word.Key, word.Count());
            }
        }

        public List<string> GetFileContents(string fileName)
        {
            var wordsString = File.ReadAllText(fileName);

            // Ignore punctuation
            string[] stripPunctuations = { "\n", "\t", "\r", ";", ",", ".", "-", "_", "^", "(", ")", "[", "]"};
            foreach (string pChar in stripPunctuations)
            {
                wordsString = wordsString.Replace(pChar, " ");
            }

            // get the word list
            return wordsString.Split(' ').ToList();
        }

        // get the words with count from string list
        public IEnumerable<IGrouping<string, string>> WordsWithCount(List<string> words)
        {
            return words.Cast<string>().GroupBy(w => w, StringComparer.CurrentCultureIgnoreCase);
        }
    }
}
