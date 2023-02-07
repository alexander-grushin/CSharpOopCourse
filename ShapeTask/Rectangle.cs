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

        public override string ToString()
        {
            return $"{Width}, {Heigtht}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Rectangle rectangle = (Rectangle)obj;

            return Width == rectangle.Width && Heigtht == rectangle.Heigtht;
        }

        public override int GetHashCode()
        {
            const int prime = 37;
            int hash = 1;

            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Heigtht.GetHashCode();

            return hash;
        }
    }
}