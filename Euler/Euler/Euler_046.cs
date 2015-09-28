using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_046 : IEulerProblem
    {
        private string _description = "It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square." +
            "\n9 = 7 + 2×1^2" + 
            "\n15 = 7 + 2×2^2" + 
            "\n21 = 3 + 2×3^2" + 
            "\n25 = 7 + 2×3^2" + 
            "\n27 = 19 + 2×2^2" + 
            "\n33 = 31 + 2×1^2" + 
            "\n\nIt turns out that the conjecture was false." +
            "\nWhat is the smallest odd composite that cannot be written as the sum of a prime and twice a square?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 46; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            long n = 100000;
            bool[] primes = findPrimes(n); // bool array of what numbers are prime up to n
            var primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList(); // list of all primes less than n

            var oddComposites = Enumerable.Range(3, (int)(n - 3)).Where(i => (i % 2 != 0) && !primes[i]).ToList();

            foreach (long oddComposite in oddComposites)
            {
                var subPrimes = primeValues.Where(i => i <= oddComposite).ToList(); // all primes <= than odd composite
                bool isMatch = false;
                int chosenSquare = 0;
                long chosenSubprime = 0;

                foreach (long subPrime in subPrimes)
                {
                    for (int square = 1; square < subPrime; square++)
                    {
                        long sum = subPrime + 2 * (square * square);

                        if (sum == oddComposite)
                        {
                            isMatch = true;
                            chosenSubprime = subPrime;
                            chosenSquare = square;
                            break;
                        }

                        if (sum > oddComposite)
                            break;
                    }

                    if (isMatch)
                        break;
                }

                if (!isMatch)
                {
                    return oddComposite.ToString();
                }
            }
            return "";
        }

        bool[] findPrimes(long number)
        {
            bool[] myArray = new bool[number];
            for (long i = 2; i < number; i++)
                myArray[i] = true;

            for (int k = 2; k < Math.Sqrt(number); k++)
            {
                if (myArray[k])
                {
                    for (int m = k * k; m < number; m += k)
                        myArray[m] = false;
                }
            }

            return myArray;
        }
    }
}
