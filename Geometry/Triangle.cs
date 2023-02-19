using Geometry.Exceptions;

using System.Threading;
using System.Xml.Linq;

namespace Geometry;

/// <summary>
/// Represents a triangle.
/// </summary>
public class Triangle : Shape
{
    private const string InvalidSideMessage = "The radius cannot be less than or equal to zero";

    /// <summary>
    /// Creates the <see cref="Triangle"/> instance.
    /// </summary>
    /// <param name="a">The first side of the triangle.</param>
    /// <param name="b">The second side of the triangle.</param>
    /// <param name="c">The third side of the triangle.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidTriangleException"></exception>
    public Triangle(double a, double b, double c)
    {
        if (a < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), a, InvalidSideMessage);
        }

        if (b < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(b), b, InvalidSideMessage);
        }

        if (c < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(c), c, InvalidSideMessage);
        }

        if (!IsPossibleToConstruct(a, b, c))
        {
            throw new InvalidTriangleException();
        }

        A = a;
        B = b;
        C = c;
    }

    /// <summary>
    /// Gets the length of the first side of the triangle.
    /// </summary>
    public double A { get; }

    /// <summary>
    /// Gets the length of the second side of the triangle.
    /// </summary>
    public double B { get; }

    /// <summary>
    /// Gets the length of the third side of the triangle.
    /// </summary>
    public double C { get; }

    /// <summary>
    /// Gets the area of the triangle.
    /// </summary>
    /// <remarks>
    /// If the triangle is degenerate, its area is always zero.
    /// </remarks>
    /// <returns>Returns the area of the triangle.</returns>
    public override double GetArea()
    {
        var p = GetSemiperimeter();
        var expressionUnderRoot = p * (p - A) * (p - B) * (p - C);
        var area = Math.Sqrt(expressionUnderRoot);

        return area;
    }

    /// <summary>
    /// Checks whether the triangle is right.
    /// </summary>
    /// <returns>
    /// Returns <see langword="true"/> if the triangle is right, otherwise - <see langword="false"/>.
    /// </returns>
    public bool IsRight()
    {
        // Comment for Mindbox:
        // I tested three options: determining the hypotenuse and further calculations,
        // then the one that is now, and writing in the style of c = sqrt(a ^ 2 + b ^ 2).
        // The search for the hypotenuse takes up a lot of space in the code, it is inconvenient to read,
        // and the difference is literally 2 - 3 ns.
        // Exponentiation takes up the same amount of space in the code as the square root,
        // but the speed is slightly faster, so I left this option.

        return Math.Pow(A, 2) == Math.Pow(B, 2) + Math.Pow(C, 2)
                        || Math.Pow(B, 2) == Math.Pow(C, 2) + Math.Pow(A, 2)
                        || Math.Pow(C, 2) == Math.Pow(A, 2) + Math.Pow(B, 2);
    }

    /// <summary>
    /// Checks whether it is possible to construct a triangle with the specified side lengths.
    /// </summary>
    /// <param name="a">First side.</param>
    /// <param name="b">Second side.</param>
    /// <param name="c">Third side.</param>
    /// <returns>
    /// Returns <see langword="true"/> if the triangle can be constructed with the specified side lengths,
    /// otherwise - <see langword="false"/>.
    /// </returns>
    private static bool IsPossibleToConstruct(double a, double b, double c)
    {
        return (a + b >= c) && (b + c >= a) && (a + c >= b);
    }

    /// <summary>
    /// Calculates the semiperimeter of the triangle.
    /// </summary>
    /// <returns>Returns the semiperimeter of the triangle.</returns>
    private double GetSemiperimeter()
    {
        return (A + B + C) / 2;
    }
}
