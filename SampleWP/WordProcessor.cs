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
        #region Display methods

        // Display return values from LINQ 
        public void DisplayWordsWithCount()
        {
            var words = GetFileContents("book.txt");
            Dictionary<int, bool> primeNumbers = new Dictionary<int, bool>();

            var result = WordsWithCount(words);
            foreach (var word in result)
            {
                if(!string.IsNullOrEmpty(word.Key.Trim()))
                {
                    var wordCount = word.Count();
                    Console.WriteLine("{0} => {1} {2}", word.Key, wordCount, GetPrimeText(wordCount, primeNumbers));
                }
            }
        }

        // Display return values from dictionary
        public void DisplayWordsWithCountDictionary()
        {
            var words = GetFileContents("book.txt");
            Dictionary<int, bool> primeNumbers = new Dictionary<int, bool>();

            var result = WordsWithCountDictionary(words);

            foreach (KeyValuePair<string, int> pair in result)
            {
                Console.WriteLine("{0} => {1} {2}", pair.Key, pair.Value, GetPrimeText(pair.Value, primeNumbers));
            }
        }
        #endregion Display methods

        /// <summary>
        /// Read the file contents and splits it into words list after sripping punctuations
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// get the words with count from string list
        /// Uses LINQ - very simple to write and maintain but bit slower
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, string>> WordsWithCount(List<string> words)
        {
            return words.Cast<string>().GroupBy(w => w, StringComparer.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// get the words with count from string list
        /// Uses Dictionary and iterations - faster compare to LINQ
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public Dictionary<string, int> WordsWithCountDictionary(List<string> words)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (string word in words)
            {
                // check if the dictionary already has the word.
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary[word] = 1;
                }
            }
            return dictionary;
        }


        /// <summary>
        /// Returns the text Prime if number is prime number
        /// If the number is already checked for prime then reads from dictionary
        /// </summary>
        /// <param name="number"></param>
        /// <param name="primeNumbers"></param>
        /// <returns></returns>
        public string GetPrimeText(int number, Dictionary<int, bool> primeNumbers)
        {
            bool isPrime;
            if (primeNumbers.ContainsKey(number))
            {
                isPrime = primeNumbers[number];
            }
            else
            {
                isPrime = IsPrimeNumber(number);
                primeNumbers.Add(number, isPrime);
            }

            return isPrime ? "[Prime]" : "";
        }

        /// <summary>
        /// Returns true if number is prime number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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
