using Xunit;
namespace third_lab;

public class SquareMatrixTests
{
    [Fact]
    public void Constructor_WithSize_CreatesMatrixOfCorrectSize()
    {
        var Matrix = new SquareMatrix(5);
        Assert.Equal(5, Matrix.Size);
    }

    [Fact]
    public void AdditionOperator_WithEqualSizeMatrices_ReturnsCorrectResult()
    {
        var Matrix1 = new SquareMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var Matrix2 = new SquareMatrix(new int[,] { { 5, 6 }, { 7, 8 } });
        var Result = Matrix1 + Matrix2;

        Assert.Equal(new double[,] { { 6, 8 }, { 10, 12 } }, Result.Matrix);
    }

    [Fact]
    public void AdditionOperator_WithDifferentSizeMatrices_ThrowsMatrixOperationException()
    {
        var Matrix1 = new SquareMatrix(2);
        var Matrix2 = new SquareMatrix(3);

        Assert.Throws<MatrixOperationException>(() => Matrix1 + Matrix2);
    }

    [Fact]
    public void MultiplicationOperator_WithEqualSizeMatrices_ReturnsCorrectResult()
    {
        var Matrix1 = new SquareMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var Matrix2 = new SquareMatrix(new int[,] { { 5, 6 }, { 7, 8 } });
        var Result = Matrix1 * Matrix2;

        Assert.Equal(new double[,] { { 19, 22 }, { 43, 50 } }, Result.Matrix);
    }

    [Fact]
    public void MultiplicationOperator_WithDifferentSizeMatrices_ThrowsMatrixOperationException()
    {
        var Matrix1 = new SquareMatrix(2);
        var Matrix2 = new SquareMatrix(3);

        Assert.Throws<MatrixOperationException>(() => Matrix1 * Matrix2);
    }

    [Fact]
    public void Determinant_WithSizeOne_ReturnsCorrectResult()
    {
        var Matrix = new SquareMatrix(new int[,] { { 5 } });
        var Result = Matrix.Determinant();

        Assert.Equal(5, Result);
    }

    [Fact]
    public void Determinant_WithSizeTwo_ReturnsCorrectResult()
    {
        var Matrix = new SquareMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var Result = Matrix.Determinant();

        Assert.Equal(-2, Result);
    }

    [Fact]
    public void Inverse_WithInvertibleMatrix_ReturnsCorrectResult()
    {
        var Matrix = new SquareMatrix(new int[,] { { 4, 7 }, { 2, 6 } });
        var Result = Matrix.Inverse();

        Assert.Equal(new double[,] { { 0.6, -0.7 }, { -0.2, 0.4 } }, Result.Matrix);
    }

    [Fact]
    public void Inverse_WithNonInvertibleMatrix_ThrowsMatrixOperationException()
    {
        var Matrix = new SquareMatrix(new int[,] { { 2, 4 }, { 1, 2 } });

        Assert.Throws<MatrixOperationException>(() => Matrix.Inverse());
    }
}
