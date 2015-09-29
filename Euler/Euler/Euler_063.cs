using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_063 : IEulerProblem
    {
        string _description = "The 5-digit number, 16807=75, is also a fifth power. Similarly, the 9-digit number, 134217728=89, is a ninth power." + 
            "\n\nHow many n-digit positive integers exist which are also an nth power?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 63; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            // The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=8^9, is a ninth power.
            // How many n-digit positive integers exist which are also an nth power?

            int count = 0;
            for (int baseValue = 1; baseValue < 10; baseValue++)
            {
                for (int pow = 0; pow < 30; pow++)
                {
                    BigInteger value = BigInteger.Pow(baseValue, pow);

                    int length = value.ToString().Length;
                    if (length == pow)
                    {
                        //Console.WriteLine(baseValue + "^" + pow + " = " + value);
                        count++;
                    }
                }
            }
            
            return count.ToString();
        }
    }
}
