using Euler.Euler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_003 : IEulerProblem
    {
        private string _description = "The prime factors of 13195 are 5, 7, 13 and 29." + 
                        "\n\nWhat is the largest prime factor of the number 600851475143?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 3; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            long n = 600851475143;
            long sqrtOfN = Convert.ToInt32(Math.Sqrt(n));
         
            // Use sieve of eratosthenes to find every prime less than square root of n
            bool[] primes = UsefulFunctions.findPrimes(sqrtOfN);
            var primeValues = Enumerable.Range(0, (int)sqrtOfN).Where(i => primes[i]).ToList().OrderByDescending(x => x);

            // Start with greatest prime and search until first factor of n is found
            foreach (long prime in primeValues)
            {
                if (n % prime == 0)
                {
                    return prime.ToString();
                }
            }

            return "";
        }
    }
}
