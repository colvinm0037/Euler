using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_017 : IEulerProblem
    {
        private string _description = "If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total." + 
                                      "\n\nIf all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?" + 
                                      "\n\nNOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of \"and\" when writing out numbers is in compliance with British usage.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 17; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            string[] digits = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] bigDigits = new string[] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety", };
            string hundred = "hundred";
            string and = "and";
            string onethousand = "onethousand";

            string word = null;
            long sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                if (i < 10)
                {
                    word = digits[i];
                }
                else if (i < 20)
                {
                    word = teens[i - 10];
                }
                else if (i < 100)
                {
                    int tensDigit = i / 10;
                    int onesDigit = i % 10;
                    word = bigDigits[tensDigit] + digits[onesDigit];
                }
                else if (i < 1000)
                {
                    int hundredsDigit = i / 100;
                    int tensDigit = (i - 100 * hundredsDigit) / 10;
                    int onesDigit = i % 10;

                    if (tensDigit == 0)
                    {
                        if (onesDigit > 0)
                            word = digits[hundredsDigit] + hundred + and + digits[onesDigit];
                        else
                            word = digits[hundredsDigit] + hundred;
                    }
                    else if (tensDigit == 1)
                    {
                        word = digits[hundredsDigit] + hundred + and + teens[onesDigit];
                    }
                    else
                    {
                        word = digits[hundredsDigit] + hundred + and + bigDigits[tensDigit] + digits[onesDigit];
                    }
                }
                            
                sum += word.Length;
            }
                        
            sum += onethousand.Length;            
            return sum.ToString();
        }    
    }
}
