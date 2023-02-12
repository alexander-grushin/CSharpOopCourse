namespace VectorTask
{
    public class Vector
    {
        private int size;

        private double[] vectorComponents;

        public Vector(int n)
        {
            SetSize(n);
            vectorComponents = new double[n + 1];
        }

        public Vector(double[] vector)
        {
            SetSize(vector.Length - 1);

            vectorComponents = new double[vector.Length];
            Array.Copy(vector, vectorComponents, vector.Length);
        }

        public Vector(int n, double[] vector)
        {
            SetSize(n);

            int length = vector.Length;

            if (n < length)
            {
                length = n + 1;
            }

            vectorComponents = new double[n + 1];
            Array.Copy(vector, vectorComponents, length);
        }

        public Vector(Vector vector)
        {
            SetSize(vector.GetSize());

            vectorComponents = new double[size + 1];
            Array.Copy(vector.GetVectorComponents(), vectorComponents, size + 1);
        }

        public int GetSize()
        {
            return size;
        }

        private void SetSize(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора n <= 0.");
            }
            else
            {
                size = n;
            }
        }

        public double[] GetVectorComponents()
        {
            return vectorComponents;
        }

        public void SumToVector(Vector vector)
        {


            int minLength = Math.Min(vector.GetSize(), GetSize());

            for (int i = 0; i < minLength; i++)
            {
                vectorComponents[i] = vectorComponents[i]; 
            }

        }

        public double GetVectorLength()
        {
            double squaresSum = 0;

            for (int i = 0; i <= size; i++)
            {
                squaresSum += vectorComponents[i] * vectorComponents[i];
            }

            return Math.Sqrt(squaresSum);
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", vectorComponents) + "}";
        }

    }
}
