using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Euler.Euler;

namespace Euler
{
    class Euler_016 : IEulerProblem
    {
        private string _description = "2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26." +
                                      "\n\nWhat is the sum of the digits of the number 2^1000?";
        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 16; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            BigInteger digits = BigInteger.Pow(2, 1000);
            long sum = 0;
            foreach (char ch in digits.ToString())
                sum += (int)Char.GetNumericValue(ch);
            //Console.WriteLine("Sum of digits: " + sum);
            //Console.WriteLine("Number of digits: " + digits.ToString().Length);
            return sum.ToString();
        }        
    }
}
