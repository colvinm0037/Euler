using Euler.Euler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_001 : IEulerProblem
    {
        private string _description = "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23." +
                         "\n\nFind the sum of all the multiples of 3 or 5 below 1000.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 1; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            // Avoiding use of modulous for perfomance reasons

            // Find sum of all multiples of 3 below 1000
            long total1 = 1000 / 3;
            long totalSum1 = (total1 * (total1 + 1)) / 2;
            long sumOfThrees = 3 * totalSum1;

            // Find sum of all multiples of 5 below 1000
            long total2 = 999 / 5;
            long totalSum2 = (total2 * (total2 + 1)) / 2;
            long sumOfFives = 5 * totalSum2;

            // Find sum of all multiples of 15 below 1000
            long total3 = 1000 / 15;
            long totalSum3 = (total3 * (total3 + 1)) / 2;
            long sumOfFifteens = 15 * totalSum3;

            long finalSum = sumOfThrees + sumOfFives - sumOfFifteens;
            return finalSum.ToString();
        }
    }
}
