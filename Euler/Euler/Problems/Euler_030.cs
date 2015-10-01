using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_030 : IEulerProblem
    {
        private string _description = "Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:" +
            "\n\n1634 = 1^4 + 6^4 + 3^4 + 4^4" +
            "\n8208 = 8^4 + ^24 + 0^4 + 8^4" +
            "\n9474 = 9^4 + 4^4 + 7^4 + 4^4" +
            "\nAs 1 = 1^4 is not a sum it is not included." +
            "\n\nThe sum of these numbers is 1634 + 8208 + 9474 = 19316." + 
            "\n\nFind the sum of all the numbers that can be written as the sum of fifth powers of their digits.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 30; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            long totalSum = 0;
            for (int i = 2; i < (Math.Pow(9, 5) * 6); i++)
            {
                long sum = 0;
                string s = Convert.ToString(i);
                foreach (char c in s)
                    sum += (long)Math.Pow((int)Char.GetNumericValue(c), 5);
                if (sum == i)
                {
                    totalSum += i;
                }
            }
            return totalSum.ToString();
        }        
    }
}
