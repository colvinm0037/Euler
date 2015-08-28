using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_031 : IEulerProblem
    {
        private string _description = "In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:" +
            "\n\n1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p)." +
            "\nIt is possible to make £2 in the following way:" +
            "\n\n1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p" +
            "\nHow many different ways can £2 be made using any number of coins?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 31; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            // In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

            // 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
            // It is possible to make £2 in the following way:

            // 1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
            // How many different ways can £2 be made using any number of coins?

            int[] values = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };

            int count = Sum(200);
            count++; // add the 200p option
            return count.ToString();
        }

        private static int Sum(int n)
        {
            int count = 0;
            for (int g = 0; g <= n / 100; g++)
            {
                for (int h = 0; h <= n / 50; h++)
                {
                    for (int i = 0; i <= n / 20; i++)
                    {
                        for (int j = 0; j <= n / 10; j++)
                        {
                            for (int k = 0; k <= n / 5; k++)
                            {
                                for (int m = 0; m <= n / 2; m++)
                                {
                                    for (int l = 0; l <= n; l++)
                                    {
                                        int v = g * 100 + h * 50 + i * 20 + j * 10 + k * 5 + m * 2 + l;
                                        if (v == n)
                                            count++;
                                        else if (v > n)
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }        
    }
}
