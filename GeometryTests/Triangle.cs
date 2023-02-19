namespace GeometryTests;

[TestClass]
public class TriangleTest
{
    [DataRow(-1, 0, 0, false)] // Validate negative lengths
    [DataRow(0, -1, 0, false)]
    [DataRow(0, 0, -1, false)]
    [DataRow(0, 0, 0, true)] // Three vertices at one point (a degenerate triangle)
    [DataRow(0, 2, 2, true)] // Two vertices at one point (a degenerate triangle)
    [DataRow(1, 2, 4, false)] // There is no such triangle
    [DataRow(1, 2, 7, false)] // There is no such triangle
    [DataRow(1, 2, 3, true)]

    [DataTestMethod]
    public void Triangle_CreateInstance(double a, double b, double c, bool isCreated)
    {
        try
        {
            var triangle = new Triangle(a, b, c);

            Assert.IsNotNull(triangle);
        }
        catch
        {
            Assert.IsFalse(isCreated);
        }
    }

    [DataRow(0, 0, 0, 0)] // Three vertices at one point (a degenerate triangle)
    [DataRow(0, 2, 2, 0)] // Two vertices at one point (a degenerate triangle)
    [DataRow(1, 2, 3, 0)] // All vertices at one line (a degenerate triangle)
    [DataRow(3, 4, 5, 6)]
    [DataTestMethod]
    public void Triangle_GetArea(double a, double b, double c, double result)
    {
        var triangle = new Triangle(a, b, c);
        var area = triangle.GetArea();

        Assert.AreEqual(area, result);
    }

    private static IEnumerable<object?[]> GetValues()
    {
        var random = new Random();

        for (var i = 0; i < 10; i++)
        {
            yield return new object?[] { random.NextDouble() * random.Next(int.MinValue, int.MaxValue),
            random.NextDouble() * random.Next(int.MinValue, int.MaxValue),
            random.NextDouble() * random.Next(int.MinValue, int.MaxValue)};
        }
    }
}
