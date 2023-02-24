namespace VectorTask
{
    public class Vector
    {
        private static readonly int defaultSize = 1;

        private int size = defaultSize;

        private double[] vectorComponents = new double[defaultSize];

        public Vector(int n)
        {
            SetSize(n);

            vectorComponents = new double[size];
        }

        public Vector(double[] vector)
        {
            SetSize(vector.Length);

            SetVectorComponents(vector);
        }

        public Vector(int n, double[] vector)
        {
            SetSize(n);

            SetVectorComponents(vector);
        }

        public Vector(Vector vector)
        {
            SetSize(vector.GetSize());

            SetVectorComponents(vector.GetVectorComponents());
        }

        public int GetSize()
        {
            return size;
        }

        private void SetSize(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"n must be > 0. Current value = {n}", nameof(n));
            }

            size = n;
        }

        public double[] GetVectorComponents()
        {
            return vectorComponents;
        }

        private void SetVectorComponents(double[] inputComponents)
        {
            int vectorLength = inputComponents.Length;

            if (size < vectorLength)
            {
                vectorLength = size;
            }

            vectorComponents = new double[size];

            Array.Copy(inputComponents, vectorComponents, vectorLength);
        }

        public void SumToVector(Vector secondVector)
        {
            int secondVectorSize = secondVector.GetSize();
            double[] secondVectorComponents = secondVector.GetVectorComponents();

            int maxSize = Math.Max(size, secondVectorSize);

            double[] resultVectorComponents = new double[maxSize];

            double tempElement1;
            double tempElement2;

            for (int i = 0; i < maxSize; i++)
            {
                tempElement1 = 0;
                tempElement2 = 0;

                if (i < size)
                {
                    tempElement1 = vectorComponents[i];
                }

                if (i < secondVectorSize)
                {
                    tempElement2 = secondVectorComponents[i];
                }

                resultVectorComponents[i] = tempElement1 + tempElement2;
            }

            SetSize(maxSize);

            SetVectorComponents(resultVectorComponents);
        }

        public void SubtractFromVector(Vector secondVector)
        {
            int secondVectorSize = secondVector.GetSize();
            double[] secondVectorComponents = secondVector.GetVectorComponents();

            int maxSize = Math.Max(size, secondVectorSize);

            double[] resultVectorComponents = new double[maxSize];

            double tempElement1;
            double tempElement2;

            for (int i = 0; i < maxSize; i++)
            {
                tempElement1 = 0;
                tempElement2 = 0;

                if (i < size)
                {
                    tempElement1 = vectorComponents[i];
                }

                if (i < secondVectorSize)
                {
                    tempElement2 = secondVectorComponents[i];
                }

                resultVectorComponents[i] = tempElement1 - tempElement2;
            }

            SetSize(maxSize);

            SetVectorComponents(resultVectorComponents);
        }

        public void MultiplyVectorOnScalar(double scalarNumber)
        {
            for (int i = 0; i < size; i++)
            {
                vectorComponents[i] *= scalarNumber;
            }
        }

        public void ExpandVector()
        {
            for (int i = 0; i < size; i++)
            {
                vectorComponents[i] *= -1;
            }
        }

        public double GetVectorLength()
        {
            double squaresSum = 0;

            for (int i = 0; i < size; i++)
            {
                squaresSum += vectorComponents[i] * vectorComponents[i];
            }

            return Math.Sqrt(squaresSum);
        }

        public double? GetByIndexComponent(int index)
        {
            if (index >= 0 && index <= size)
            {
                return vectorComponents[index];
            }

            return null;
        }

        public void SetByIndexComponent(int index, double component)
        {
            if (index >= 0 && index <= size)
            {
                vectorComponents[index] = component;
            }
        }

        public static Vector GetSumVectorsVector(Vector firstVector, Vector secondVector)
        {
            double[] firstVectorComponents = firstVector.GetVectorComponents();
            double[] secondVectorComponents = secondVector.GetVectorComponents();

            int firstVectorSize = firstVector.GetSize();
            int secondVectorSize = secondVector.GetSize();

            int maxSize = Math.Max(firstVectorSize, secondVectorSize);

            double[] resultVectorComponents = new double[maxSize];

            double tempElement1;
            double tempElement2;

            for (int i = 0; i < maxSize; i++)
            {
                tempElement1 = 0;
                tempElement2 = 0;

                if (i < firstVectorSize)
                {
                    tempElement1 = firstVectorComponents[i];
                }

                if (i < secondVectorSize)
                {
                    tempElement2 = secondVectorComponents[i];
                }

                resultVectorComponents[i] = tempElement1 + tempElement2;
            }

            return new Vector(resultVectorComponents);
        }

        public static Vector GetSubtractionVectorsVector(Vector firstVector, Vector secondVector)
        {
            double[] firstVectorComponents = firstVector.GetVectorComponents();
            double[] secondVectorComponents = secondVector.GetVectorComponents();

            int firstVectorSize = firstVector.GetSize();
            int secondVectorSize = secondVector.GetSize();

            int maxSize = Math.Max(firstVectorSize, secondVectorSize);

            double[] resultVectorComponents = new double[maxSize];

            double tempElement1;
            double tempElement2;

            for (int i = 0; i < maxSize; i++)
            {
                tempElement1 = 0;
                tempElement2 = 0;

                if (i < firstVectorSize)
                {
                    tempElement1 = firstVectorComponents[i];
                }

                if (i < secondVectorSize)
                {
                    tempElement2 = secondVectorComponents[i];
                }

                resultVectorComponents[i] = tempElement1 - tempElement2;
            }

            return new Vector(resultVectorComponents);
        }

        public static Vector GetMultiplicationVectorsVector(Vector firstVector, Vector secondVector)
        {
            double[] firstVectorComponents = firstVector.GetVectorComponents();
            double[] secondVectorComponents = secondVector.GetVectorComponents();

            int firstVectorSize = firstVector.GetSize();
            int secondVectorSize = secondVector.GetSize();

            int maxSize = Math.Max(firstVectorSize, secondVectorSize);

            double[] resultVectorComponents = new double[maxSize];

            double tempElement1;
            double tempElement2;

            for (int i = 0; i < maxSize; i++)
            {
                tempElement1 = 0;
                tempElement2 = 0;

                if (i < firstVectorSize)
                {
                    tempElement1 = firstVectorComponents[i];
                }

                if (i < secondVectorSize)
                {
                    tempElement2 = secondVectorComponents[i];
                }

                if (tempElement1 == 0 || tempElement2 == 0)
                {
                    resultVectorComponents[i] = 0;
                }
                else
                {
                    resultVectorComponents[i] = tempElement1 * tempElement2;
                }
            }

            return new Vector(resultVectorComponents);
        }

        public override string ToString()
        {
            return "{" + string.Join("; ", vectorComponents) + "}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector v = (Vector)obj;

            if (size != v.GetSize())
            {
                return false;
            }

            double[] checkingVectorComponents = v.GetVectorComponents();

            for (int i = 0; i < size; i++)
            {
                if (!Equals(vectorComponents[i], checkingVectorComponents[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 37;
            int hash = 1;

            hash = prime * hash + size;

            foreach (double component in vectorComponents)
            {
                hash = prime * hash + component.GetHashCode();
            }

            return hash;
        }
    }
}