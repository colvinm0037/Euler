using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_005 : EulerProblem
    {
        private string _description = "2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\n\nWhat is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 5; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            for (int i = 20; i < 10000000000; i = i + 20)
            {
                if (checkDivisors(i))
                    return i.ToString();
            }
            return null;
        }

        private static bool checkDivisors(int number)
        {
            for (int k = 1; k <= 20; k++)
            {
                if (number % k != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
