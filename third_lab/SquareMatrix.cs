using System;
using System.Collections.Generic;
using System.Linq;

namespace third_lab;

class SquareMatrix
{

    public int this[int row, int col]
    {
        get
        {
            return matrix[row, col];
        }
        set
        {
            matrix[row, col] = value;
        }
    }
    private int size;
    private int[,] matrix;

    public SquareMatrix(int size)
    {
        this.size = size;
        matrix = new int[size, size];
    }

    public SquareMatrix(int size, int minValue, int maxValue)
    {
        this.size = size;
        matrix = new int[size, size];
        Random random = new Random();
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = random.Next(minValue, maxValue);
            }
        }
    }

    public static SquareMatrix RandomMatrix(int size, double min, double max)
    {
        var random = new Random();
        var matrix = new SquareMatrix(size);

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = (int)(min + (max - min) * random.NextDouble());
            }
        }

        return matrix;
    }

    public SquareMatrix(int[,] matrix)
    {
        size = matrix.GetLength(0);
        this.matrix = new int[size, size];
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                this.matrix[row, col] = matrix[row, col];
            }
        }
    }

    public static SquareMatrix operator +(SquareMatrix matrix1, SquareMatrix matrix2)
    {
        if (matrix1.size != matrix2.size)
        {
            throw new MatrixOperationException("Cannot add matrices of different sizes");
        }

        SquareMatrix result = new SquareMatrix(matrix1.size);
        for (int row = 0; row < result.size; row++)
        {
            for (int col = 0; col < result.size; col++)
            {
                result.matrix[row, col] = matrix1.matrix[row, col] + matrix2.matrix[row, col];
            }
        }
        return result;
    }

    public static SquareMatrix operator *(SquareMatrix matrix1, SquareMatrix matrix2)
    {
        if (matrix1.size != matrix2.size)
        {
            throw new MatrixOperationException("Cannot multiply matrices of different sizes");
        }

        SquareMatrix result = new SquareMatrix(matrix1.size);
        for (int row = 0; row < result.size; row++)
        {
            for (int col = 0; col < result.size; col++)
            {
                int sum = 0;
                for (int k = 0; k < result.size; k++)
                {
                    sum += matrix1.matrix[row, k] * matrix2.matrix[k, col];
                }
                result.matrix[row, col] = sum;
            }
        }
        return result;
    }

    public static bool operator >(SquareMatrix matrix1, SquareMatrix matrix2)
    {
        if (matrix1.size != matrix2.size)
        {
            throw new MatrixOperationException("Cannot compare matrices of different sizes");
        }

        for (int row = 0; row < matrix1.size; row++)
        {
            for (int col = 0; col < matrix1.size; col++)
            {
                if (matrix1.matrix[row, col] <= matrix2.matrix[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator <(SquareMatrix matrix1, SquareMatrix matrix2)
    {
        if (matrix1.size != matrix2.size)
        {
            throw new MatrixOperationException("Cannot compare matrices of different sizes");
        }

        for (int row = 0; row < matrix1.size; row++)
        {
            for (int col = 0; col < matrix1.size; col++)
            {
                if (matrix1.matrix[row, col] >= matrix2.matrix[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator >=(SquareMatrix matrix1, SquareMatrix matrix2)
    {
        if (matrix1.size != matrix2.size)
        {
            throw new MatrixOperationException("Cannot compare matrices of different sizes");
        }

        for (int row = 0; row < matrix1.size; row++)
        {
            for (int col = 0; col < matrix1.size; col++)
            {
                if (matrix1.matrix[row, col] < matrix2.matrix[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator <=(SquareMatrix matrix1, SquareMatrix matrix2)
    {
        if (matrix1.size != matrix2.size)
        {
            throw new MatrixOperationException("Cannot compare matrices of different sizes");
        }

        for (int row = 0; row < matrix1.size; row++)
        {
            for (int col = 0; col < matrix1.size; col++)
            {
                if (matrix1.matrix[row, col] > matrix2.matrix[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator ==(SquareMatrix matrix1, SquareMatrix matrix2)
    {
        if (matrix1.size != matrix2.size)
        {
            return false;
        }

        for (int row = 0; row < matrix1.size; row++)
        {
            for (int col = 0; col < matrix1.size; col++)
            {
                if (matrix1.matrix[row, col] != matrix2.matrix[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(SquareMatrix matrix1, SquareMatrix matrix2)
    {
        return !(matrix1 == matrix2);
    }

    public static explicit operator int(SquareMatrix matrix)
    {
        if (matrix.size != 1)
        {
            throw new MatrixOperationException("Cannot convert matrix to integer");
        }

        return matrix.matrix[0, 0];
    }

    public static implicit operator bool(SquareMatrix matrix)
    {
        for (int row = 0; row < matrix.size; row++)
        {
            for (int col = 0; col < matrix.size; col++)
            {
                if (matrix.matrix[row, col] != 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override string ToString()
    {
        string result = "";
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                result += matrix[row, col] + " ";
            }
            result += "\n";
        }
        return result;
    }

    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 1;
        }

        SquareMatrix otherMatrix = obj as SquareMatrix;
        if (otherMatrix != null)
        {
            if (this > otherMatrix)
            {
                return 1;
            }
            else if (this < otherMatrix)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            throw new ArgumentException("Object is not a SquareMatrix");
        }
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is SquareMatrix))
        {
            return false;
        }

        SquareMatrix otherMatrix = (SquareMatrix)obj;
        return this == otherMatrix;
    }

    public override int GetHashCode()
    {
        int result = 17;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                result = result * 31 + matrix[row, col].GetHashCode();
            }
        }
        return result;
    }

    public SquareMatrix DeepCopy()
    {
        SquareMatrix copy = new SquareMatrix(size);
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                copy.matrix[row, col] = matrix[row, col];
            }
        }
        return copy;
    }

    public double Determinant()
    {
        if (size == 1)
        {
            return matrix[0, 0];
        }
        else if (size == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        else
        {
            double result = 0;
            for (int row = 0; row < size; row++)
            {
                SquareMatrix minor = new SquareMatrix(size - 1);
                for (int col = 1; col < size; col++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if (k < row)
                        {
                            minor.matrix[col - 1, k] = matrix[col, k];
                        }
                        else if (k > row)
                        {
                            minor.matrix[col - 1, k - 1] = matrix[col, k];
                        }
                    }
                }
                double sign = (row % 2 == 0) ? 1 : -1;
                result += sign * matrix[0, row] * minor.Determinant();
            }
            return result;
        }
    }

    public SquareMatrix Inverse()
    {
        double determinant = Determinant();
        if (determinant == 0)
        {
            throw new MatrixOperationException("Cannot invert matrix with determinant 0");
        }

        SquareMatrix result = new SquareMatrix(size);
        if (size == 1)
        {
            result.matrix[0, 0] = 1 / matrix[0, 0];
        }
        else
        {
            int sign = 1;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    SquareMatrix minor = new SquareMatrix(size - 1);
                    for (int NewRow = 0; NewRow < size; NewRow++)
                    {
                        if (NewRow != row)
                        {
                            for (int NewCol = 1; NewCol < size; NewCol++)
                            {
                                if (NewCol < col)
                                {
                                    minor.matrix[NewRow < row ? NewRow : NewRow - 1, NewCol - 1] = matrix[NewRow, NewCol];
                                }
                                else if (NewCol > col)
                                {
                                    minor.matrix[NewRow < row ? NewRow : NewRow - 1, NewCol - 2] = matrix[NewRow, NewCol];
                                }
                            }
                        }
                    }
                    result.matrix[col, row] = (int)(sign * minor.Determinant() / determinant);
                    sign = -sign;
                }
                if (size % 2 == 0)
                {
                    sign = -sign;
                }
            }
        }
        return result;
    }
}
