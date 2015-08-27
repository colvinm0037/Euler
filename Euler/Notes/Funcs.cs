using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Notes
{
    class Funcs
    {
        void Main()
        {
            Action<int> print = i => Console.WriteLine(i % 2 == 0);

            print(100);
            print(12345);
            print(12346);
            Console.WriteLine();

            Func<double, double> square = d => d * d;
            Func<double, double, double> add = (x, y) => x + y;
            Predicate<double> isLessThanTen = d => d < 10;

            Console.WriteLine(isLessThanTen(12));
            Console.WriteLine(isLessThanTen(2));
            Console.WriteLine(square(54));
            Console.WriteLine(add(3, 5));
        }
    }
}
