using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Challenges
{
    class Challenge_Week_6_Level_1
    {
        int[][] pyramid = new int[][] 
	    {
		    new int[] {75},
		    new int[] {-95,64},
		    new int[] {17,-47,-82},
		    new int[] {-18,35,-87,10},
		    new int[] {20,-04,82,-47,65},
		    new int[] {-19,01,-23,-75,03,-34},
		    new int[] {88,-02,-77,-73,07,-63,67},
		    new int[] {-99,65,04,-28,06,16,-70,-92},
		    new int[] {41,-41,-26,56,-83,40,80,-70,-33},
		    new int[] {-41,48,-72,-33,-47,32,-37,16,-94,29},
		    new int[] {53,-71,-44,65,-25,43,91,-52,97,-51,14},
		    new int[] {70,-11,-33,-28,77,73,-17,78,39,-68,17,-57},
		    new int[] {-91,71,-52,-38,17,-14,91,-43,58,-50,27,-29,-48},
		    new int[] {-63,-66,-04,68,89,-53,67,-30,73,-16,-69,87,-40,31},
		    new int[] {-04,62,-98,27,-23,-09,70,-98,-73,93,-38,53,-60,-04,-23}
	    };

        void Main()
        {
            int minSum = 0;
            int totalRows = 15;
            int[,] subtriangles = new int[15, 15];
            for (int numberOfRows = 1; numberOfRows <= totalRows; numberOfRows++)
            {
                // We count every sub-triangle of this size starting from the top of the sub-triangle
                for (int row = 0; row < (totalRows + 1) - numberOfRows; row++) // The starting row of the sub-triangle
                {
                    for (int column = 0; column <= row; column++) // The starting column of the sub-triangle
                    {
                        int sum = 0;

                        sum += subtriangles[row, column];
                        sum += SumRow(row, column, numberOfRows); // add the last row													

                        subtriangles[row, column] = sum;
                        if (sum < minSum)
                            minSum = sum;
                    }
                }
            }

            Console.WriteLine("Min: " + minSum);
        }

        int SumRow2(int row, int column, int itemsInRow)
        {
            int sum = 0;
            for (int i = 0; i < itemsInRow; i++)
                sum += pyramid[row + (itemsInRow - 1)][column + i];
            return sum;
        }

        int SumRow(int row, int column, int itemsInRow)
        {
            //Console.WriteLine ("Starting SumRow, row: " + row + ", column: " + column + ", itemsInRow " + itemsInRow);
            int sum = 0;

            if (itemsInRow < 500)
            {
                for (int i = 0; i < itemsInRow; i++)
                    sum += pyramid[row + (itemsInRow - 1)][column + i];
            }
            else
            {
                // Take sum of entire row
                sum = pyramid[row].Sum();

                // remove columns before start
                for (int i = 0; i < column; i++)
                    sum -= pyramid[row + (itemsInRow - 1)][i];

                // remove columns after end

                for (int i = column + itemsInRow; i < pyramid[row].Count(); i++)
                    sum -= pyramid[row + (itemsInRow - 1)][i];
            }

            return sum;
        }
    }
}
