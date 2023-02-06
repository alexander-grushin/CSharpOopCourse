namespace ShapeTask
{
    public class SortAreaComparer : IComparer<IShape>
    { 
        public int Compare(IShape? s1, IShape? s2)
        {
            if (s1 is null || s2 is null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }
            else
            {
                return (int)s1.GetArea() - (int)s2.GetArea();
            }
        }
    }
}
