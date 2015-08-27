using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euler.Notes
{
    class Threads
    {
        static void Main()
        {
            Thread t = new Thread(WriteY); // Kick off a new thread
            t.Start(); // running WriteY()

            Thread z = new Thread(WriteZ); // Kick off a new thread
            z.Start(); // running WriteZ()

            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++) Console.Write("x");

            Console.WriteLine("Is t alive: " + t.IsAlive);
            Console.WriteLine("Is z alive: " + z.IsAlive);
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }

        static void WriteZ()
        {
            for (int i = 0; i < 1000; i++) Console.Write("z");
        }
    }
}
