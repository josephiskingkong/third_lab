using System;
using System.Collections.Generic;
using System.Linq;

namespace third_lab;

class SquareMatrix
{

    public double this[int RowIndex, int ColumnIndex]
    {
        get
        {
            return Matrix[RowIndex, ColumnIndex];
        }
        set
        {
            Matrix[RowIndex, ColumnIndex] = value;
        }
    }
    private int Size;
    private double[,] Matrix;

    public SquareMatrix(int Size)
    {
        this.Size = Size;
        Matrix = new double[Size, Size];
    }

    public SquareMatrix(int Size, int MinValue, int MaxValue)
    {
        this.Size = Size;
        Matrix = new double[Size, Size];
        Random random = new Random();
        for (int RowIndex = 0; RowIndex < Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Size; ColumnIndex++)
            {
                Matrix[RowIndex, ColumnIndex] = random.Next(MinValue, MaxValue);
            }
        }
    }

    public SquareMatrix(int[,] Matrix)
    {
        Size = Matrix.GetLength(0);
        this.Matrix = new double[Size, Size];
        for (int RowIndex = 0; RowIndex < Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Size; ColumnIndex++)
            {
                this.Matrix[RowIndex, ColumnIndex] = Matrix[RowIndex, ColumnIndex];
            }
        }
    }

    public static SquareMatrix operator +(SquareMatrix Matrix1, SquareMatrix Matrix2)
    {
        if (Matrix1.Size != Matrix2.Size)
        {
            throw new MatrixOperationException("Cannot add matrices of different Sizes");
        }

        SquareMatrix Result = new SquareMatrix(Matrix1.Size);
        for (int RowIndex = 0; RowIndex < Result.Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Result.Size; ColumnIndex++)
            {
                Result.Matrix[RowIndex, ColumnIndex] = Matrix1.Matrix[RowIndex, ColumnIndex] + Matrix2.Matrix[RowIndex, ColumnIndex];
            }
        }
        return Result;
    }

    public static SquareMatrix operator *(SquareMatrix Matrix1, SquareMatrix Matrix2)
    {
        if (Matrix1.Size != Matrix2.Size)
        {
            throw new MatrixOperationException("Cannot multiply matrices of different Sizes");
        }

        SquareMatrix Result = new SquareMatrix(Matrix1.Size);
        for (int RowIndex = 0; RowIndex < Result.Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Result.Size; ColumnIndex++)
            {
                double Summ = 0;
                for (int ResultIndex = 0; ResultIndex < Result.Size; ResultIndex++)
                {
                    Summ += Matrix1.Matrix[RowIndex, ResultIndex] * Matrix2.Matrix[ResultIndex, ColumnIndex];
                }
                Result.Matrix[RowIndex, ColumnIndex] = Summ;
            }
        }
        return Result;
    }

    public static bool operator >(SquareMatrix Matrix1, SquareMatrix Matrix2)
    {
        if (Matrix1.Size != Matrix2.Size)
        {
            throw new MatrixOperationException("Cannot compare matrices of different Sizes");
        }

        for (int RowIndex = 0; RowIndex < Matrix1.Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix1.Size; ColumnIndex++)
            {
                if (Matrix1.Matrix[RowIndex, ColumnIndex] <= Matrix2.Matrix[RowIndex, ColumnIndex])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator <(SquareMatrix Matrix1, SquareMatrix Matrix2)
    {
        if (Matrix1.Size != Matrix2.Size)
        {
            throw new MatrixOperationException("Cannot compare matrices of different Sizes");
        }

        for (int RowIndex = 0; RowIndex < Matrix1.Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix1.Size; ColumnIndex++)
            {
                if (Matrix1.Matrix[RowIndex, ColumnIndex] >= Matrix2.Matrix[RowIndex, ColumnIndex])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator >=(SquareMatrix Matrix1, SquareMatrix Matrix2)
    {
        if (Matrix1.Size != Matrix2.Size)
        {
            throw new MatrixOperationException("Cannot compare matrices of different Sizes");
        }

        for (int RowIndex = 0; RowIndex < Matrix1.Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix1.Size; ColumnIndex++)
            {
                if (Matrix1.Matrix[RowIndex, ColumnIndex] < Matrix2.Matrix[RowIndex, ColumnIndex])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator <=(SquareMatrix Matrix1, SquareMatrix Matrix2)
    {
        if (Matrix1.Size != Matrix2.Size)
        {
            throw new MatrixOperationException("Cannot compare matrices of different Sizes");
        }

        for (int RowIndex = 0; RowIndex < Matrix1.Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix1.Size; ColumnIndex++)
            {
                if (Matrix1.Matrix[RowIndex, ColumnIndex] > Matrix2.Matrix[RowIndex, ColumnIndex])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator ==(SquareMatrix Matrix1, SquareMatrix Matrix2)
    {
        if (Matrix1.Size != Matrix2.Size)
        {
            return false;
        }

        for (int RowIndex = 0; RowIndex < Matrix1.Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix1.Size; ColumnIndex++)
            {
                if (Matrix1.Matrix[RowIndex, ColumnIndex] != Matrix2.Matrix[RowIndex, ColumnIndex])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(SquareMatrix Matrix1, SquareMatrix Matrix2)
    {
        return !(Matrix1 == Matrix2);
    }

    public static explicit operator double(SquareMatrix Matrix)
    {
        if (Matrix.Size != 1)
        {
            throw new MatrixOperationException("Cannot convert matrix to integer");
        }

        return Matrix.Matrix[0, 0];
    }

    public static implicit operator bool(SquareMatrix Matrix)
    {
        for (int RowIndex = 0; RowIndex < Matrix.Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix.Size; ColumnIndex++)
            {
                if (Matrix.Matrix[RowIndex, ColumnIndex] != 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override string ToString()
    {
        string Result = "";
        for (int RowIndex = 0; RowIndex < Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Size; ColumnIndex++)
            {
                Result += Matrix[RowIndex, ColumnIndex] + " ";
            }
            Result += "\n";
        }
        return Result;
    }

    public int CompareTo(object Obj)
    {
        if (Obj == null)
        {
            return 1;
        }

        SquareMatrix OtherMatrix = Obj as SquareMatrix;
        if (OtherMatrix != null)
        {
            if (this > OtherMatrix)
            {
                return 1;
            }
            else if (this < OtherMatrix)
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

    public override bool Equals(object Obj)
    {
        if (Obj == null || !(Obj is SquareMatrix))
        {
            return false;
        }

        SquareMatrix OtherMatrix = (SquareMatrix)Obj;
        return this == OtherMatrix;
    }

    public override int GetHashCode()
    {
        int Result = 17;
        for (int RowIndex = 0; RowIndex < Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Size; ColumnIndex++)
            {
                Result = Result * 31 + Matrix[RowIndex, ColumnIndex].GetHashCode();
            }
        }
        return Result;
    }

    public SquareMatrix DeepCopy()
    {
        SquareMatrix Copy = new SquareMatrix(Size);
        for (int RowIndex = 0; RowIndex < Size; RowIndex++)
        {
            for (int ColumnIndex = 0; ColumnIndex < Size; ColumnIndex++)
            {
                Copy.Matrix[RowIndex, ColumnIndex] = Matrix[RowIndex, ColumnIndex];
            }
        }
        return Copy;
    }

    public double Determinant()
    {
        if (Size == 1)
        {
            return Matrix[0, 0];
        }
        else if (Size == 2)
        {
            return Matrix[0, 0] * Matrix[1, 1] - Matrix[0, 1] * Matrix[1, 0];
        }
        else
        {
            double Result = 0;
            for (int RowIndex = 0; RowIndex < Size; RowIndex++)
            {
                SquareMatrix Minor = new SquareMatrix(Size - 1);
                for (int ColumnIndex = 1; ColumnIndex < Size; ColumnIndex++)
                {
                    for (int MinorIndex = 0; MinorIndex < Size; MinorIndex++)
                    {
                        if (MinorIndex < RowIndex)
                        {
                            Minor.Matrix[ColumnIndex - 1, MinorIndex] = Matrix[ColumnIndex, MinorIndex];
                        }
                        else if (MinorIndex > RowIndex)
                        {
                            Minor.Matrix[ColumnIndex - 1, MinorIndex - 1] = Matrix[ColumnIndex, MinorIndex];
                        }
                    }
                }
                double Sign = (RowIndex % 2 == 0) ? 1 : -1;
                Result += Sign * Matrix[0, RowIndex] * Minor.Determinant();
            }
            return Result;
        }
    }

    public SquareMatrix Inverse()
    {
        double Determinant = this.Determinant();
        if (Determinant == 0)
        {
            throw new MatrixOperationException("Cannot invert matrix with determinant 0");
        }

        SquareMatrix Result = new SquareMatrix(Size);
        if (Size == 1)
        {
            Result.Matrix[0, 0] = 1 / Matrix[0, 0];
        }
        else
        {
            int Sign = 1;
            for (int RowIndex = 0; RowIndex < Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Size; ++ColumnIndex)
                {
                    SquareMatrix Minor = new SquareMatrix(Size - 1);
                    for (int MinorRow = 0; MinorRow < Size - 1; ++MinorRow)
                    {
                        if (MinorRow < RowIndex)
                        {
                            for (int MinorColumn = 0; MinorColumn < Size - 1; ++MinorColumn)
                            {
                                if (MinorColumn < ColumnIndex)
                                {
                                    Minor.Matrix[MinorRow, MinorColumn] = Matrix[MinorRow, MinorColumn];
                                }
                                else
                                {
                                    Minor.Matrix[MinorRow, MinorColumn] = Matrix[MinorRow, MinorColumn + 1];
                                }
                            }
                        }
                        else
                        {
                            for (int NewCol = 0; NewCol < Size - 1; ++NewCol)
                            {
                                if (NewCol < ColumnIndex)
                                {
                                    Minor.Matrix[MinorRow, NewCol] = Matrix[MinorRow + 1, NewCol];
                                }
                                else
                                {
                                    Minor.Matrix[MinorRow, NewCol] = Matrix[MinorRow + 1, NewCol + 1];
                                }
                            }
                        }
                    }
                    Result.Matrix[RowIndex, ColumnIndex] = Sign * Minor.Determinant() / Determinant;
                    Sign = -Sign;
                }
                if (Size % 2 == 0)
                {
                    Sign = -Sign;
                }
            }
        }
        return Result;
    }

}
