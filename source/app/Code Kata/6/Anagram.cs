using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace app.Code_Kata._6
{
    public class Anagram
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"c:\Words.txt");
            var dictionary = File.ReadAllLines(@"c:\dictionary.txt");
            foreach (var line in lines)
            {
                var cleanLine = line.Replace(" ", "");
                foreach (var dLine in dictionary)
                {
                    while(fin)
                }
            }
            Console.ReadLine();
        }
        private bool findMatch(char character, int currentIndex, string dictionaryWord)
        {
            if (dictionaryWord[currentIndex] == character)
                return true;
            return false;
        }
        string[][] allPossibleMatches (string[] word)
    }
}
