using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_058_Version_2 : IEulerProblem
    {
        string _description = "Starting with 1 and spiralling anticlockwise in the following way, a square spiral with side length 7 is formed." +
                "\n\n37 36 35 34 33 32 31" +
                "\n38 17 16 15 14 13 30" +
                "\n39 18  5  4  3 12 29" +
                "\n40 19  6  1  2 11 28" +
                "\n41 20  7  8  9 10 27" +
                "\n42 21 22 23 24 25 26" +
                "\n43 44 45 46 47 48 49" +
                "\n\nIt is interesting to note that the odd squares lie along the bottom right diagonal, but what is more interesting is that 8 out of the 13 numbers lying along both diagonals are prime; that is, a ratio of 8/13 ≈ 62%." +
                "\n\nIf one complete new layer is wrapped around the spiral above, a square spiral with side length 9 will be formed.If this process is continued, what is the side length of the square spiral for which the ratio of primes along both diagonals first falls below 10%?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 58; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            int position = 1;
            int smallGap = 2;
            int bigGap = 4;
            int totalPrimeCount = 0;

            HashSet<int> diagonals = new HashSet<int>();
            diagonals.Add(1);
            
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    position += smallGap;
                    diagonals.Add(position);
                    if (isPrime(position))
                        totalPrimeCount++;
                }

                double average = (double)totalPrimeCount / diagonals.Count();

                if (average < .10)
                {            
                    break;
                }

                smallGap += 2;
                bigGap += 2;
            }
            return (bigGap - 1).ToString();
        }

        bool isPrime(int number)
        {
            if (number < 2)
                return false;

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Sqrt(number); i = i + 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
