using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_053
    {
        void Main()
        {
            // nCr =	n! / r!(n−r)!, where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.
            // It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.	
            // How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?

            int count = 0;

            for (int n = 1; n <= 100; n++)
            {
                for (int r = 1; r <= n; r++)
                {
                    BigInteger amount = (Factorial(n)) / ((Factorial(r)) * (Factorial(n - r)));
                    if (amount > 1000000)
                    {
                        Console.WriteLine(n + ", " + r + ", " + amount);
                        count++;
                    }
                }
            }

            Console.WriteLine("Count: " + count);
        }

        BigInteger Factorial(BigInteger number)
        {
            if (number <= 1)
                return BigInteger.One;
            else
                return number * Factorial(number - 1);
        }
    }
}
