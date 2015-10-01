using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_026 : IEulerProblem
    {
        private string _description = "A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:" +
            "\n1/2	= 	0.5" +
            "\n1/3	= 	0.(3)" +
            "\n1/4	= 	0.25" +
            "\n1/5	= 	0.2" +
            "\n1/6	= 	0.1(6)" +
            "\n1/7	= 	0.(142857)" +
            "\n1/8	= 	0.125" +
            "\n1/9	= 	0.(1)" +
            "\n1/10	= 	0.1" +
            "\nWhere 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle." +
            "\n\nFind the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 26; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            int sequenceLength = 0;
            int finalDenom = 0;

            for (int denom = 1000; denom > 1; denom--)
            {
                if (sequenceLength >= denom)
                    break;

                int[] foundRemainders = new int[denom];
                int value = 1;
                int position = 0;

                while (foundRemainders[value] == 0 && value != 0)
                {
                    foundRemainders[value] = position;
                    value = (value * 10) % denom;
                    position++;
                }

                int newSequenceLength = position - foundRemainders[value];
                if (newSequenceLength > sequenceLength)
                {
                    sequenceLength = position - foundRemainders[value];
                    finalDenom = denom;
                }
            }
            
            return finalDenom.ToString();
        }        
    }
}
