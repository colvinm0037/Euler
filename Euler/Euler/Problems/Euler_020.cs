using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_020 : IEulerProblem
    {
        private string _description = "n! means n × (n − 1) × ... × 3 × 2 × 1" +
            "\nFor example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800," +
            "\nand the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27." +
            "\nFind the sum of the digits in the number 100!";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 20; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            BigInteger number = BigInteger.Parse("100");
            BigInteger result = Factorial(number);
            String digits = result.ToString();

            // Console.WriteLine(result);
            // Console.WriteLine(digits);

            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += (int)Char.GetNumericValue(digits[i]);
            }

            return sum.ToString();
        }

        private static BigInteger Factorial(BigInteger number)
        {
            if (number == 1)
                return BigInteger.One;
            else
                return number * Factorial(number - BigInteger.One);
        }        
    }
}
