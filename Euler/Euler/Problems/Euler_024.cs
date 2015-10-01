using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_024 : IEulerProblem
    {
        private string _description = "A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:" +
            "\n\n012   021   102   120   201   210" +
            "\n\nWhat is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 24; }
        }

        public string Description
        {
            get { return _description; }
        }

        private int count = 0;
        private HashSet<string> numbers = new HashSet<string>();

        private string Main()
        {
            permutation(" ", "1234567890");
            List<string> sorted = numbers.OrderBy(x => x).ToList();
            return sorted[999999].ToString();
        }

        void permutation(String prefix, String str)
        {
            int n = str.Length;
            if (n == 0)
            {                
                numbers.Add(prefix);
                count++;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {                    
                    permutation(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1, n - i - 1));
                }
            }
        }        
    }
}
