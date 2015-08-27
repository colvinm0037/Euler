using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_027
    {
        void Main()
        {
            //	Considering quadratics of the form:
            //	n² + an + b, where |a| < 1000 and |b| < 1000
            //	where |n| is the modulus/absolute value of n
            //	e.g. |11| = 11 and |−4| = 4
            //	Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.

            int maxConsecutivePrimes = 0;
            int product = 0;
            bool[] primes = findPrimes(1000000);

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

            Console.WriteLine("Max Consecutive Primes: " + maxConsecutivePrimes);
            Console.WriteLine("Product of a and b: " + product)
        }

        bool[] findPrimes(long number)
        {
            bool[] myArray = new bool[number];
            for (long i = 2; i < number; i++)
                myArray[i] = true;

            for (int k = 2; k < Math.Sqrt(number); k++)
            {
                if (myArray[k])
                {
                    for (int m = k * k; m < number; m += k)
                        myArray[m] = false;
                }
            }

            return myArray;
        }
    }
}
