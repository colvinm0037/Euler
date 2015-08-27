using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_025
    {
        void Main()
        {
            BigInteger[] fibs = new BigInteger[1000000];

            fibs[1] = new BigInteger(1);
            fibs[2] = new BigInteger(1);
            int count = 3;

            while (true)
            {
                fibs[count] = fibs[count - 1] + fibs[count - 2];
                //Console.WriteLine (fibs[count]);
                Console.WriteLine(fibs[count].ToString().Length);

                if (fibs[count].ToString().Length >= 1000)
                {
                    Console.WriteLine("Count: " + count);
                    break;
                }
                count++;
            }
        }
    }
}
