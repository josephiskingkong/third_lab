using System;

namespace third_lab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SquareMatrix a = new SquareMatrix(3, 1, 10);
            Console.WriteLine("Matrix A:\n" + a.ToString());

            SquareMatrix b = new SquareMatrix(3, 1, 10);
            Console.WriteLine("Matrix B:\n" + b.ToString());

            SquareMatrix c = a + b;
            Console.WriteLine("Matrix C = A + B:\n" + c.ToString());

            SquareMatrix d = a * b;
            Console.WriteLine("Matrix D = A * B:\n" + d.ToString());

            bool equal = (a == b);
            Console.WriteLine("A == B: " + equal);

            bool notEqual = (a != b);
            Console.WriteLine("A != B: " + notEqual);

            bool greaterThan = (a > b);
            Console.WriteLine("A > B: " + greaterThan);

            bool lessThan = (a < b);
            Console.WriteLine("A < B: " + lessThan);

            bool greaterOrEqual = (a >= b);
            Console.WriteLine("A >= B: " + greaterOrEqual);

            bool lessOrEqual = (a <= b);
            Console.WriteLine("A <= B: " + lessOrEqual);

            SquareMatrix e = (SquareMatrix)a.DeepCopy();
            Console.WriteLine("Matrix E (deep copy of A):\n" + e.ToString());

            double determinantA = a.Determinant();
            Console.WriteLine("Determinant of A: " + determinantA);

            SquareMatrix inverseA = a.Inverse();
            Console.WriteLine("Inverse of A:\n" + inverseA.ToString());

            double determinantInverseA = inverseA.Determinant();
            Console.WriteLine("Determinant of inverse of A: " + determinantInverseA);
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
