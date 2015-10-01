using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_028 : IEulerProblem
    {
        private string _description = "Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:" + 
            "\n21 22 23 24 25" + 
            "\n20  7  8  9 10" + 
            "\n19  6  1  2 11" + 
            "\n18  5  4  3 12" + 
            "\n17 16 15 14 13" +
            "\n\nIt can be verified that the sum of the numbers on the diagonals is 101." + 
            "\n\nWhat is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 28; }
        }

        public string Description
        {
            get {return _description; }
        }

        private string Main()
        {
            // 1  3 5 7 9  13 17 21 25  31 37 43 49  57 65 73 81

            long sum = 1;
            int lastDigit = 1;
            int counter = 2;

            for (int i = 0; i < 500; i++)
            {
                for (int k = 1; k < 5; k++)
                    sum += lastDigit + counter * k;
                lastDigit += counter * 4;
                counter += 2;
            }

            return sum.ToString();
        }        
    }
}
