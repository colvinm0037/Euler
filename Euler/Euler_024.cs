using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_024
    {
        public int count = 0;
        public HashSet<string> numbers = new HashSet<string>();

        void Main()
        {
            permutation(" ", "1234567890");
            Console.WriteLine(count);
            List<string> sorted = numbers.OrderBy(x => x).ToList();
            Console.WriteLine(sorted.Last());
            Console.WriteLine(sorted[999999]);
        }

        void permutation(String prefix, String str)
        {
            int n = str.Length;
            if (n == 0)
            {
                //	Console.WriteLine (prefix);
                numbers.Add(prefix);
                count++;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    //string s = prefix + str[i];
                    //string k = str.Substring(0, i) + str.Substring(i+1, n - i - 1);
                    permutation(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1, n - i - 1));
                }
            }
        }
    }
}
