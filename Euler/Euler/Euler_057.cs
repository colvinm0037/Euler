using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_057 : IEulerProblem
    {
        private string _description = "It is possible to show that the square root of two can be expressed as an infinite continued fraction." + 
                       "\n\n√ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213..." +
                       "\n\nBy expanding this for the first four iterations, we get:" +
                       "\n\n1 + 1/2 = 3/2 = 1.5" +
                       "\n1 + 1/(2 + 1/2) = 7/5 = 1.4" +
                       "\n1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666..." +
                       "\n1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379..." +
                       "\n\nThe next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example where the number of digits in the numerator exceeds the number of digits in the denominator." +
                       "\n\nIn the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 57; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {            
            BigInteger count = 0;
            BigInteger[] numers = new BigInteger[1002];
            BigInteger[] denoms = new BigInteger[1002];

            numers[1] = 1;
            numers[2] = 3;
            denoms[1] = 1;
            denoms[2] = 2;

            for (long i = 3; i < 1002; i++)
            {
                numers[i] = 2 * numers[i - 1] + numers[i - 2];
                denoms[i] = 2 * denoms[i - 1] + denoms[i - 2];

                if (numers[i].ToString().Length > denoms[i].ToString().Length)
                    count++;
            }

            return count.ToString();
        }
    }
}
