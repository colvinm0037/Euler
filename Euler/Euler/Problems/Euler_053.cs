using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_053 : IEulerProblem
    {
        private string _description = "There are exactly ten ways of selecting three from five, 12345:" +
            "\n\n123, 124, 125, 134, 135, 145, 234, 235, 245, and 345" +
            "\n\nIn combinatorics, we use the notation, 5C3 = 10." +
            "\n\nIn general," +
            "\n\nnCr = n! / r!(n−r)!, where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1." +
            "\n\nIt is not until n = 23, that a value exceeds one-million: 23C10 = 1144066." +
            "\n\nHow many, not necessarily distinct, values of nCr, for 1 ≤ n ≤ 100, are greater than one-million?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 53; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            int count = 0;

            for (int n = 1; n <= 100; n++)
            {
                for (int r = 1; r <= n; r++)
                {
                    BigInteger amount = (UsefulFunctions.Factorial(n)) / ((UsefulFunctions.Factorial(r)) * (UsefulFunctions.Factorial(n - r)));
                    if (amount > 1000000)
                    {            
                        count++;
                    }
                }
            }
                        
            return count.ToString();
        }
    }
}
