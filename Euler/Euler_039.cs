using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_039
    {
        void Main()
        {
            // If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.
            // {20,48,52}, {24,45,51}, {30,40,50}
            // For which value of p ≤ 1000, is the number of solutions maximised?

            int maxCount = 0;
            int maxP = 0;

            for (int p = 0; p <= 1000; p++)
            {
                int count = 0;
                for (int i = 1; i < p; i++)
                {
                    for (int j = i + 1; j < p; j++)
                    {
                        int k = p - (i + j);
                        if (i * i + j * j == k * k)
                        {
                            //	Console.WriteLine (i + "," + j + "," + k);
                            count++;
                        }
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxP = p;
                    Console.WriteLine(p);
                }
            }

            Console.WriteLine("Count: " + maxCount);
            Console.WriteLine("p: " + maxP);
        }
    }
}
