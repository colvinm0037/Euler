using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_042
    {
        void Main()
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

            Console.WriteLine("Count: " + wordCount);
        }

        List<int> WordValues(List<string> words)
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

        List<int> FindTriangleNumbers(int number)
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
