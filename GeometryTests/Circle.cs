namespace GeometryTests;

[TestClass]
public class CircleTest
{
    // Comment for Mindbox:
    // It was possible to do an instance creation test in the same way as a circle.
    // Just wanted to show different options.
    [DataRow(0)]
    [DynamicData(nameof(GetRadiuses), DynamicDataSourceType.Method)]
    [DataTestMethod]
    public void Circle_RadiusZeroOrLess_ThrowException(double radius)
    {
        if (radius <= 0)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(radius));
        }
    }

    [DataRow(0)]
    [DynamicData(nameof(GetRadiuses), DynamicDataSourceType.Method)]
    [DataTestMethod]
    public void Circle_RadiusGreaterThanZero_CreateCircle(double radius)
    {
        if (radius > 0)
        {
            Assert.IsNotNull(new Circle(radius));
        }
    }

    [DataRow(124, 48305.12864159666)]
    [DataRow(1, 3.141592653589793)]
    [DataRow(454, 647532.5113873138)]
    [DataRow(double.MaxValue, double.PositiveInfinity)]
    [DataTestMethod]
    public void GetArea(double radius, double result)
    {
        var circle = new Circle(radius);
        var area = circle.GetArea();

        Assert.AreEqual(area, result);
    }

    private static IEnumerable<object?[]> GetRadiuses()
    {
        var random = new Random();

        for (var i = 0; i < 10; i++)
        {
            yield return new object?[] { random.NextDouble() * random.Next(int.MinValue, int.MaxValue) };
        }
    }
}