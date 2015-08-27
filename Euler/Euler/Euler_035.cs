using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_035
    {
        void Main()
        {
            // How many circular primes are there below one million?

            bool[] primes = findPrimes(1000000);
            bool fullyPrime = false;
            int count = 0;
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
            Console.WriteLine("Count: " + count);
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
