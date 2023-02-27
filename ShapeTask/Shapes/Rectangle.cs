namespace ShapeTask.Shapes;

class Rectangle : IShape
{
    public double Width { get; set; }

    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetWidth()
    {
        return Width;
    }

    public double GetHeight()
    {
        return Height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetPerimeter()
    {
        return (Width + Height) * 2;
    }

    public override string ToString()
    {
        return $"Rectangle. Width = {Width}; Height = {Height}.";
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

        return Width == rectangle.Width && Height == rectangle.Height;
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        hash = prime * hash + Width.GetHashCode();
        hash = prime * hash + Height.GetHashCode();

        return hash;
    }
}