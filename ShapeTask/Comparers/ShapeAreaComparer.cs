using ShapeTask.Shape;

namespace ShapeTask.Comparers
{
    public class ShapeAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape? s1, IShape? s2)
        {
            if (s1 is null || s2 is null)
            {
                return -1;
            }    

            double shapeArea1 = s1.GetArea();
            double shapeArea2 = s2.GetArea();

            return shapeArea1.CompareTo(shapeArea2);
        }
    }
}