using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_032_Version_3 : IEulerProblem
    {
        private List<string> numbers = new List<string>();
        private string _description = "We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital." + 
            "\n\nThe product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital." +
            "\n\nFind the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital." + 
            "\n\nHINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 32; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            permutation("", "123456789");
            HashSet<int> pandigitalNumbers = new HashSet<int>();
            foreach (string s in numbers.AsParallel().Where(
                                       x => Convert.ToInt32(x.Substring(0, 3)) * Convert.ToInt32(x.Substring(3, 2)) == Convert.ToInt32(x.Substring(5, 4))
                                         || Convert.ToInt32(x.Substring(0, 1)) * Convert.ToInt32(x.Substring(1, 4)) == Convert.ToInt32(x.Substring(5, 4))))
                pandigitalNumbers.Add(Convert.ToInt32(s.Substring(5, 4)));
            return pandigitalNumbers.Sum().ToString();
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
