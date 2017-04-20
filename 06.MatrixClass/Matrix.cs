using System;

public class Matrix
{
    //field
    private int[,] matrix;

    //properties rows
    public int Rows
    {
        get //matrix.GetLength(0)
        {
            return this.matrix.GetLength(0);
        }
    }

    //properties cols
    public int Columns
    {
        get //matrix.GetLength(1)
        {
            return this.matrix.GetLength(1);
        }
    }

    //Constructor
    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }

    //Overload "operators for adding"
    public static Matrix operator +(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Columns);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] + second[row, col];
            }
        }

        return result;
    }
    //Overload "operators for subtracting"
    public static Matrix operator -(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Columns);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] - second[row, col];
            }
        }

        return result;
    }
    //Overload "operators for multiplying"
    public static Matrix operator *(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Columns);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] * second[row, col];
            }
        }

        return result;
    }

    //Define and overload "indexer for accessing the matrix content" (Дефениране/предефениране на индексатор)
    public int this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }

    //Overload ".ToString()" method
    public override string ToString()
    {
        string result = null;

        for (int row = 0; row < this.Rows; row++)  //this.Rows <==> this.matrix.GetLength(0)
        {
            for (int col = 0; col < this.Columns; col++)  //this.Columns <==> this.matrix.GetLength(1)
            {
                result += matrix[row, col] + " ";  //<==> Console.Write(matrix[row, col] + " ");

            }
            result += Environment.NewLine;  //<==> Console.WriteLine();
        }

        return result;
    }
}

