namespace ShapeTask
{
    class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Heigtht { get; set; }

        public Rectangle(double width, double heigtht)
        {
            Width = width;
            Heigtht = heigtht;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Heigtht;
        }
        public double GetArea()
        {
            return Width * Heigtht;
        }

        public double GetPerimeter()
        {
            return (Width + Heigtht) * 2;
        }
    }
}
