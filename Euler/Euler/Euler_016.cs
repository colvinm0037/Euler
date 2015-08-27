using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Euler
{
    class Euler_016
    {
        void Main()
        {
            BigInteger digits = BigInteger.Pow(2, 1000);
            long sum = 0;
            foreach (char ch in digits.ToString())
                sum += (int)Char.GetNumericValue(ch);
            Console.WriteLine("Sum of digits");
            Console.WriteLine("Number of digits: " + digits.ToString().Length);
        }
    }
}
