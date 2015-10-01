using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_047 : IEulerProblem
    {
        private List<int> primeValues = new List<int>();
        private string _description = "The first two consecutive numbers to have two distinct prime factors are:" +           
           "\n\n14 = 2 × 7" +
           "\n15 = 3 × 5" +           
           "\n\nThe first three consecutive numbers to have three distinct prime factors are:" +           
           "\n\n644 = 2² × 7 × 23" +
           "\n645 = 3 × 5 × 43" +
           "\n646 = 2 × 17 × 19." +           
           "\n\nFind the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 47; }
        }

        public string Description
        {
            get { return _description; }
        }

        String Main()
        {            
            long n = 250000;
            int factors = 4;

            bool[] primes = UsefulFunctions.findPrimes(n); // bool array of what numbers are prime up to n
            primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList(); // list of all primes less than n

            int count = 0;

            for (long i = 100; i <= n; i++)
            {
                if (HasUniquePrimeFactors(i, factors))
                {
                    count++;

                    if (count == factors)
                    {
                        
                        return (i - (factors - 1)).ToString();                        
                    }
                }
                else
                {
                    count = 0;
                }
            }
            return "";
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
    }
}
