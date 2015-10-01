using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_033 : IEulerProblem
    {
        // TODO: Need to fix so that answer is returned

        private string _description = "The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s." + 
            "\n\nWe shall consider fractions like, 30/50 = 3/5, to be trivial examples." +
            "\n\nThere are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator." + 
            "\n\nIf the product of these four fractions is given in its lowest common terms, find the value of the denominator.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get {return 33; }
        }

        public string Description
        {
            get {return _description; }
        }

        private string Main()
        {
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
            return "";
        }       
    }
}
