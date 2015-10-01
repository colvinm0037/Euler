using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_037 : IEulerProblem
    {
        private string _description = "The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3." +
            "\n\nFind the sum of the only eleven primes that are both truncatable from left to right and right to left." +
            "\n\nNOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 37; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            bool[] primes = UsefulFunctions.findPrimes(1000000);
            bool fullyPrime = false;
            int sum = 0;
            for (int i = 9; i < 1000000; i = i + 2)
            {
                if (primes[i])
                {
                    string prime = Convert.ToString(i);
                    fullyPrime = true;

                    // truncate right to left
                    for (int k = 1; k < prime.Length; k++)
                    {
                        string rotated = prime.Substring(0, prime.Length - k);
                        int rotatedPrime = Convert.ToInt32(rotated);

                        if (!primes[rotatedPrime])
                        {
                            fullyPrime = false;
                            break;
                        }
                    }

                    if (fullyPrime)
                    {
                        // truncate left to right
                        for (int k = 1; k < prime.Length; k++)
                        {
                            string rotated = prime.Substring(k, prime.Length - k);
                            int rotatedPrime = Convert.ToInt32(rotated);

                            if (!primes[rotatedPrime])
                            {
                                fullyPrime = false;
                                break;
                            }
                        }
                    }
                    if (fullyPrime)
                    {
                        sum += i;
                    }
                }
            }
            return sum.ToString();
        }
    }
}
