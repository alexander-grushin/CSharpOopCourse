namespace ShapeTask
{
    public class SortPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape? s1, IShape? s2)
        {
            if (s1 is null || s2 is null)
            {
                throw new ArgumentException("Некорректное значение параметра.");
            }
            else
            {
                return (int)Math.Round(s2.GetPerimeter() - s1.GetPerimeter(), MidpointRounding.AwayFromZero);
            }
        }
    }
}