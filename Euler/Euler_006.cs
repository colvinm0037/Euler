using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_006
    {
        void Main()
        {
            long sumOfSquares = 0;
            long squareOfSum = 0;

            for (int i = 1; i <= 100; i++)
            {
                squareOfSum += i;
                sumOfSquares += i * i;
            }

            squareOfSum *= squareOfSum;

            Console.WriteLine(sumOfSquares);
            Console.WriteLine(squareOfSum);

            long total = squareOfSum - sumOfSquares;
            Console.WriteLine(total);
        }
    }
}
