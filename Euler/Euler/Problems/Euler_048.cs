using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_048 : IEulerProblem
    {
        private string _description = "The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317." + 
            "\nFind the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 48; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            BigInteger sum = new BigInteger(0);
            BigInteger mod = new BigInteger(10000000000);

            for (int i = 1; i <= 1000; i++)
                sum += BigInteger.ModPow(i, i, mod);

            return sum.ToString();
        }
    }
}
