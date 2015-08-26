using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_009
    {
        void Main()
        {
            for (int i = 1; i < 1000; i++)
            {
                for (int k = i; k < 1000; k++)
                {
                    for (int m = k; m < 1000; m++)
                    {
                        if (i * i + k * k == m * m)
                        {
                            int sum = i + k + m;
                            if (sum == 1000)
                            {
                                Console.WriteLine(i + ", " + k + ", " + m);
                                long product = i * k * m;
                                Console.WriteLine("Sum:" + product);
                            }
                        }
                    }
                }
            }
        }
    }
}
