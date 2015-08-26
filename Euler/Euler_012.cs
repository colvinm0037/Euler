using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_012
    {
        void Main()
        {
            //What is the value of the first triangle number to have over five hundred divisors?

            for (int i = 1; i < 500000; i++)
            {
                long triangle = i * (i + 1) / 2;
                int factors = FindFactors(triangle);
                if (factors > 500)
                {
                    Console.WriteLine(i + ": " + triangle + ", factors: " + factors);
                    break;
                }

            }
        }

        int FindFactors(long triangle)
        {
            int factors = 0;
            for (int i = 1; i <= Math.Sqrt(triangle); i++)
            {
                if (triangle % i == 0)
                    factors += 2;
            }
            return factors;
        }

    }
}
