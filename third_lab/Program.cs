using System;

namespace third_lab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SquareMatrix MatrixA = new SquareMatrix(4, 1, 100);
            Console.WriteLine("Matrix A:\n" + MatrixA.ToString());

            SquareMatrix MatrixB = new SquareMatrix(4, 1, 100);
            Console.WriteLine("Matrix B:\n" + MatrixB.ToString());

            SquareMatrix MatrixC = MatrixA + MatrixB;
            Console.WriteLine("Matrix C = A + B:\n" + MatrixC.ToString());

            SquareMatrix MatrixD = MatrixA * MatrixB;
            Console.WriteLine("Matrix D = A * B:\n" + MatrixD.ToString());

            bool Equal = (MatrixA == MatrixB);
            Console.WriteLine("A == B: " + Equal);

            bool NotEqual = (MatrixA != MatrixB);
            Console.WriteLine("A != B: " + NotEqual);

            bool GreaterThan = (MatrixA > MatrixB);
            Console.WriteLine("A > B: " + GreaterThan);

            bool LessThan = (MatrixA < MatrixB);
            Console.WriteLine("A < B: " + LessThan);

            bool GreaterOrEqual = (MatrixA >= MatrixB);
            Console.WriteLine("A >= B: " + GreaterOrEqual);

            bool LessOrEqual = (MatrixA <= MatrixB);
            Console.WriteLine("A <= B: " + LessOrEqual);

            SquareMatrix MatrixE = (SquareMatrix)MatrixA.DeepCopy();
            Console.WriteLine("\nMatrix E (deep copy of A):\n" + MatrixA.ToString());

            double DeterminantA = MatrixA.Determinant();
            Console.WriteLine("Determinant of A: " + DeterminantA);

            SquareMatrix InverseMatrixA = MatrixA.Inverse();
            Console.WriteLine("Inverse of A:\n" + InverseMatrixA.ToString());

            double DeterminantInverseA = InverseMatrixA.Determinant();
            Console.WriteLine("Determinant of inverse of A: " + DeterminantInverseA);
        }
        catch (MatrixOperationException e)
        {
            Console.WriteLine("Matrix operation error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        Console.ReadKey();
    }
}
