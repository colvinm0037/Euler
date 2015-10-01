using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Euler
{
    public class UserInterface
    {       
        static void Main(string[] args)
        {
            // Use reflection to grab all classes that implement IEulerProblem
            var eulerImplementations = typeof(IEulerProblem)
            .Assembly.GetTypes()
            .Where(t => !t.IsInterface && typeof(IEulerProblem).IsAssignableFrom(t))
            .Select(a => (IEulerProblem) Activator.CreateInstance(a))
            .ToList();

            // User Interface loop
            Console.WriteLine("Welcome to Project Euler");
            while (true)
            {                
                Console.Write("Please enter a number [q to quit]: ");                
                string input = Console.ReadLine();
                if (input == "q" || input == "") break;

                Console.Clear();
                var result = eulerImplementations.Where(a => a.Number == int.Parse(input)).FirstOrDefault();

                if (result == null)
                {
                    Console.WriteLine("Sorry, this problem hasn't been implemented yet");
                }
                else
                {
                    Console.WriteLine("{0}\n", result.Description);
                    Console.WriteLine("Calculating...");
                    Console.WriteLine("The solution: {0}\n", result.Run());
                }
            }
        } 
    }
}
