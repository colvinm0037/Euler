using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_043 : IEulerProblem
    {
        private List<long> numbers = new List<long>();
        private int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17 };
        private string _description = "The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property." + 
            "\n\nLet d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:" + 
            "\n\nd2d3d4=406 is divisible by 2" + 
            "\nd3d4d5=063 is divisible by 3" + 
            "\nd4d5d6=635 is divisible by 5" + 
            "\nd5d6d7=357 is divisible by 7" + 
            "\nd6d7d8=572 is divisible by 11" + 
            "\nd7d8d9=728 is divisible by 13" +
            "\nd8d9d10=289 is divisible by 17" + 
            "\nFind the sum of all 0 to 9 pandigital numbers with this property.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 43; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            long sum = 0;
            permutation("", "0123456789");

            foreach (long number in numbers.OrderByDescending(x => x))
            {
                if (HasSpecialProperty(number))
                {
                    Console.WriteLine("Special: " + number);
                    sum += number;
                }
            }

            return sum.ToString();
        }

        private bool HasSpecialProperty(long number)
        {
            // There is an issue with numbers starting with zero
            // If we just ignore anything starting with zero then
            // we get the correct answer.	
            if (number < 1000000000)
                return false;

            for (int i = 0; i < 7; i++)
            {
                string substring = number.ToString().Substring((1 + i), 3);
                int value = Convert.ToInt32(substring);

                if (value % primes[i] != 0)
                    return false;
            }

            return true;
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
