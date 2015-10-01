using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_039 : IEulerProblem
    {
        private string _description = "If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120." + 
            "\n\n{20,48,52}, {24,45,51}, {30,40,50}" + 
            "\n\nFor which value of p ≤ 1000, is the number of solutions maximised?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 39; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            int maxCount = 0;
            int maxP = 0;

            for (int p = 0; p <= 1000; p++)
            {
                int count = 0;
                for (int i = 1; i < p; i++)
                {
                    for (int j = i + 1; j < p; j++)
                    {
                        int k = p - (i + j);
                        if (i * i + j * j == k * k)
                        {
                            count++;
                        }
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxP = p;
                }
            }
            
            return maxP.ToString();
        }       
    }
}
