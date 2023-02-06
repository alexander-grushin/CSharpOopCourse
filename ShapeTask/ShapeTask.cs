namespace ShapeTask
{
    internal class ShapeTask
    {
        static void Main(string[] args)
        {
            IShape[] shapes = { new Square(8), new Triangle(2, 1, 5, 5, 12, 2),
                                new Rectangle(10, 25), new Circle(7)};

            Array.Sort(shapes, new SortAreaComparer());

            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"{shape.ToString} - {shape.GetArea()}");
            }
        }
    }
}