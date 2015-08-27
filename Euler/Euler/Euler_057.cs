using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_057
    {
        void Main()
        {
            //	1 + 1/2 = 3/2 = 1.5
            //	1 + 1/(2 + 1/2) = 7/5 = 1.4
            //	1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
            //	1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...

            // The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example 
            // where the number of digits in the numerator exceeds the number of digits in the denominator.
            // In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?

            // 1, 1, 3, 7, 17, 41, 99, 239
            // 1, 1, 2, 5, 12, 29, 70, 169, 

            BigInteger count = 0;

            BigInteger[] numers = new BigInteger[1002];
            BigInteger[] denoms = new BigInteger[1002];

            numers[1] = 1;
            numers[2] = 3;
            denoms[1] = 1;
            denoms[2] = 2;

            for (long i = 3; i < 1002; i++)
            {
                numers[i] = 2 * numers[i - 1] + numers[i - 2];
                denoms[i] = 2 * denoms[i - 1] + denoms[i - 2];

                if (numers[i].ToString().Length > denoms[i].ToString().Length)
                    count++;
            }

            Console.WriteLine("Count: " + count);
        }
    }
}
