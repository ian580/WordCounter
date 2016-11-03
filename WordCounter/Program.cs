using System;

namespace WordCounterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            WordCounter counter = new WordCounter();
            Console.WriteLine(counter.CountWords(filePath));
            Console.ReadLine();
        }
    }
}
