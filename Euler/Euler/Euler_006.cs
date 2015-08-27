using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_006 : EulerProblem
    {
        private string _description = "The sum of the squares of the first ten natural numbers is,\n\n12 + 22 + ... + 102 = 385\n\nThe square of the sum of the first ten natural numbers is,\n\n(1 + 2 + ... + 10)2 = 552 = 3025\n\nHence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.\n\nFind the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 6; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            long sumOfSquares = 0;
            long squareOfSum = 0;

            for (int i = 1; i <= 100; i++)
            {
                squareOfSum += i;
                sumOfSquares += i * i;
            }

            squareOfSum *= squareOfSum;

            //Console.WriteLine(sumOfSquares);
            //Console.WriteLine(squareOfSum);

            long total = squareOfSum - sumOfSquares;
            return total.ToString();
        }        
    }
}
