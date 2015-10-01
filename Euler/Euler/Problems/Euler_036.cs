using Euler.Euler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_036 : IEulerProblem
    {
        private string _description = "The decimal number, 585 = 10010010012 (binary), is palindromic in both bases." +
            "\n\nFind the sum of all numbers, less than one million, which are palindromic in base 10 and base 2." +
            "\n\n(Please note that the palindromic number, in either base, may not include leading zeros.)";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 36; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            long sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                if (UsefulFunctions.isPalindrome(i) && UsefulFunctions.isPalindrome(Convert.ToString(i, 2)))
                {
                    Console.WriteLine(i + " and " + Convert.ToString(i, 2) + " are palindromes");
                    sum += i;
                }
            }
            return sum.ToString();
        }     
    }
}
