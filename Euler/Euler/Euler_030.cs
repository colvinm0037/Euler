using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_030
    {
        void Main()
        {
            long totalSum = 0;
            for (int i = 2; i < (Math.Pow(9, 5) * 6); i++)
            {
                long sum = 0;
                string s = Convert.ToString(i);
                foreach (char c in s)
                    sum += (long)Math.Pow((int)Char.GetNumericValue(c), 5);
                if (sum == i)
                {
                    Console.WriteLine(i);
                    totalSum += i;
                }
            }
            Console.WriteLine("Total: " + totalSum);
        }
    }
}
