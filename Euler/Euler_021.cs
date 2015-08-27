using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_021
    {
        void Main()
        {
            int sum = 0;

            for (int i = 1; i < 10000; i++)
            {
                int result = SumOfProperDivisors(i);
                int amicable = SumOfProperDivisors(result);
                if (i == amicable && result != amicable)
                {
                    sum += i;
                    Console.WriteLine("Adding: " + i + ", " + amicable + ", " + result);
                }
            }

            Console.WriteLine("Sum: " + sum);
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
