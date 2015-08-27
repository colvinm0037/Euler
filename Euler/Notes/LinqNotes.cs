using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Notes
{
    class LinqNotes
    {
        void Main()
        {
            IEnumerable<Recipe> recipes = new[]
             {
 	            new Recipe {Id = 1, Name = "Apple Pie", Rating = 5},
 	            new Recipe {Id = 2, Name = "Cherry Pie", Rating = 2},
 	            new Recipe {Id = 3, Name = "Beef Pie", Rating = 3}
             };

            Dictionary<int, Recipe> dictionaries = recipes.ToDictionary(x => x.Id);

            foreach (var d in dictionaries)
                Console.WriteLine("key = " + d.Key + ", Name = " + d.Value.Name);

            var digits = Enumerable.Range(10, 20).Where(x => x % 2 == 0 && x % 3 == 0);

            var result = digits.Aggregate(0,
           (currentElement, runningTotal) => runningTotal + currentElement);
                    
            Console.WriteLine("result: " + result);

            foreach (int i in digits)
                Console.WriteLine(i);


            var someNumbers = Enumerable.Range(1, 10000000).ToArray();
            var sw = new Stopwatch();
            sw.Start();
            someNumbers.Where(x => x.ToString().Contains("3")).ToArray();
            sw.Stop();
            Console.WriteLine("Non PLINQ query took {0} ms", sw.ElapsedMilliseconds);

            sw.Restart();
            someNumbers.AsParallel().Where(x => x.ToString().Contains("3")).ToArray();
            sw.Stop();
            Console.WriteLine("PLINQ query took {0} ms", sw.ElapsedMilliseconds);


            var inputNumbers = Enumerable.Range(1, 10).ToArray();
            Console.WriteLine("Input numbers");
            foreach (var num in inputNumbers)
            {
                Console.Write(num + " ");
            }
            var outputNumbers = inputNumbers.AsParallel().Select(x => x);
            Console.WriteLine();
            Console.WriteLine("Output numbers");
            foreach (var num in outputNumbers)
            {
                Console.Write(num + " ");
            }

        }
        class Recipe
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Rating { get; set; }
        }

        // Define other methods and classes here
    }
}
