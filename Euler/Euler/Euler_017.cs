using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_017
    {
        void Main()
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

                Console.WriteLine(word);
                sum += word.Length;
            }

            Console.WriteLine(onethousand);
            sum += onethousand.Length;
            Console.WriteLine(sum);
        }
    }
}
