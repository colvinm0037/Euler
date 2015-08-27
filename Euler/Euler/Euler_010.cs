using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_010 : IEulerProblem
    {
        private string _description = "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.\n\nFind the sum of all the primes below two million.";
        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 10; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
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

            return sum.ToString();
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
