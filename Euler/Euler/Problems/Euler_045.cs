﻿using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_045 : IEulerProblem
    {
        private string _description = "Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:" + 
            "\n\nTriangle	 	Tn=n(n+1)/2	 	1, 3, 6, 10, 15, ..." + 
            "\nPentagonal	 	Pn=n(3n−1)/2	 	1, 5, 12, 22, 35, ..." + 
            "\nHexagonal	 	Hn=n(2n−1)	 	1, 6, 15, 28, 45, ..." +
            "\nIt can be verified that T285 = P165 = H143 = 40755." + 
            "\n\nFind the next triangle number that is also pentagonal and hexagonal.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 45; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            HashSet<long> hexagonals = FindHexagonalNumbers(100000);
            HashSet<long> pentagonals = FindPentagonalNumbers(100000);
            HashSet<long> triangles = FindTriangleNumbers(100000);

            int count = 0;
            long result = 0;
            foreach (long number in triangles)
            {
                count++;
                if (hexagonals.Contains(number) && pentagonals.Contains(number))
                {
                    result = number;
                }
            }
            return result.ToString();
        }

        private static HashSet<long> FindPentagonalNumbers(int number)
        {
            HashSet<long> pentagonals = new HashSet<long>();

            for (long i = 1; i <= number; i++)
            {
                long pentagonal = i * (3 * i - 1) / 2;
                if (pentagonal < 0)
                    Console.WriteLine("PENTAGONAL ERROR: " + i);
                pentagonals.Add(pentagonal);
            }

            return pentagonals;
        }

        private static HashSet<long> FindHexagonalNumbers(int number)
        {
            HashSet<long> hexagonals = new HashSet<long>();

            for (long i = 1; i <= number; i++)
            {
                long hexagonal = i * (2 * i - 1);
                if (hexagonal < 0)
                    Console.WriteLine("HEXAGONAL ERROR: " + i);
                hexagonals.Add(hexagonal);
            }

            return hexagonals;
        }

        private static HashSet<long> FindTriangleNumbers(int number)
        {
            HashSet<long> triangles = new HashSet<long>();

            for (long i = 1; i <= number; i++)
            {
                long triangle = (long)((i) * (i + 1)) / 2;
                if (triangle < 0)
                    Console.WriteLine("TRIANGLE ERROR: " + i + ", " + triangle);
                triangles.Add(triangle);
            }

            return triangles;
        }        
    }
}
