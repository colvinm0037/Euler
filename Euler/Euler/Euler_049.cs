using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_049
    {
        void Main()
        {
            // The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is
            // unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit
            // numbers are permutations of one another.  There are no arithmetic sequences made up of three
            // 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
            // What 12-digit number do you form by concatenating the three terms in this sequence?

            int n = 10000;
            bool[] primes = findPrimes(n);
            var primeValues = Enumerable.Range(0, (int)n).Where(i => primes[i]).ToList();

            foreach (int prime in primeValues)
            {
                for (int i = 3; i < 3334; i++)
                {
                    if ((prime + i + i) > n)
                        break;

                    if (primes[prime + i] && primes[prime + i + i]) // if 2nd and 3rd are also prime
                    {
                        List<char> a = prime.ToString().ToCharArray().OrderBy(ch => ch).ToList();
                        List<char> b = (prime + i).ToString().ToCharArray().OrderBy(ch => ch).ToList();
                        List<char> c = (prime + i + i).ToString().ToCharArray().OrderBy(ch => ch).ToList();

                        if (a.Count() != b.Count() || a.Count() != c.Count())
                            break;

                        bool isSame = true;

                        for (int k = 0; k < a.Count(); k++)
                        {
                            if (a[k] != b[k] || a[k] != c[k])
                            {
                                isSame = false;
                                break;
                            }
                        }

                        if (isSame)
                        {
                            Console.WriteLine(prime);
                            Console.WriteLine(prime + i);
                            Console.WriteLine(prime + i + i);
                            Console.WriteLine();
                        }
                    }
                }
            }
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
