using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/02.%20Multidimensional-Arrays/homework/02.%20Maximal%20sum/README.md
            //1.input
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int[,] matrix = new int[n, m];
            //int[] tempArr = new int[n];
            int[,] subMatrix = new int[3, 3];

            for (int row = 0; row < n; row++)
            {
               int[] tempArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = tempArr[col];
                }
                Array.Clear(tempArr, 0, tempArr.Length);
            }
            //calculation
            int maxSum = int.MinValue;
            CalcMaximalSum(matrix, subMatrix, n, m, ref maxSum);
            //print
            Console.WriteLine(maxSum);
        }

        static void CalcMaximalSum(int[,] matrix, int[,] subMatrix, int n, int m, ref int maxSum)
        {
            int tempMaxSum = 0;
            //iterate through master matrix
            for (int row = 0; row < (n - 2); row++)
            {
                for (int col = 0; col < (m - 2); col++)
                {
                    //iterate through subMatrix
                    for (int subRow = row; subRow < (row + 3); subRow++)
                    {
                        for (int subCol = col; subCol < (col + 3); subCol++)
                        {
                            tempMaxSum += matrix[subRow, subCol];
                        }
                    }
                    //check maxSum
                    if (tempMaxSum > maxSum)
                    {
                        maxSum = tempMaxSum;
                    }
                    tempMaxSum = 0;
                }
            }
        }
    }
}
