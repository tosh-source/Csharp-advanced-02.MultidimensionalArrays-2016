using System;

class MatrixUI
{
    public static void Main(string[] args)
    { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/02.%20Multidimensional-Arrays/homework/06.%20Matrix%20class/README.md
      //video: https://www.youtube.com/watch?v=_I2BG4w1Iyc

        //define matrix
        int matrixHeight = 2;
        int matrixWidth = 2;

        Matrix firstMatrix = new Matrix(matrixHeight, matrixWidth);
        firstMatrix[0, 0] = 1;
        firstMatrix[1, 1] = -12;

        Matrix secondMatrix = new Matrix(matrixHeight, matrixWidth);
        secondMatrix[0, 1] = 2;
        secondMatrix[1, 1] = 24;

        //input
        Console.Write("Use predefined parameter for matrices? Y/n (n = enter new one): ");
        char userChoice = char.Parse(Console.ReadLine());

        if ((userChoice == 'N') || (userChoice == 'n'))
        {
            NewMatrices(ref matrixHeight, ref matrixWidth, out firstMatrix, out secondMatrix);
        }

        //calculate result and print
        Console.WriteLine("\n" + new string('*', 10) + "\n RESULT\n" + new string('*', 10) + "\n");

        Console.WriteLine("Adding Matrices..");
        Matrix addingMatrices = firstMatrix + secondMatrix;
        Console.WriteLine(addingMatrices.ToString());

        Console.WriteLine("Subtracting Matrices..");
        Matrix subtractingMatrices = firstMatrix - secondMatrix;
        Console.WriteLine(subtractingMatrices.ToString());

        Console.WriteLine("Multiplying Matrices..");
        Matrix multiplyingMatrices = firstMatrix * secondMatrix;
        Console.WriteLine(multiplyingMatrices.ToString());
    }

    private static void NewMatrices(ref int matrixHeight, ref int matrixWidth, out Matrix firstMatrix, out Matrix secondMatrix)
    {
        //matrices height
        Console.Write("\nNew Matrices size..\n\n" + "matrices height: ");
        matrixHeight = int.Parse(Console.ReadLine());
        //matrices width
        Console.Write("matrices width: ");
        matrixWidth = int.Parse(Console.ReadLine());
        Console.WriteLine(); //NewLine

        //change matrices values
        firstMatrix = new Matrix(matrixHeight, matrixWidth);
        Console.WriteLine("Enter values for first Matrix..");
        parseNewValues(matrixHeight, matrixWidth, firstMatrix);

        Console.WriteLine("Enter values for second Matrix..");
        secondMatrix = new Matrix(matrixHeight, matrixWidth);
        parseNewValues(matrixHeight, matrixWidth, secondMatrix);

    }

    private static void parseNewValues(int matrixHeight, int matrixWidth, Matrix newMatrix)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        for (int rowInput = 0; rowInput < matrixHeight; rowInput++)
        {
            for (int colInput = 0; colInput < matrixWidth; colInput++)
            {
                Console.Write("matrix[{0},{1}] = ", rowInput, colInput);
                newMatrix[rowInput, colInput] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }

        Console.ResetColor();
    }
}
