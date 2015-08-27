using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_023 : IEulerProblem
    {
        private string _description = "A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number." +
            "\n\nA number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n." +
            "\n\nAs 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit." +
            "\n\nFind the sum of all the positive integers which cannot be written as the sum of two abundant numbers.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 23; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            // Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

            List<int> numbers = new List<int>();

            // Build list of all abundant numbers less than 28123
            for (int i = 1; i <= 28123; i++)
            {
                if (SumOfProperDivisors(i) > i)
                    numbers.Add(i);
            }

            // Build set of very possible pair from all Abundant numbers
            HashSet<int> allNumbers = new HashSet<int>();
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                for (int k = 0; k <= i; k++)
                {
                    allNumbers.Add(numbers[i] + numbers[k]);
                }
            }

            //Console.WriteLine(allNumbers.Count());
            //Console.WriteLine(numbers.Count());
            long total = 0;

            // Sum every number under 28123 that is not in pair set
            for (int i = 0; i < 28123; i++)
            {
                if (!allNumbers.Contains(i))
                {
                    //Console.WriteLine("adding " + i);
                    total += i;
                }
            }

            return total.ToString();
        }

        private static int SumOfProperDivisors(int number)
        {
            int sum = 0;

            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }      
    }
}
