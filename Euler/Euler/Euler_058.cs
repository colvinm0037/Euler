using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_058
    {
        bool[] primes = null;

        void Main()
        {
            // 26241
            int position = 1;
            int smallGap = 2;
            int bigGap = 4;

            HashSet<int> diagonals = new HashSet<int>();
            diagonals.Add(1);
            primes = findPrimes(700000000);
            bool isFound = false;

            while (!isFound)
            {
                for (int i = 0; i < 4; i++)
                {
                    position += smallGap;
                    diagonals.Add(position);
                }

                double average = CalcAverage(diagonals);
                // Console.WriteLine (position + ", " + bigGap + ", " + average + ", " + (bigGap + 1));				

                if (average < .10)
                {
                    Console.WriteLine("Average: " + average + ", position: " + position + ", sideLength: " + (bigGap - 1));
                    isFound = true;
                    break;
                }

                Console.WriteLine("SideLength: " + (bigGap + 1));

                smallGap += 2;
                bigGap += 2;


                if (position > 690000000)
                    break;
            }
        }

        double CalcAverage(HashSet<int> diagonals)
        {
            long totalCount = diagonals.Count();
            int primeCount = 0;

            foreach (int diagonal in diagonals)
            {
                if (primes[diagonal])
                    primeCount++;
            }

            double average = (double)primeCount / totalCount;
            return average;
        }

        bool[] findPrimes(long number)
        {
            bool[] myArray = new bool[number];
            for (long i = 2; i < number; i++)
                myArray[i] = true;

            for (int k = 2; k < Math.Sqrt(number); k++)
            {
                if (myArray[k])
                {
                    for (int m = k * k; m < number; m += k)
                        myArray[m] = false;
                }
            }

            return myArray;
        }
    }
}
