using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_028
    {
        void Main()
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

            Console.WriteLine(sum);
        }
    }
}
