using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Notes
{
    class Permutations
    {
        List<string> numbers = new List<string>();

        void Main()
        {
            String digits = "123456789";
            permutation("", digits);
            HashSet<int> pandigitalNumbers = new HashSet<int>();

            foreach (string s in numbers)
            {
                int three = Convert.ToInt32(s.Substring(0, 3));
                int two = Convert.ToInt32(s.Substring(3, 2));

                int one = Convert.ToInt32(s.Substring(0, 1));
                int four = Convert.ToInt32(s.Substring(1, 4));

                int total = Convert.ToInt32(s.Substring(5, 4));

                if (three * two == total || one * four == total)
                {
                    Console.WriteLine("ADDING: " + s);
                    pandigitalNumbers.Add(total);
                }
            }

            Console.WriteLine(pandigitalNumbers.Sum());
        }

        void permutation(String prefix, String str)
        {
            int n = str.Length;
            if (n == 0)
            {
                numbers.Add(prefix);
            }
            else
            {
                for (int i = 0; i < n; i++)
                    permutation(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1, n - i - 1));
            }
        }
    }
}
