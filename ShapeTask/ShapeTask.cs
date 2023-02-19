using ShapeTask.Comparers;
using ShapeTask.Classes;

namespace ShapeTask
{
    internal class ShapeTask
    {
        public static IShape? GetMaxAreaShape(IShape[] shapes)
        {
            int shapesLength = shapes.Length;

            if (shapesLength == 0)
            {
                return null;
            }

            Array.Sort(shapes, new ShapeAreaComparer());
 
            return shapes[shapesLength - 1];
        }

        public static IShape? GetSecondMaxPerimeterShape(IShape[] shapes)
        {
            int shapesLength = shapes.Length;
            
            if (shapesLength == 0)
            {
                return null;
            }

            Array.Sort(shapes, new ShapePerimeterComparer());

            return shapes[shapesLength - 2];
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

            if (maxAreaShape is not null && secondMaxPerimeterShape is not null)
            {
                Console.WriteLine("Фигура с максимальной площадью из массива фигур:");
                Console.WriteLine($"- Информация о фигуре: {maxAreaShape}");
                Console.WriteLine($"- Площадь фигуры: {maxAreaShape.GetArea():f3}");
                Console.WriteLine($"- Периметр фигуры: {maxAreaShape.GetPerimeter():f3}");

                Console.WriteLine();

                Console.WriteLine("Фигуру со вторым по величине периметром из массива фигур:");
                Console.WriteLine($"- Информация о фигуре: {secondMaxPerimeterShape}");
                Console.WriteLine($"- Площадь фигуры: {secondMaxPerimeterShape.GetArea():f3}");
                Console.WriteLine($"- Периметр фигуры: {secondMaxPerimeterShape.GetPerimeter():f3}");
            }
            else
            {
                Console.WriteLine("Shape is null.");
            }
        }
    }
}