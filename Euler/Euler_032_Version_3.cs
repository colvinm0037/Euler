using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_032_Version_3
    {
        List<string> numbers = new List<string>();

        void Main()
        {
            permutation("", "123456789");
            HashSet<int> pandigitalNumbers = new HashSet<int>();
            foreach (string s in numbers.AsParallel().Where(
                                       x => Convert.ToInt32(x.Substring(0, 3)) * Convert.ToInt32(x.Substring(3, 2)) == Convert.ToInt32(x.Substring(5, 4))
                                         || Convert.ToInt32(x.Substring(0, 1)) * Convert.ToInt32(x.Substring(1, 4)) == Convert.ToInt32(x.Substring(5, 4))))
                pandigitalNumbers.Add(Convert.ToInt32(s.Substring(5, 4)));
            Console.WriteLine(pandigitalNumbers.Sum());
        }

        void permutation(String prefix, String str)
        {
            if (str.Length == 0)
                numbers.Add(prefix);
            else
                for (int i = 0; i < str.Length; i++)
                    permutation(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1, str.Length - i - 1));
        }
    }
}
