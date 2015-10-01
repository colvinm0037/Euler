using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_038 : IEulerProblem
    {
        private string _description = "Take the number 192 and multiply it by each of 1, 2, and 3:" + 
            "\n\n192 × 1 = 192" + 
            "\n192 × 2 = 384" + 
            "\n192 × 3 = 576" + 
            "\nBy concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated product of 192 and (1,2,3)" +
            "\n\nThe same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5)." + 
            "\n\nWhat is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 38; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            long maxPandigital = 0;
            int upperBound = 10000;

            for (int currentNumber = 1; currentNumber <= upperBound; currentNumber++)
            {
                long testValue = currentNumber;
                int factor = 2;
                while (testValue < 10000000000)
                {
                    long concatValue = currentNumber * factor; // the number we add to end of value			
                    foreach (char c in concatValue.ToString()) // shift testValue to left for each digit in concatValue
                        testValue *= 10;
                    testValue += concatValue;

                    if (IsPandigital(testValue, 9))
                    {
                        if (testValue > maxPandigital)
                        {
                            maxPandigital = testValue;
                            break;
                        }
                    }

                    factor++;
                }
            }

            return maxPandigital.ToString();
        }

        private static bool IsPandigital(long number, int end)
        {
            string num = number.ToString();

            if (num.Length != end)
                return false;

            for (int i = 1; i <= end; i++)
            {
                if (!num.Contains(i.ToString()))
                    return false;
            }

            return true;
        }
    }
}
