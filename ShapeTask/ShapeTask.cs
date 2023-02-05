namespace ShapeTask
{
    internal class ShapeTask
    {
        static void Main(string[] args)
        {
            IShape t = new Triangle(2, 5, 5, 5, 12, 2);

            Console.WriteLine($"Площадь = {t.GetArea()}");
            Console.WriteLine($"Периметр = {t.GetPerimeter()}");
        }
    }
}