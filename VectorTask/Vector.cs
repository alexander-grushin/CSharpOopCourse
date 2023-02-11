namespace VectorTask
{
    public class Vector
    {
        private int n;

        private double[] vectorComponents;
        
        private int N
        {
            get 
            { 
                return n;
            }
            set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentException("Размерность n <= 0");
                }    
                else
                {
                    n = value;
                }
            }
        }

        public Vector(int n)
        {
            N = n;
            //SetSize(n);
            vectorComponents = new double[n];
        }

        public Vector(double[] vector)
        {
            N = vector.Length;

            vectorComponents = new double[N];
            Array.Copy(vector, vectorComponents, N);
        }

        public Vector(int n, double[] vector)
        {
            N = vector.Length;

            if (n < N)
            {
                N = n;
            }

            vectorComponents = new double[n];
            Array.Copy(vector, vectorComponents, N);
        }

        public Vector(Vector vector)
        {

        }

        public int GetSize()
        {
            return n;
        }
        /*
        private void SetSize(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Размерность n <= 0");
            }
            else
            {
                n = size;
            }
        }*/

        public override string ToString()
        {
            //return $"({string.Join(", ", vectorComponents)})";
            return "{" + string.Join(", ", vectorComponents) + "}";
        }

    }
}
