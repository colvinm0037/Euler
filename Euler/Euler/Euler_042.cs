using Euler.Euler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_042 : IEulerProblem
    {
        private string _description = "The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:" + 
            "\n\n1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ..." +
            "\n\nBy converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall call the word a triangle word." + 
            "\n\nUsing words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common English words, how many are triangle words?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 42; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            // How many words in the list are triangle words?

            string line = null;
            List<String> words = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\COLVINM\\Documents\\LINQPad Queries\\p042_words.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        words = line.Split(',').ToList();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            int longestWordLength = (words.OrderBy(x => x.Length).Last().Length);

            List<int> triangles = FindTriangleNumbers(longestWordLength * 26);
            List<int> wordValues = WordValues(words);

            int wordCount = 0;
            foreach (int value in wordValues)
            {
                if (triangles.Contains(value))
                    wordCount++;
            }

            return wordCount.ToString();
        }

        private static List<int> WordValues(List<string> words)
        {
            char[] letters = new char[] { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            List<int> values = new List<int>();

            foreach (string s in words)
            {
                int wordValue = 0;
                foreach (char c in s)
                {
                    if (c == '"')
                        continue;

                    wordValue += Array.IndexOf(letters, c);
                }
                values.Add(wordValue);
            }

            return values;
        }

        private static List<int> FindTriangleNumbers(int number)
        {
            List<int> triangles = new List<int>();
            int i = 1;

            while (true)
            {
                int triangle = (int)((i) * (i + 1)) / 2;
                triangles.Add(triangle);
                if (triangle >= number)
                    break;
                i++;
            }

            return triangles;
        }        
    }
}
