using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Euler
{
    public class Interface
    {       
        static void Main(string[] args)
        {
            var accessors = typeof(EulerProblem)
            .Assembly
            .GetTypes()
            .Where(t => !t.IsInterface && typeof(EulerProblem).IsAssignableFrom(t))
            .Select(a => (EulerProblem) Activator.CreateInstance(a))
            .ToList();

            Console.WriteLine("Welcome to Project Euler");
            while (true)
            {                
                Console.Write("Please enter a number [q to quit]: ");                
                string input = Console.ReadLine();
                if (input == "q") break;
                
                Console.WriteLine();
                var result = accessors.Where(a => a.Number == int.Parse(input)).FirstOrDefault();

                if (result == null)
                {
                    Console.WriteLine("Sorry, this problem hasn't been implemented yet");
                }
                else
                {
                    Console.WriteLine(result.Description);
                    Console.WriteLine();
                    Console.WriteLine("The solution: " + result.Run());
                    Console.WriteLine();
                }
            }
        } 
    }
}
