using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_069 : IEulerProblem
    {
        private List<int> primeValues = null;
        private string _description = "Euler's Totient function, φ(n) [sometimes called the phi function], is used to determine the number of numbers less than n which are relatively prime to n. For example, as 1, 2, 4, 5, 7, and 8, are all less than nine and relatively prime to nine, φ(9)=6." +
            "\n\nIt can be seen that n=6 produces a maximum n/φ(n) for n ≤ 10." +
            "\n\nFind the value of n ≤ 1,000,000 for which n/φ(n) is a maximum.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 69; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
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
                    //Console.WriteLine(n + ", " + coprimes + ", " + ratio);
                }
            }

            //Console.WriteLine("Ratio: " + maxRatio);
            //Console.WriteLine("n: " + finalN);
            return finalN.ToString();
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
