using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_060: IEulerProblem
    {
        private bool[] primes;
        private string _description = "The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes and concatenating them in any order the result will always be prime. For example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property." +
                "\n\nFind the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 60; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
	        primes = UsefulFunctions.findPrimes(100000000);
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
                                    return (i + j + k + l + m).ToString();							        
						        }
					        }
				        }
			        }
		        }
	        }
            return "";
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
