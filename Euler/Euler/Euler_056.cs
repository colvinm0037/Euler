using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_056
    {
        void Main()
        {
            //Considering natural numbers of the form, ab, where a, b < 100, what is the maximum digital sum?
            long max = 0;

            for (int a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    long sum = 0;
                    BigInteger big = BigInteger.Pow(a, b);
                    String str = big.ToString();

                    for (int i = 0; i < str.Length; i++)
                        sum += (int)char.GetNumericValue(str[i]);

                    if (sum > max) max = sum;
                }
            }

            Console.WriteLine("Max Digital Sum: " + max);
        }
    }
}
