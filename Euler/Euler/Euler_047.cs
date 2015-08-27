using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_047
    {
        List<int> primeValues = new List<int>();

        void Main()
        {
            //The first two consecutive numbers to have two distinct prime factors are:
            //
            //14 = 2 × 7
            //15 = 3 × 5
            //
            //The first three consecutive numbers to have three distinct prime factors are:
            //
            //644 = 2² × 7 × 23
            //645 = 3 × 5 × 43
            //646 = 2 × 17 × 19.
            //
            //Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?

            long n = 250000;
            int factors = 4;

            bool[] primes = findPrimes(n); // bool array of what numbers are prime up to n
            primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList(); // list of all primes less than n

            int count = 0;

            for (long i = 100; i <= n; i++)
            {
                if (HasUniquePrimeFactors(i, factors))
                {
                    count++;

                    if (count == factors)
                    {
                        Console.WriteLine("Found: " + (i - (factors - 1)));
                        break;
                    }
                }
                else
                    count = 0;
            }
        }

        bool HasUniquePrimeFactors(long prime, int factors)
        {
            long currentValue = prime;
            int distinctPrimes = 0;

            foreach (int primeValue in primeValues)
            {
                bool isCounted = false;
                while (currentValue % primeValue == 0)
                {
                    if (!isCounted)
                    {
                        distinctPrimes++;
                        isCounted = true;
                    }
                    currentValue = currentValue / primeValue;
                    if (currentValue == 1)
                        break;

                }
            }

            return distinctPrimes == factors;
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
