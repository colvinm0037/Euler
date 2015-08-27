using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_014
    {
        void Main()
        {
            int max = 0;
            for (int i = 2; i <= 1000000; i++)
            {
                int sequence = FindCollatzNumbers(i);
                if (sequence > max)
                {
                    max = sequence;
                    Console.WriteLine("i; " + i + ", max: " + max);
                }
            }
            Console.WriteLine(max);
        }

        int FindCollatzNumbers(int number)
        {
            int sequence = 1;
            long current = number;

            while (current != 1)
            {
                if (current % 2 == 0)
                    current = current / 2;
                else
                    current = 3 * current + 1;
                sequence++;
            }
            return sequence;
        }
    }
}
