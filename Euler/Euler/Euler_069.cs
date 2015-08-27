using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_069
    {
        public List<int> primeValues = null;

        void Main()
        {
            // Find the value of n ≤ 1,000,000 for which n/φ(n) is a maximum.

            // Find the prime factorization of each number

            // Answer is actually just 2*3*5*7*11*13*17	

            int m = 1000000;
            double maxRatio = 0;
            int finalN = 0;
            bool[] primes = findPrimes(m);
            primeValues = Enumerable.Range(0, (int)m).Where(i => primes[i]).ToList();

            for (int n = 2; n < m; n = n + 2)
            {
                int coprimes = PhiOf(n);
                double ratio = (double)n / coprimes;

                if (ratio > maxRatio)
                {
                    maxRatio = ratio;
                    finalN = n;
                    Console.WriteLine(n + ", " + coprimes + ", " + ratio);
                }
            }

            Console.WriteLine("Ratio: " + maxRatio);
            Console.WriteLine("n: " + finalN);
        }

        int PhiOf(int number)
        {
            double phi = number;
            HashSet<int> factors = PrimeFactors(number);
            foreach (int factor in factors)
            {
                phi *= (1.0 - (1.0 / factor));
            }
            return (int)phi;
        }

        HashSet<int> PrimeFactors(int number)
        {
            HashSet<int> factors = new HashSet<int>();
            int index = 0;

            while (number > 1)
            {
                if (number % primeValues[index] == 0)
                {
                    number = (int)number / primeValues[index];
                    factors.Add(primeValues[index]);
                }
                else
                {
                    index++;
                }
            }

            return factors;
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
