using ShapeTask.Classes;

namespace ShapeTask.Comparers
{
    public class ShapePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape? s1, IShape? s2)
        {
            if (s1 is null || s2 is null)
            {
                return -1;
            }

            double shapePerimeter1 = s1.GetPerimeter();
            double shapePerimeter2 = s2.GetPerimeter();

            return shapePerimeter1.CompareTo(shapePerimeter2);
        }
    }
}