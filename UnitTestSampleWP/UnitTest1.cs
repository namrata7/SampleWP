using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SampleWP;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSampleWP
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ResultNotEmpty()
        {
            WordProcessor wordProcessor = new WordProcessor();
            List<string> list = new List<string>() { "aaa" };
            var result = wordProcessor.WordsWithCount(list);
            Assert.IsNotNull(result, "Result Empty");
        }

        [TestMethod]
        public void SingleStringReturns1()
        {
            WordProcessor wordProcessor = new WordProcessor();
            List<string> list = new List<string>() { "aaa" };
            var result = wordProcessor.WordsWithCount(list);
            foreach (var word in result)
            {
                Assert.AreEqual<int>(1, word.Count(), "Single String does not returns count 1");
            }
        }

        [TestMethod]
        public void ThreeTimesReturns3()
        {
            WordProcessor wordProcessor = new WordProcessor();
            List<string> list = new List<string>() { "aaa", "bbb", "aaa", "ccc", "ddd", "bbb", "aaa" };
            IEnumerable<IGrouping<string, string>> result = wordProcessor.WordsWithCount(list);
            var actual = result.Where(w => w.Key == "aaa").FirstOrDefault().Count();
            Assert.AreEqual<int>(3, actual, "Three times does not returns count 3");
        }

        [TestMethod]
        public void GetFileReturnsData()
        {
            WordProcessor wordProcessor = new WordProcessor();
            var actual = wordProcessor.GetFileContents("book_test.txt");
            Assert.IsNotNull(actual, "File not read");
        }

        [TestMethod]
        public void ThreeTimesFromFileReturns3()
        {
            WordProcessor wordProcessor = new WordProcessor();
            List<string> list = wordProcessor.GetFileContents("book_test.txt");
            IEnumerable<IGrouping<string, string>> result = wordProcessor.WordsWithCount(list);
            var actual = result.Where(w => w.Key == "aaa").FirstOrDefault().Count();
            Assert.AreEqual<int>(3, actual, "Three times from file does not returns count 3");
        }
    }
}
