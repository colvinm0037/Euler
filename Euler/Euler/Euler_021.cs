using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_021 : IEulerProblem
    {
        private string _description = "Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n)." +
            "\nIf d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers." +
            "\nFor example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220." +
            "\nEvaluate the sum of all the amicable numbers under 10000.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 21; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            int sum = 0;

            for (int i = 1; i < 10000; i++)
            {
                int result = SumOfProperDivisors(i);
                int amicable = SumOfProperDivisors(result);
                if (i == amicable && result != amicable)
                {
                    sum += i;
                 //   Console.WriteLine("Adding: " + i + ", " + amicable + ", " + result);
                }
            }

            return sum.ToString();
        }

        private int SumOfProperDivisors(int number)
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
