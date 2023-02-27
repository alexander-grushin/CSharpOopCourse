using ShapeTask.Shapes;

namespace ShapeTask.Comparers;

public class ShapeAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? s1, IShape? s2)
    {
        if (s1 is null && s2 is null)
        {
            return 0;
        }
        
        if (s1 is null)
        {
            return -1;
        }

        if (s2 is null)
        {
            return 1;
        }

        return s1.GetArea().CompareTo(s2.GetArea());
    }
}