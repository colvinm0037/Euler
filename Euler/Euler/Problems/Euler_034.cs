using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_034 : IEulerProblem
    {
        private string _description = "145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145." + 
            "\n\nFind the sum of all numbers which are equal to the sum of the factorial of their digits." + 
            "\n\nNote: as 1! = 1 and 2! = 2 are not sums they are not included.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 34; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            // 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
            // Find the sum of all numbers which are equal to the sum of the factorial of their digits.

            int[] factorials = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

            long finalSum = 0;
            for (long i = 3; i < 1000000; i++)
            {
                string s = Convert.ToString(i);
                long sum = 0;
                foreach (char ch in s)
                {
                    sum += factorials[(int)Char.GetNumericValue(ch)];
                }

                if (sum == i)
                {
                    Console.WriteLine("Adding: " + i);
                    finalSum += i;
                }
            }
            return finalSum.ToString();
        }        
    }
}
