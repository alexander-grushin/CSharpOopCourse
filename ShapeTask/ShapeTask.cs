using ShapeTask.Comparers;
using ShapeTask.Shapes;

namespace ShapeTask;

internal class ShapeTask
{
    public static IShape? GetMaxAreaShape(IShape[] shapes)
    {
        if (shapes.Length == 0)
        {
            return null;
        }

        Array.Sort(shapes, new ShapeAreaComparer());

        return shapes[^1];
    }

    public static IShape? GetSecondMaxPerimeterShape(IShape[] shapes)
    {
        if (shapes.Length == 0)
        {
            return null;
        }

        if (shapes.Length == 1)
        {
            return shapes[0];
        }

        Array.Sort(shapes, new ShapePerimeterComparer());

        return shapes[^2];
    }

    static void Main(string[] args)
    {
        IShape[] shapes =
        {
            new Square(5),
            new Triangle(2, 1, 5, 5, 12, 2),
            new Rectangle(10, 25),
            new Circle(7),
            new Circle(7.00005),
            new Circle(7.00001),
            new Triangle(0, 0, 20, 20, 35, 0),
            new Rectangle(6, 32)
        };

        IShape? maxAreaShape = GetMaxAreaShape(shapes);

        IShape? secondMaxPerimeterShape = GetSecondMaxPerimeterShape(shapes);

        if (maxAreaShape is null)
        {
            Console.WriteLine("Shape is null.");
        }
        else
        {
            Console.WriteLine("Фигура с максимальной площадью из массива фигур:");
            Console.WriteLine($"- Информация о фигуре: {maxAreaShape}");
            Console.WriteLine($"- Площадь фигуры: {maxAreaShape.GetArea():f3}");
            Console.WriteLine($"- Периметр фигуры: {maxAreaShape.GetPerimeter():f3}");
        }

        Console.WriteLine();

        if (secondMaxPerimeterShape is null)
        {
            Console.WriteLine("Shape is null.");
        }
        else
        {
            Console.WriteLine("Фигуру со вторым по величине периметром из массива фигур:");
            Console.WriteLine($"- Информация о фигуре: {secondMaxPerimeterShape}");
            Console.WriteLine($"- Площадь фигуры: {secondMaxPerimeterShape.GetArea():f3}");
            Console.WriteLine($"- Периметр фигуры: {secondMaxPerimeterShape.GetPerimeter():f3}");
        }
    }
}