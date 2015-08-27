using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_005
    {
        static void Main(string[] args)
        {
            for (int i = 20; i < 10000000000; i = i + 20)
            {
                if (checkDivisors(i))
                {
                    Console.WriteLine(i);
                    break;
                }
            }

            Console.ReadKey();
        }

        static bool checkDivisors(int number)
        {
            for (int k = 1; k <= 20; k++)
            {
                if (number % k != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
