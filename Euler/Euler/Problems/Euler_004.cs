using Euler.Euler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_004 : IEulerProblem
    {
        private string _description = "A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.\n\nFind the largest palindrome made from the product of two 3-digit numbers.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 4; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            int max = 0;

            for (int i = 999; i > 0; i--)
            {
                for (int k = 999; k > 0; k--)
                {
                    int number = i * k;
                    if (UsefulFunctions.isPalindrome(number))
                    {
                        if (number > max)
                            max = number;
                    }
                }
            }

            return max.ToString();
        }      
    }
}
