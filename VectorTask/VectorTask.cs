namespace VectorTask
{
    internal class VectorTask
    {
        static void Main(string[] args)
        {
            Vector vector1 = new(5);

            Console.WriteLine(vector1);
            Console.WriteLine(vector1.GetSize());

            double[] v1 = new double[] { 2, 3, 8 };

            Vector vector2 = new(v1);

            Console.WriteLine(vector2);
            Console.WriteLine(vector2.GetSize());

            Vector vector3 = new(6, v1);

            Console.WriteLine(vector3);
            Console.WriteLine(vector3.GetSize());
        }
    }
}