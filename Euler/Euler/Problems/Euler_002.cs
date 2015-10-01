﻿using Euler.Euler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_002 : IEulerProblem
    {
        private string _description = "Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:" +
                            "\n\n1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ..." +
                            "\n\nBy considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 2; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            int[] fibs = new int[2000];
            fibs[0] = 1;
            fibs[1] = 2;
            long sum = 2;

            for (int i = 2; i < 2000; i++)
            {
                fibs[i] = fibs[i - 1] + fibs[i - 2];
                if (fibs[i] > 4000000)
                {
                    break;
                }

                if (fibs[i] % 2 == 0)
                {
                    sum += fibs[i];
                }
            }

            return sum.ToString();
        }

    }
}