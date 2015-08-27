using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_019 : IEulerProblem
    {
        private string _description = "You are given the following information, but you may prefer to do some research for yourself." +
              "\n1 Jan 1900 was a Monday." +
              "\nThirty days has September," +
              "\nApril, June and November." +
              "\nAll the rest have thirty-one," +
              "\nSaving February alone," +
              "\nWhich has twenty-eight, rain or shine." +
              "\nAnd on leap years, twenty-nine." +
              "\nA leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400." +
              "\nHow many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 19; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
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

            return numberOfSundays.ToString();
        }       
    }
}
