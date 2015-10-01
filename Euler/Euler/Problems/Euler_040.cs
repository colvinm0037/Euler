using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_040 : IEulerProblem
    {
        private string _description = "An irrational decimal fraction is created by concatenating the positive integers:" +
            "\n\n0.123456789101112131415161718192021..." +
            "\n\nIt can be seen that the 12th digit of the fractional part is 1." +
            "\n\nIf dn represents the nth digit of the fractional part, find the value of the following expression." +
            "\n\nd1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000";

        public string Run()
        {
            return Run();
        }

        public int Number
        {
            get { return 40; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {           
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 1000000; i++)
            {
                sb.Append("" + i);
                if (sb.Length > 1000000)
                    break;
            }

            String s = sb.ToString();
            double result = char.GetNumericValue(s[0]) * char.GetNumericValue(s[9]) * char.GetNumericValue(s[99]) * char.GetNumericValue(s[999]) * char.GetNumericValue(s[9999]) * char.GetNumericValue(s[99999]) * char.GetNumericValue(s[999999]);
            return result.ToString();
        }        
    }
}
