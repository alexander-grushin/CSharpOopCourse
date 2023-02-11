namespace VectorTask
{
    internal class VectorTask
    {
        static void Main(string[] args)
        {
            Vector vector1 = new(3);

            Console.WriteLine(vector1);
            Console.WriteLine(vector1.GetSize());

        }
    }
}