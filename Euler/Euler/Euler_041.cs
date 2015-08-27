using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_041
    {
        List<long> numbers = new List<long>();

        void Main()
        {
            // We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
            // What is the largest n-digit pandigital prime that exists?

            permutation("", "1234567");
            foreach (long number in numbers.OrderByDescending(x => x))
            {
                if (IsPrime(number))
                {
                    Console.WriteLine("Prime: " + number);
                    break;
                }
            }
        }

        void permutation(String prefix, String str)
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

        bool IsPrime(long number)
        {
            if (number % 2 == 0)
                return false;

            for (int i = 3; i < number / 2; i = i + 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
