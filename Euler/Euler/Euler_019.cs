using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_019
    {
        void Main()
        {
            // Count number of Sundays that occurred on 1st day of the month from 1901 - 2000
            int[] daysInMonth = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            int dayOfTheWeek = 1;
            int currentYear = 1;
            int numberOfSundays = 0;

            while (currentYear <= 100)
            {
                if (currentYear % 4 == 0 && currentYear % 400 != 0)
                    daysInMonth[2] = 29;
                else
                    daysInMonth[2] = 28;

                for (int month = 1; month <= 12; month++)
                {
                    for (int day = 1; day <= daysInMonth[month]; day++)
                    {
                        dayOfTheWeek++;
                        if (dayOfTheWeek % 7 == 0 && day == 1)
                        {
                            numberOfSundays++;
                            dayOfTheWeek = 0;
                        }
                    }
                }

                currentYear++;
            }

            Console.WriteLine(numberOfSundays);
        }
    }
}
