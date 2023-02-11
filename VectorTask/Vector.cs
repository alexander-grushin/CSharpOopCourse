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

            vectorComponents = new double[n];
        }

        public int GetSize()
        {
            return N;
        }

        public override string ToString()
        {
            return $"({string.Join(", ", vectorComponents)})";
        }

    }
}
