using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_044
    {
        void Main()
        {
            // Pn=n(3n−1)/2. The first ten pentagonal numbers are:

            // 1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...

            // Find the pair of pentagonal numbers, Pj and Pk, for which their sum and difference are pentagonal and D = |Pk − Pj| is minimised; what is the value of D?

            // Trick is to just try and find the first pair
            // There isn't an exact science to picking how many pentagonal numbers we need to check

            HashSet<long> pentagonals = PentagonalNumbers(2500);

            foreach (long i in pentagonals)
            {
                foreach (long j in pentagonals)
                {
                    if (pentagonals.Contains(i + j) && pentagonals.Contains(Math.Abs(i - j)))
                    {
                        Console.WriteLine("I = " + i);
                        Console.WriteLine("J = " + j);
                        Console.WriteLine("D = " + Math.Abs(i - j));
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }

        HashSet<long> PentagonalNumbers(int number)
        {
            HashSet<long> pentagonals = new HashSet<long>();

            for (int i = 1; i <= number; i++)
            {
                long pentagonal = i * (3 * i - 1) / 2;
                pentagonals.Add(pentagonal);
            }

            return pentagonals;
        }
    }
}
