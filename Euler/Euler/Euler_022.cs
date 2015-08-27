using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_022
    {
        void Main()
        {
            List<string> names = new List<string>();
            string line = null;
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\COLVINM\\Documents\\LINQPad Queries\\p022_names.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("Splitting");
                        names = line.Split(',').ToList();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            List<string> alphabetical = names.OrderBy(x => x).ToList();

            long finalSum = 0;
            for (int i = 0; i < alphabetical.Count; i++)
            {
                int charSum = 0;
                foreach (char ch in alphabetical[i])
                {
                    if (ch != '\"')
                    {
                        charSum += ((int)ch - 64);
                    }
                }

                long nameScore = (i + 1) * charSum;
                finalSum += nameScore;
            }
            Console.WriteLine(finalSum);
        }
    }
}
