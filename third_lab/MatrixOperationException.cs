using System;
namespace third_lab;

class MatrixOperationException : Exception
{
    public MatrixOperationException(string Message) : base(Message)
    {
    }
}
