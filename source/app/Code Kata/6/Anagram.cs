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
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }

    }
}
