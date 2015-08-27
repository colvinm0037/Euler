using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_050
    {
        void Main()
        {
            // The prime 41, can be written as the sum of six consecutive primes:
            // 41 = 2 + 3 + 5 + 7 + 11 + 13
            // This is the longest sum of consecutive primes that adds to a prime below one-hundred.

            // The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
            // Which prime, below one-million, can be written as the sum of the most consecutive primes?

            int n = 1000000;
            int maxTerms = 1;
            int finalPrime = 0;

            bool[] primes = findPrimes(n);
            var primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList();

            foreach (int prime in primeValues)
            {
                Console.WriteLine(prime);

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

            Console.WriteLine("Prime number: " + finalPrime);
            Console.WriteLine("Consecutive Terms: " + maxTerms);
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
