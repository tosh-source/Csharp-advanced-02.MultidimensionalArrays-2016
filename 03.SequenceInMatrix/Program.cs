using System;


namespace _03.SequenceInMatrix
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/02.%20Multidimensional-Arrays/homework/03.%20Sequence%20in%20matrix/README.md
            //input and values
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);  //rows
            int m = int.Parse(input[1]);  //cols

            string[,] MasterMatrix = new string[n, m]; //create Master Matrix from user's values
            for (int row = 0; row < n; row++)
            {
                string[] tempStr = Console.ReadLine().Split(' ');
                for (int col = 0; col < m; col++)
                {
                    MasterMatrix[row, col] = tempStr[col];
                }
            }

            int[,] longestSequenceMatrix = new int[n, m]; //this matrix will keep only the number of equal elements. This is "dynamic programing" technique. See: 01.Arrays\18.RemoveElementsFromArray
            for (int row = 0; row < n; row++) //define all element with value "1"
            {
                for (int col = 0; col < m; col++)
                {
                    longestSequenceMatrix[row, col] = 1;
                }
            }

            //calculation
            MasterMatrixCalculation(n, m, MasterMatrix, longestSequenceMatrix);
            //print
            int result = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (result < longestSequenceMatrix[row, col])
                    {
                        result = longestSequenceMatrix[row, col];
                    }
                }
            }
            Console.WriteLine(result);
        }

        static void MasterMatrixCalculation(int n, int m, string[,] MasterMatrix, int[,] longestSequenceMatrix)
        {
            //matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    //create a sub matrix for check each element of master matrix
                    //top side
                    for (int top = 0; top < 3; top++)
                    {
                        if (((row - 1) < 0) || (((col - 1) + top < 0) || (((col - 1) + top) > m - 1)))
                        {
                            continue;
                        }
                        else
                        {
                            if (MasterMatrix[(row - 1), ((col - 1) + top)] == MasterMatrix[row, col])
                            {
                                longestSequenceMatrix[row, col] += longestSequenceMatrix[(row - 1), ((col - 1) + top)];
                                longestSequenceMatrix[(row - 1), ((col - 1) + top)] = 0;
                            }
                        }
                    }
                    //right side
                    if (!((col + 1) > m - 1))
                    {
                        if (MasterMatrix[row, (col + 1)] == MasterMatrix[row, col])
                        {
                            longestSequenceMatrix[row, col] += longestSequenceMatrix[row, (col + 1)];
                            longestSequenceMatrix[row, (col + 1)] = 0;
                        }
                    }
                    //left side
                    if (!((col - 1) < 0))
                    {
                        if (MasterMatrix[row, (col - 1)] == MasterMatrix[row, col])
                        {
                            longestSequenceMatrix[row, col] += longestSequenceMatrix[row, (col - 1)];
                            longestSequenceMatrix[row, (col - 1)] = 0;
                        }
                    }
                    //bottom side
                    for (int bottom = 0; bottom < 3; bottom++)
                    {
                        if (((row + 1) > n - 1) || (((col - 1) + bottom < 0) || (((col - 1) + bottom) > m - 1)))
                        {
                            continue;
                        }
                        else
                        {
                            if (MasterMatrix[(row + 1), ((col - 1) + bottom)] == MasterMatrix[row, col])
                            {
                                longestSequenceMatrix[row, col] += longestSequenceMatrix[(row + 1), ((col - 1) + bottom)];
                                longestSequenceMatrix[(row + 1), ((col - 1) + bottom)] = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
