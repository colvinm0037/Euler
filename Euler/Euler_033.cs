using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_033
    {
        void Main()
        {
            // The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
            // We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
            // There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.

            // If the product of these four fractions is given in its lowest common terms, find the value of the denominator.

            for (int numerator = 10; numerator < 100; numerator++)
            {
                for (int denomenator = numerator + 1; denomenator < 100; denomenator++)
                {
                    double correctFraction = (double)numerator / denomenator;

                    int topDigitOne = numerator / 10;
                    int topDigitTwo = numerator % 10;
                    int bottomDigitOne = denomenator / 10;
                    int bottomDigitTwo = denomenator % 10;

                    if (topDigitTwo == bottomDigitOne)
                    {
                        double incorrectFraction = (double)topDigitOne / bottomDigitTwo;

                        if (incorrectFraction == correctFraction)
                            Console.WriteLine(numerator + "/" + denomenator + ", " + topDigitOne + "/" + bottomDigitTwo + ", " + correctFraction);
                    }
                }
            }
        }
    }
}
