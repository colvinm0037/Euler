using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_020
    {
        void Main()
        {
            BigInteger number = BigInteger.Parse("100");
            BigInteger result = Factorial(number);
            String digits = result.ToString();

            Console.WriteLine(result);
            Console.WriteLine(digits)

            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += (int)Char.GetNumericValue(digits[i]);
            }

            Console.WriteLine(sum);
        }

        BigInteger Factorial(BigInteger number)
        {
            if (number == 1)
                return BigInteger.One;
            else
                return number * Factorial(number - BigInteger.One);
        }
    }
}
