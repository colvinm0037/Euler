using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_029
    {
        void Main()
        {
            HashSet<BigInteger> bigDigits = new HashSet<BigInteger>();
            for (int i = 2; i <= 100; i++)
            {
                for (int k = 2; k <= 100; k++)
                {
                    bigDigits.Add(BigInteger.Pow(i, k));
                }
            }
            Console.WriteLine(bigDigits.Count);
        }
    }
}
