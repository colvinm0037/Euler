using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_058_Version_2
    {
        void Main()
        {
            int position = 1;
            int smallGap = 2;
            int bigGap = 4;
            int totalPrimeCount = 0;

            HashSet<int> diagonals = new HashSet<int>();
            diagonals.Add(1);
            bool isFound = false;

            while (!isFound)
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
                    Console.WriteLine("Average: " + average + ", position: " + position + ", sideLength: " + (bigGap - 1));
                    isFound = true;
                    break;
                }

                smallGap += 2;
                bigGap += 2;
            }
        }

        bool isPrime(int number)
        {
            if (number <= 1)
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
