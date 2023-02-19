using Geometry.Exceptions;

internal class Program
{
    private static void Main()
    {
        // Комментарий для Mindbox:
        // Сразу делаю вычисление площади фигуры без знания типа фигуры в compile-time
        Shape? figure;

        Console.Write($"Введите радиус круга: ");

        var isCircleCreated = false;

        do
        {
            if (double.TryParse(Console.ReadLine(), out var radius))
            {
                try
                {
                    figure = new Circle(radius);

                    isCircleCreated = true;

                    Console.WriteLine($"Площадь круга: {figure.GetArea()}");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Такого радиуса быть не может!");
                    Console.WriteLine("Попробуйте ещё раз!\n");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели что-то не то... Попробуйте ещё раз ввести радиус!");
            }
        } while (!isCircleCreated);

        Console.Write($"\nТеперь треугольник!");
        Console.WriteLine($"Введите длины сторон треугольника.");

        var isTriangleCreated = false;

        do
        {
            var a = InputTriangleSide("A");
            var b = InputTriangleSide("B");
            var c = InputTriangleSide("C");

            try
            {
                figure = new Triangle(a, b, c);

                isTriangleCreated = true;

                Console.WriteLine($"Площадь треугольника: {figure.GetArea()}");

                try
                {
                    // Комментарий для Mindbox:
                    // Так как все выше делалось без знания типа фигуры в compile-time
                    // Но мы знаем, что это треугольник, то я сразу привожу к нужному типу.
                    var triangle = (Triangle) figure;

                    if (triangle.IsRight())
                    {
                        Console.WriteLine("Кстати, вы ввели прямоугольный треугольник!");
                    }
                }
                catch
                {
                    Console.WriteLine("К сожалению, не смогли определить, прямоугольный ли треугольник" +
                        "из-за непредвиденной ошибки. :с");
                }
            }

            catch (Exception ex) when (ex is ArgumentOutOfRangeException or InvalidTriangleException)
            {
                Console.WriteLine("Вы ввели неправильные стороны! Такого треугольника не может быть!");
                Console.WriteLine("Попробуйте ещё раз!\n");
            }

            Console.WriteLine();
        } while (!isTriangleCreated);
    }

    private static double InputTriangleSide(string sideName)
    {
        var entered = false;
        double side;

        Console.Write($"Введите сторону {sideName}: ");

        do
        {
            if (double.TryParse(Console.ReadLine(), out side))
            {
                entered = true;
            }
            else
            {
                Console.WriteLine("Вы ввели что-то не то...\n");
                Console.Write($"Попробуйте ещё раз ввести сторону {sideName}:");
            }
        } while (!entered);

        return side;
    }
}