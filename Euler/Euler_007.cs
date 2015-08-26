using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_007
    {
        void Main()
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

            Console.WriteLine(primeCount);
            Console.WriteLine(i);
        }

        bool isPrime(int number)
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
