namespace ShapeTask
{
    internal class ShapeTask
    {
        static void Main(string[] args)
        {
            double X1 = 2;
            double Y1 = 1;

            double X2 = 5;
            double Y2 = 5;

            double X3 = 12;
            double Y3 = 2;

            IShape t = new Triangle(X1, Y1, X2, Y2, X3, Y3);

            Console.WriteLine($"Площадь = {t.GetArea()}");

            double sideLengthAB = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            double sideLengthBC = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            double sideLengthAC = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));

            Console.WriteLine($"AB = {sideLengthAB}");
            Console.WriteLine($"BC = {sideLengthBC}");
            Console.WriteLine($"AC = {sideLengthAC}");

            Console.WriteLine($"Периметр = {t.GetPerimeter()}");
            Console.WriteLine($"Высота = {t.GetHeight()}");
            Console.WriteLine($"Ширина = {t.GetWidth()}");
        }
    }
}