using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_027 : IEulerProblem
    {
        private string _description = "Euler discovered the remarkable quadratic formula:" + 
            "\nn² + n + 41" + 
            "\nIt turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41." + 
            "\nThe incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. The product of the coefficients, −79 and 1601, is −126479." + 
            "\n\nConsidering quadratics of the form:" + 
            "\nn² + an + b, where |a| < 1000 and |b| < 1000" + 
            "\nwhere |n| is the modulus/absolute value of n" +
            "\ne.g. |11| = 11 and |−4| = 4" + 
            "\n\nFind the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 27; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            int maxConsecutivePrimes = 0;
            int product = 0;
            bool[] primes = UsefulFunctions.findPrimes(1000000);

            for (int a = -1000; a <= 1000; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    // n^2 + an + b
                    int consecutivePrimes = 0;
                    int n = 1;
                    while (true)
                    {
                        int potentialPrime = n * n + a * n + b;
                        if (potentialPrime < 0)
                            break;

                        if (primes[potentialPrime])
                        {
                            consecutivePrimes++;
                            n++;
                        }
                        else
                            break;
                    }

                    if (consecutivePrimes > maxConsecutivePrimes)
                    {
                        maxConsecutivePrimes = consecutivePrimes;
                        product = a * b;
                    }
                }
            }

            return product.ToString();
        }
    }
}
