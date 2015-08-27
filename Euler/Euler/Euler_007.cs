using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_007 : EulerProblem
    {
        private string _description = "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.\n\nWhat is the 10 001st prime number?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 7; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            // Count 2 right away
            int primeCount = 1;

            int i = 1;
            while (true)
            {
                i += 2;

                if (isPrime(i))
                {
                    primeCount++;
                    if (primeCount == 10001)
                    {
                        break;
                    }
                }
            }

            // Console.WriteLine(primeCount);
            // Console.WriteLine(i);
            return i.ToString();
        }

        private static bool isPrime(int number)
        {
            for (int i = 2; i < number / 2; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }        
    }
}
