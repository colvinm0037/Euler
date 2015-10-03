using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_035 : IEulerProblem
    {
        private string _description = "The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime." +
            "\n\nThere are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97." +
            "\n\nHow many circular primes are there below one million?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 35; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            bool[] primes = UsefulFunctions.findPrimes(1000000);
            bool fullyPrime = false;
            int count = 1;
            for (int i = 3; i < 1000000; i = i + 2)
            {
                if (primes[i])
                {
                    string prime = Convert.ToString(i);
                    fullyPrime = true;
                    for (int k = 1; k < prime.Length; k++)
                    {
                        string rotated = prime.Substring(k, prime.Length - k) + prime.Substring(0, k);
                        int rotatedPrime = Convert.ToInt32(rotated);

                        if (!primes[rotatedPrime])
                        {
                            fullyPrime = false;
                            break;
                        }
                    }

                    if (fullyPrime)
                    {
                        Console.WriteLine(i + " Fully Prime!");
                        count++;
                    }
                }
            }
            return count.ToString();
        }
    }
}
