﻿using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_051 : IEulerProblem
    {
        private bool[] primes = null;
        private string _description = "By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime." +
                        "\n\nBy replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number is the first example having seven primes among the ten generated numbers, yielding the family:" +
                        "\n\n56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being the first member of this family, is the smallest prime with this property." +
                        "\n\nFind the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 51; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            // We can replace any number of digits

            int n = 250000;
            primes = UsefulFunctions.findPrimes(n);
            var primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList();
            primes = UsefulFunctions.findPrimes(1000000);


            foreach (int prime in primeValues.Where(p => p > 1000))
            {
                //List<List<int>> sets = FindTwos(prime);
                List<List<int>> sets = FindThrees(prime);

                foreach (List<int> primeList in sets)
                {
                    if (primeList.Count() >= 8)
                    {
                        // Console.Write("This Prime: " + prime + ", Primes: ");
                        // foreach (int i in primeList)
                        //     Console.Write(i + ", ");
                        // Console.WriteLine();
                        return primeList.First().ToString();
                    }
                }
            }

            return "";
        }

        List<List<int>> FindTwos(int prime)
        {
            string primeString = prime.ToString();
            int primeLength = primeString.Length;
            List<List<int>> sets = new List<List<int>>();

            for (int first = 0; first < primeLength - 1; first++)
            {
                for (int second = first + 1; second < primeLength; second++)
                {
                    List<int> primeList = new List<int>();

                    for (int i = 0; i <= 9; i++)
                    {
                        string value = "";
                        for (int c = 0; c < primeString.Length; c++)
                        {
                            if (c == first || c == second)
                                value = value + i;
                            else
                                value = value + primeString[c];
                        }

                        int newValue = int.Parse(value);
                        if (newValue > 999 && primes[newValue])
                            primeList.Add(newValue);
                    }
                    sets.Add(primeList);
                }
            }

            return sets;
        }

        List<List<int>> FindThrees(int prime)
        {
            string primeString = prime.ToString();
            int primeLength = primeString.Length;
            List<List<int>> sets = new List<List<int>>();

            for (int first = 0; first < primeLength - 1; first++)
            {
                for (int second = first + 1; second < primeLength; second++)
                {
                    for (int third = second + 1; third < primeLength; third++)
                    {
                        List<int> primeList = new List<int>();

                        for (int i = 0; i <= 9; i++)
                        {
                            string value = "";
                            for (int c = 0; c < primeString.Length; c++)
                            {
                                if (c == first || c == second || c == third)
                                    value = value + i;
                                else
                                    value = value + primeString[c];
                            }

                            int newValue = int.Parse(value);
                            if (newValue > 999 && primes[newValue])
                                primeList.Add(newValue);
                        }
                        sets.Add(primeList);
                    }
                }
            }

            return sets;
        }
    }
}
