namespace ShapeTask
{
    class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle (double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return Radius * 2;
        }

        public double GetHeight()
        {
            return Radius * 2;
        }
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return Math.PI * Radius * 2;
        }
    }
}
