using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_015
    {
        void Main()
        {
            Console.WriteLine(CalcRoute(20));
        }

        long CalcRoute(long cubeSize)
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
