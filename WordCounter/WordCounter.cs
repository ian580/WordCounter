using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WordCounterApp
{
    public class WordCounter
    {
        public Dictionary<string, int> WordsDictionary { get; private set; }

        /// <summary>
        /// Initializes a new instance of WordCounter
        /// </summary>
        public WordCounter()
        {
            WordsDictionary = new Dictionary<string, int>();
        }

        /// <summary>
        /// Counts the unique words in the given file
        /// </summary>
        /// <param name="filePath">The full path to the file to read</param>
        /// <returns>A string with each unique word in the file and its count</returns>
        public string CountWords(string filePath)
        {
            if (File.Exists(filePath))
            {
                WordsDictionary.Clear();

                // Read the contents of the file
                StreamReader reader = new StreamReader(filePath);
                string contents = reader.ReadToEnd();
                reader.Close();

                // Remove any punctuation from the text and split into words
                var punctuation = contents.Where(Char.IsPunctuation).Distinct().ToArray();
                var words = contents.Split().Select(x => x.Trim(punctuation));

                // Loop through words and count the unique words
                foreach (string word in words)
                {
                    if (WordsDictionary.ContainsKey(word))
                    {
                        WordsDictionary[word]++;
                    }
                    else
                    {
                        WordsDictionary[word] = 1;
                    }
                }

            }
            return GetResult();
        }

        

        /// <summary>
        /// Get a formatted string with the unique words and their count
        /// </summary>
        /// <returns>Formatted string with unique words and their count</returns>
        private string GetResult()
        {
            StringBuilder result = new StringBuilder();
            if (WordsDictionary.Keys.Count > 0)
            {
                foreach (var word in WordsDictionary)
                {
                    result.Append(word.Value + ": " + word.Key + "\r\n");
                }
            }
            else
            {
                result.Append("Could not open the given file or the file contains no words");
            }

            return result.ToString();
        }
    }
}
