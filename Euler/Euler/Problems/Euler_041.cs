using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_041 : IEulerProblem
    {
        private List<long> numbers = new List<long>();
        private string _description = "We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime." +
            "\n\nWhat is the largest n-digit pandigital prime that exists?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 41; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            string result = "";
            permutation("", "1234567");
            foreach (long number in numbers.OrderByDescending(x => x))
            {
                if (UsefulFunctions.IsPrime(number))
                {
                    result = number.ToString();
                    break;
                }
            }
            return result;
        }

        private void permutation(String prefix, String str)
        {
            int n = str.Length;
            if (n == 0)
            {
                numbers.Add(Convert.ToInt64(prefix));
            }
            else
            {
                for (int i = 0; i < n; i++)
                    permutation(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1, n - i - 1));
            }
        }
    }
}
