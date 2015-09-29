using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_056 : IEulerProblem
    {
        private string _description = "A googol (10100) is a massive number: one followed by one-hundred zeros; 100100 is almost unimaginably large: one followed by two-hundred zeros. Despite their size, the sum of the digits in each number is only 1." +
                        "\n\nConsidering natural numbers of the form, ab, where a, b< 100, what is the maximum digital sum?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 56; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
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

            return max.ToString();
        }
    }
}
