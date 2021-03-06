﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_521
    {
        void Main()
        {
            // 3461543 
            long num = (long)Math.Pow(10, 12);
            long mod = (long)Math.Pow(10, 9);

            Console.WriteLine(num);
            Console.WriteLine(mod);
            long n = 20000000;
            long sum = 0;

            // 3  5,7  9  11,13  15  17,19  21 
            //5 15 25 35 45 

            bool[] primes = findPrimes(n);
            var primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList();

            int count = 2;

            for (int k = 3; k <= n; k = k + 2)
            {
                if (count == 2)
                {
                    sum += 3;
                    count = 0;
                    //	Console.WriteLine (k);
                    continue;
                }
                count++;

                if (primes[k])
                    sum += k;
                else
                    sum += primeValues.First(i => k % i == 0);
                if (sum > mod)
                    sum = sum % mod;
            }
            sum += n;
            Console.WriteLine("Sum of first prime factor of every number between 2 and " + n);
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
