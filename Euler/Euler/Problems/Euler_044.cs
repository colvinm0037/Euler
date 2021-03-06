﻿using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_044 : IEulerProblem
    {
        private string _description = "Pentagonal numbers are generated by the formula, Pn=n(3n−1)/2. The first ten pentagonal numbers are:" + 
            "\n\n1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ..." +
            "\n\nIt can be seen that P4 + P7 = 22 + 70 = 92 = P8. However, their difference, 70 − 22 = 48, is not pentagonal." + 
            "\n\nFind the pair of pentagonal numbers, Pj and Pk, for which their sum and difference are pentagonal and D = |Pk − Pj| is minimised; what is the value of D?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 44; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            // Trick is to just try and find the first pair
            // There isn't an exact science to picking how many pentagonal numbers we need to check

            HashSet<long> pentagonals = PentagonalNumbers(2500);
            string result = "";

            foreach (long i in pentagonals)
            {
                foreach (long j in pentagonals)
                {
                    if (pentagonals.Contains(i + j) && pentagonals.Contains(Math.Abs(i - j)))
                    {                        
                        result = Math.Abs(i - j).ToString();
                        return result;
                    }
                }
            }

            return result;
        }

        private HashSet<long> PentagonalNumbers(int number)
        {
            HashSet<long> pentagonals = new HashSet<long>();

            for (int i = 1; i <= number; i++)
            {
                long pentagonal = i * (3 * i - 1) / 2;
                pentagonals.Add(pentagonal);
            }

            return pentagonals;
        }
    }
}
