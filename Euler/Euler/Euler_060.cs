using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_060
    {
        bool[] primes;

        void Main()
        {
	        // The primes 3, 7, 109, and 673, are quite remarkable.By taking any two primes and concatenating them in any order the result will always be prime.
	        // For example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.
	        // Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.

	        primes = findPrimes(100000000);
	        var primeValues = Enumerable.Range(0, 10000).Where(x => primes[x]).ToList();

	        foreach (int i in primeValues)
	        {
		        foreach (int j in primeValues.Where(x => x > i))
		        {
			        if (!IsMagical(new List<int> { i, j})) continue;

			        foreach (int k in primeValues.Where(x => x > j))
			        {
				        if (!IsMagical(new List<int> { i, j, k})) continue;
			
				        foreach (int l in primeValues.Where(x => x > k))
				        {
					        if (!IsMagical(new List<int> { i, j, k, l})) continue;
				
					        foreach (int m in primeValues.Where(x => x > l))
					        {
						        if (IsMagical(new List<int> { i, j, k, l, m }))
						        {
							        Console.WriteLine(i + " " + j + " " + k + " " + l + " " + m);
							        Console.WriteLine(i + j + k + l + m);
							        return;
						        }
					        }
				        }
			        }
		        }
	        }
        }

        bool[] findPrimes(int number)
        {
	        bool[] myArray = new bool[number];
	        for (int i = 2; i < number; i++)
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

        bool IsMagical(List<int> set)
        {
	        foreach (int p in set)
	        {
		        foreach (int p2 in set.Where(x => x != p))
                {
			        string str = p + "" + p2;
			        if (!primes[Int32.Parse(str)])
				        return false;
		        }
	        }

	        return true;
        }
    }
}
