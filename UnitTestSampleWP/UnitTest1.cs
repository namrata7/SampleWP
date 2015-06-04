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
    }
}
