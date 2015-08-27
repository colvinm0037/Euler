using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_040
    {
        void Main()
        {
            /*
            An irrational decimal fraction is created by concatenating the positive integers:
            0.123456789101112131415161718192021...
            It can be seen that the 12th digit of the fractional part is 1.
            If dn represents the nth digit of the fractional part, find the value of the following expression.
            d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
            */

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 1000000; i++)
            {
                sb.Append("" + i);
                if (sb.Length > 1000000)
                    break;
            }

            String s = sb.ToString();
            double result = char.GetNumericValue(s[0]) * char.GetNumericValue(s[9]) * char.GetNumericValue(s[99]) * char.GetNumericValue(s[999]) * char.GetNumericValue(s[9999]) * char.GetNumericValue(s[99999]) * char.GetNumericValue(s[999999]);
            Console.WriteLine(result);
        }
    }
}
