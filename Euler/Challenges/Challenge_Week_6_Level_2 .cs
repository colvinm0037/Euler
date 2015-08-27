using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Challenges
{
    class Challenge_Week_6_Level_2
    {
        public long[][] pyramid = new long[1000][];

        void Main()
        {
            BuildPyramid(); // Build all of the pseudorandom numbers

            long minSum = 0;
            int totalRows = 1000;
            long[,] subtriangles = new long[totalRows, totalRows];
            long[,] oddRowSums = new long[totalRows, totalRows];
            long[,] evenRowSums = new long[totalRows, totalRows];

            // every triangle is just an old triangle with an additional row added to the bottom
            // keeping track of previous triangles then using those to count the new triangle	
            for (int numberOfRows = 1; numberOfRows <= totalRows; numberOfRows++)
            {
                for (int row = 0; row < (totalRows + 1) - numberOfRows; row++) // The starting row of the sub-triangle
                {
                    for (int column = 0; column <= row; column++) // The starting column of the top of sub-triangle
                    {
                        long sum = 0;
                        int localRow = row + numberOfRows - 1;

                        if (numberOfRows == 1)
                        {
                            sum += pyramid[row][column];
                            evenRowSums[row, column] = pyramid[row][column];
                            oddRowSums[row, column] = pyramid[row][column];
                        }
                        else
                            sum += subtriangles[row, column]; // Top portion of triangle already calculated

                        long rowSum = 0;
                        if (numberOfRows % 2 == 0)
                        {
                            if (numberOfRows == 2)
                                rowSum = evenRowSums[localRow, column] + pyramid[localRow][column + 1];
                            else
                                rowSum = evenRowSums[localRow, column + 1] + pyramid[localRow][column + numberOfRows - 1] + pyramid[localRow][column];
                            evenRowSums[localRow, column] = rowSum;
                        }
                        else if (numberOfRows > 1)
                        {
                            rowSum = oddRowSums[localRow, column + ((numberOfRows - 1) / 2)] + pyramid[localRow][column + numberOfRows - 1] + pyramid[localRow][column];
                            oddRowSums[localRow, column + ((numberOfRows - 1) / 2)] = rowSum;
                        }

                        sum += rowSum;
                        subtriangles[row, column] = sum; // Save this triangle
                        if (sum < minSum) minSum = sum;
                    }
                }
            }

            Console.WriteLine("Min: " + minSum);
        }

        void BuildPyramid()
        {
            long t = 0;
            long modulos = (long)Math.Pow(2, 20);
            long sub = (long)Math.Pow(2, 19);

            // Compute all of the values
            List<long> values = new List<long>();
            for (int k = 1; k <= 500500; k++)
            {
                t = (615949 * t + 797807) % modulos;
                values.Add(t - sub);
            }

            // Group the values into seperate arrays for each row in the triangle
            int count = 0;
            for (int i = 1; i <= 1000; i++)
            {
                long[] row = new long[i];
                for (int k = 0; k < i; k++)
                {
                    row[k] = values[count];
                    count++;
                }
                pyramid[i - 1] = row;
            }
        }
    }
}
