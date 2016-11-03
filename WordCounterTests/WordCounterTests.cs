using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounterApp;
using System.IO;

namespace WordCounterTests
{
    [TestClass]
    public class WordCounterTests
    {
        [TestMethod]
        public void TestBaseCase()
        {
            StreamWriter writer = new StreamWriter("test.txt");
            writer.Write("Go do that thing that you do so well");
            writer.Close();

            WordCounter counter = new WordCounter();

            counter.CountWords("test.txt");

            Assert.AreEqual("1: Go\r\n2: do\r\n2: that\r\n1: thing\r\n1: you\r\n1: so\r\n1: well\r\n", counter.CountWords("test.txt"));

            Assert.AreEqual(7, counter.WordsDictionary.Count);
            Assert.AreEqual(1, counter.WordsDictionary["Go"]);
            Assert.AreEqual(2, counter.WordsDictionary["do"]);
            Assert.AreEqual(2, counter.WordsDictionary["that"]);
            Assert.AreEqual(1, counter.WordsDictionary["thing"]);
            Assert.AreEqual(1, counter.WordsDictionary["you"]);
            Assert.AreEqual(1, counter.WordsDictionary["so"]);
            Assert.AreEqual(1, counter.WordsDictionary["well"]);

            File.Delete("test.txt");
        }

        [TestMethod]
        public void HandlesPunctuation()
        {
            StreamWriter writer = new StreamWriter("test.txt");
            writer.Write("Go, do that thing that you do so well.");
            writer.Close();

            WordCounter counter = new WordCounter();

            Assert.AreEqual("1: Go\r\n2: do\r\n2: that\r\n1: thing\r\n1: you\r\n1: so\r\n1: well\r\n", counter.CountWords("test.txt"));

            Assert.AreEqual(7, counter.WordsDictionary.Count);
            Assert.AreEqual(1, counter.WordsDictionary["Go"]);
            Assert.AreEqual(2, counter.WordsDictionary["do"]);
            Assert.AreEqual(2, counter.WordsDictionary["that"]);
            Assert.AreEqual(1, counter.WordsDictionary["thing"]);
            Assert.AreEqual(1, counter.WordsDictionary["you"]);
            Assert.AreEqual(1, counter.WordsDictionary["so"]);
            Assert.AreEqual(1, counter.WordsDictionary["well"]);

            File.Delete("test.txt");
        }

        [TestMethod]
        public void FailsGracefully()
        {
            WordCounter counter = new WordCounter();

            Assert.AreEqual("Could not open the given file or the file contains no words", counter.CountWords("doesNotExist.txt"));
        }

    }

    
}
