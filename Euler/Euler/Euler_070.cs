using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_062
    {
        public List<int> primeValues = null;

        void Main()
        {
            // Find the value of n, 1 < n < 10^7, for which φ(n) is a permutation of n and the ratio n/φ(n) produces a minimum.

            // Takes 13 minutes to complete!

            double minRatio = 1000000;
            int finalN = 0;
            int n = (int)Math.Pow(10, 7);
            Console.WriteLine(n);

            bool[] primes = findPrimes(n);
            int[] phis = new int[n];

            primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList();

            for (int i = 3; i < n; i = i + 2)
            {

                int phi = 0;

                if (primes[i])
                {
                    phi = i - 1;
                }
                else
                {
                    phi = PhiOf(i);
                }

                var iChars = i.ToString().ToCharArray().OrderBy(c => c).ToList();
                var phiChars = phi.ToString().ToCharArray().OrderBy(c => c).ToList();

                bool isMatch = true;

                if (iChars.Count != phiChars.Count)
                    continue;

                for (int k = 0; k < iChars.Count; k++)
                {
                    if (iChars[k] != phiChars[k])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    double ratio = (double)i / phi;
                    if (ratio < minRatio)
                    {
                        minRatio = ratio;
                        finalN = i;
                        Console.WriteLine(i + ", " + minRatio + ", " + phi);
                    }
                }
            }

            Console.WriteLine("Final ratio: " + minRatio);
            Console.WriteLine("Final n: " + finalN);

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
