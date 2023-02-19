namespace Geometry.Exceptions;

public class InvalidTriangleException : Exception
{
    public InvalidTriangleException(string? message = "This triangle cannot exist") : base(message)
    {
    }
}
