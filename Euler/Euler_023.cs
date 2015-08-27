using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_023
    {
        void Main()
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

            Console.WriteLine(allNumbers.Count());
            Console.WriteLine(numbers.Count());
            long total = 0;

            // Sum every number under 28123 that is not in pair set
            for (int i = 0; i < 28123; i++)
            {
                if (!allNumbers.Contains(i))
                {
                    Console.WriteLine("adding " + i);
                    total += i;
                }
            }

            Console.WriteLine("Total: " + total);
        }

        int SumOfProperDivisors(int number)
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
