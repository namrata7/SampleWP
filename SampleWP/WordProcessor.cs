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
                if(!string.IsNullOrEmpty(word.Key.Trim()))
                {
                    var wordCount = word.Count();
                    Console.WriteLine("{0} => {1} {2}", word.Key, wordCount, IsPrimeNumber(wordCount) ? "[Prime]" : "");
                }
            }
        }

        public List<string> GetFileContents(string fileName)
        {
            var wordsString = File.ReadAllText(fileName);

            // Ignore punctuation
            string[] stripPunctuations = { "\n", "\t", "\r", "\"", "!", "?", ":", ";", ",", ".", "-", "_", "^", "(", ")", "[", "]" };
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

        public bool IsPrimeNumber(int number)
        {
            // Test whether the parameter is a prime number.
            if ((number & 1) == 0)
            {
                if (number == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 3; (i * i) <= number; i += 2)
            {
                if ((number % i) == 0)
                {
                    return false;
                }
            }
            return number != 1;
        }
    }
}
