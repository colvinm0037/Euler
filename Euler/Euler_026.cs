using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_026
    {
        void Main()
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

            Console.WriteLine("Length of sequence: " + sequenceLength);
            Console.WriteLine("Denom: " + finalDenom);
        }
    }
}
