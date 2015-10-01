using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_050 : IEulerProblem
    {
        // TODO: This problem takes too long to run.

        private string _description = "The prime 41, can be written as the sum of six consecutive primes:" +
                   "\n41 = 2 + 3 + 5 + 7 + 11 + 13" +
                   "\nThis is the longest sum of consecutive primes that adds to a prime below one-hundred." +
                 "\n\nThe longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953." +
                   "\nWhich prime, below one-million, can be written as the sum of the most consecutive primes?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 50; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            int n = 1000000;
            int maxTerms = 1;
            int finalPrime = 0;

            bool[] primes = UsefulFunctions.findPrimes(n);
            var primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList();

            foreach (int prime in primeValues)
            {
            
                var subPrimes = primeValues.Where(p => p <= prime).ToList();
                foreach (int startingPrime in subPrimes)
                {
                    int count = 0;
                    int sum = 0;
                    bool isMatch = false;

                    if (startingPrime >= prime / maxTerms)
                        break;

                    for (int start = primeValues.IndexOf(startingPrime); start < subPrimes.Count(); start++)
                    {
                        sum += subPrimes[start];
                        count++;

                        if (sum < prime)
                            continue;

                        if (sum == prime)
                        {
                            isMatch = true;
                            break;
                        }

                        if (sum > prime)
                            break;
                    }

                    if (isMatch && count > maxTerms)
                    {
                        maxTerms = count;
                        finalPrime = prime;
                    }
                }
            }

            return finalPrime.ToString();
        }
    }
}
