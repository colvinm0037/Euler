using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_010
    {
        static void Main(string[] args)
        {
            // Find the sum of all the primes below two million.
            bool[] primes = findPrimes(2000000);
            long sum = 0;

            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static bool[] findPrimes(int number)
        {
            bool[] myArray = new bool[number];
            for (int i = 2; i < number; i++)
                myArray[i] = true;

            for (int k = 2; k < Math.Sqrt(number); k++)
            {
                if (myArray[k])
                {
                    for (int m = k * k; m < number; m += k)
                    {
                        myArray[m] = false;
                    }
                }
            }

            return myArray;
        }
    }
}
