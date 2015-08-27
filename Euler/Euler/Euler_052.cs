using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_052
    {
        void Main()
        {
            // It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.
            // Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.

            for (int i = 1; i < 1000000; i++)
            {
                List<char> integer = i.ToString().ToCharArray().OrderBy(ch => ch).ToList();
                bool isMatch = true;

                for (int factor = 2; factor <= 6; factor++)
                {
                    List<char> multiple = (i * factor).ToString().ToCharArray().OrderBy(ch => ch).ToList();

                    if (integer.Count() != multiple.Count())
                    {
                        isMatch = false;
                        break;
                    }

                    for (int k = 0; k < integer.Count(); k++)
                    {
                        if (integer[k] != multiple[k] || integer[k] != multiple[k])
                        {
                            isMatch = false;
                            break;
                        }
                    }
                }

                if (isMatch)
                {
                    for (int m = 1; m < 7; m++)
                        Console.WriteLine(i * m);

                    break;
                }
            }
        }
    }
}
