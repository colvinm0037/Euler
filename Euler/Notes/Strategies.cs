using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Notes
{
    class Strategies
    {
        void Main()
        {
            MethodOne m = new MethodOne();
            MethodTwo m2 = new MethodTwo();

            List<ITestStrategy> strategies = new List<ITestStrategy> { new MethodOne(), new MethodTwo(), new MethodThree() };
            foreach (var strategy in strategies)
                Console.WriteLine(strategy.GetNumber());
        }

        // Define other methods and classes here
        public interface ITestStrategy
        {
            int GetNumber();
        }

        public class MethodOne : ITestStrategy
        {
            public int GetNumber()
            {
                return 1;
            }
        }

        public class MethodTwo : ITestStrategy
        {
            public int GetNumber()
            {
                return 2;
            }
        }

        public class MethodThree : ITestStrategy
        {
            public int GetNumber()
            {
                return 3;
            }
        }
    }
}
