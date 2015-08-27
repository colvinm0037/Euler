using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Notes
{
    class Primes
    {
        void Main()
        {
            // Sieve of Eratosthenes
            bool[] primes = findPrimes(100);
        }

        bool[] findPrimes(int number)
        {
            bool[] myArray = new bool[number];
            for (int i = 2; i < number; i++)
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
