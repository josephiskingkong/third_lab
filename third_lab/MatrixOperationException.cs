using System;
namespace third_lab;

class MatrixOperationException : Exception
{
    public MatrixOperationException(string message) : base(message)
    {
    }
}
