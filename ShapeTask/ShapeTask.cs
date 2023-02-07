namespace ShapeTask
{
    internal class ShapeTask
    {
        static IShape GetMaxArea(IShape[] shapes, IComparer<IShape>? comparer)
        {
            Array.Sort(shapes, comparer);

            return shapes[0];
        }

        static IShape GetSecondMaxPerimeter(IShape[] shapes, IComparer<IShape>? comparer)
        {
            Array.Sort(shapes, comparer);

            return shapes[1];
        }

        static void Main(string[] args)
        {
            IShape[] shapes = { new Square(10), new Triangle(2, 1, 5, 5, 12, 2),
                                new Rectangle(10, 25), new Circle(7), new Circle(7.00005),
                                new Triangle(0, 0, 20, 20, 35, 0), new Rectangle(6, 32) };

            IShape shapeWithMaxArea = GetMaxArea(shapes, new SortAreaComparer());

            Console.WriteLine($"Фигура с максимальной площадью из массива фигур = {shapeWithMaxArea.GetArea():f3}");
            Console.WriteLine($"- Периметр фигуры: {shapeWithMaxArea.GetPerimeter():f3}");
            Console.WriteLine($"- Высота и ширина: {shapeWithMaxArea.GetHeight()} x {shapeWithMaxArea.GetWidth()}");
            Console.WriteLine($"- Поля объекта: {shapeWithMaxArea}");

            Console.WriteLine();

            IShape shapeWithSecondMaxPerimeter = GetSecondMaxPerimeter(shapes, new SortPerimeterComparer());

            Console.WriteLine($"Фигуру со вторым по величине периметром из массива фигур = {shapeWithSecondMaxPerimeter.GetArea():f3}");
            Console.WriteLine($"- Площадь фигуры: {shapeWithSecondMaxPerimeter.GetPerimeter():f3}");
            Console.WriteLine($"- Высота и ширина: {shapeWithSecondMaxPerimeter.GetHeight()} x {shapeWithSecondMaxPerimeter.GetWidth()}");
            Console.WriteLine($"- Поля объекта: {shapeWithSecondMaxPerimeter}");
        }
    }
}