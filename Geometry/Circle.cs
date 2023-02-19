namespace Geometry;

/// <summary>
/// Represents a circle.
/// </summary>
public class Circle : Shape
{
    private const string InvalidRadiusMessage = "The radius cannot be less than or equal to zero";

    /// <summary>
    /// Creates the <see cref="Circle"/> instance.
    /// </summary>
    /// <param name="radius">Circle radius.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), radius, InvalidRadiusMessage);
        }

        Radius = radius;
    }

    /// <summary>
    /// Gets the circle radius.
    /// </summary>
    public double Radius { get; }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
