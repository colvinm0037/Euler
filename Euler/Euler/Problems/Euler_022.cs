using Euler.Euler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_022 : IEulerProblem
    {
        private string _description = "Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score." +
                                      "\n\nFor example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714." +
                                      "\n\nWhat is the total of all the name scores in the file?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 22; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            // TODO: Fix file path hardcoding, add text file to project

            List<string> names = new List<string>();
            string line = null;
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\COLVINM\\Documents\\LINQPad Queries\\p022_names.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {                        
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
            return finalSum.ToString();
        }        
    }
}
