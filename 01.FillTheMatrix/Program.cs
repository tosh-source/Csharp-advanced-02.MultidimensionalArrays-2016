using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillTheMatrix
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/02.%20Multidimensional-Arrays/homework/01.%20Fill%20the%20matrix/README.md
            //input
            int matrixSize = int.Parse(Console.ReadLine());
            char matrixType = char.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            int counter = 1;
            //matrix type 'a', calculation
            if (matrixType == 'a')
            {
                for (int col = 0; col <= matrixSize - 1; col++)
                {
                    for (int row = 0; row <= matrixSize - 1; row++, counter++)
                    {
                        matrix[row, col] = counter;
                    }
                }
            }
            else if (matrixType == 'b') //matrix type 'b', calculation
            {
                for (int col = 0; col <= matrixSize - 1; col++)
                {
                    for (int row = 0; row <= matrixSize - 1; row++, counter++)
                    {
                        if ((col % 2) == 0)
                        {
                            matrix[row, col] = counter;
                        }
                        else
                        {
                            matrix[row, col] = counter + (matrixSize - (row * 2) - 1);  //"counter + (matrixSize - (row * 2) - 1)" is equal to ==> counter-- (started from DOUBLED last one counter++)
                        }
                    }

                }
            }
            else if (matrixType == 'c') //matrix type "c" (diagonal matrix), calculation 
            {
                DiagonalMatrix(matrix, matrixSize, counter);
            }
            else if (matrixType == 'd') //matrix type 'd' (spiral matrix), calculation
            {
                SpiralMatrixCalc(matrix, matrixSize, counter);
            }
            //print
            for (int row = 0; row <= matrixSize - 1; row++)
            {
                for (int col = 0; col <= matrixSize - 1; col++)
                {
                    
                    if (col == (matrixSize - 1)) //last element without spacing 
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else //any other element, separated with spacing
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void DiagonalMatrix(int[,] matrix, int matrixSize, int counter)
        {
            //first half of diagonal matrix
            for (int reversedRow = matrixSize - 1; reversedRow >= 0; reversedRow--)
            {
                for (int col = 0; col < (matrixSize - reversedRow); col++, counter++)
                {
                    if (col == 0)
                    {
                        matrix[reversedRow, col] = counter;
                    }
                    else
                    {
                        matrix[(reversedRow + col), col] = counter;
                    }
                }
            }
            //second half of diagonal matrix
            for (int col = 1; col <= matrixSize - 1; col++)
            {
                for (int row = 0; row < (matrixSize - col); row++, counter++)
                {
                    if (row == 0)
                    {
                        matrix[row, col] = counter;
                    }
                    else
                    {
                        matrix[row, (col + row)] = counter;
                    }
                }
            }
        }

        static void SpiralMatrixCalc(int[,] matrix, int matrixSize, int counter)
        {
            for (int depth = 0; depth <= (matrixSize / 2); depth++)
            {
                for (int down = depth; down <= matrixSize - depth - 1; down++, counter++)
                {
                    matrix[down, depth] = counter;
                }
                for (int right = depth + 1; right <= matrixSize - depth - 1; right++, counter++)
                {
                    matrix[(matrixSize - depth - 1), right] = counter;
                }
                for (int up = matrixSize - depth - 2; up > depth; up--, counter++)
                {
                    matrix[up, (matrixSize - depth - 1)] = counter;
                }
                for (int left = matrixSize - depth - 1; left > depth; left--, counter++)
                {
                    if (matrix[depth, left] == 0)
                    {
                        matrix[depth, left] = counter;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
