using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_015 : IEulerProblem
    {
        private string _description = "Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner." +
                                      "\n\nHow many such routes are there through a 20×20 grid?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 15; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
           return CalcRoute(20).ToString();
        }

        private long CalcRoute(long cubeSize)
        {
            long[] L = new long[cubeSize];
            for (long a = 0; a < L.Length; a++)
                L[a] = 1;

            for (long i = 0; i < cubeSize; i++)
            {
                for (long j = 0; j < i; j++)
                {
                    if (j == 0)
                        L[j] = L[j] + 1;
                    else
                        L[j] = L[j] + L[j - 1];
                }
                if (i == 0)
                    L[i] = 2 * 1;
                else
                    L[i] = 2 * L[i - 1];
            }

            return L[cubeSize - 1];
        }        
    }
}
