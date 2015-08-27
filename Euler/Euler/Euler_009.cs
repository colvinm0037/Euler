using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_009 : IEulerProblem
    {
        private string _description = "A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,\n\n" + 
            "a^2 + b^2 = c^2\n\nFor example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.\n\nThere exists exactly one Pythagorean triplet for which a + b + c = 1000." + 
            "\nFind the product abc.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 9; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
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
                                // Console.WriteLine(i + ", " + k + ", " + m);
                                long product = i * k * m;
                                // Console.WriteLine("Sum:" + product);
                                return product.ToString();
                            }
                        }
                    }
                }
            }

            return null;
        }        
    }
}
