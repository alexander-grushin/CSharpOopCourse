namespace VectorTask
{
    public class Vector
    {
        private int size = 1; // убрать поле, так как это длина массива

        private double[] components = new double[1];

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size must be > 0. Current value = {size}", nameof(size));
            }

            this.size = size; // этого поля не будет

            //SetSize(n);

            components = new double[size];
        }

        public Vector(double[] vector)
        {
            SetSize(vector.Length);

            SetComponents(vector);
        }

        public Vector(int n, double[] vector)
        {
            SetSize(n);

            SetComponents(vector);
        }

        public Vector(Vector vector)
        {
            SetSize(vector.GetSize());

            SetComponents(vector.GetComponents());
        }

        public int GetSize()
        {
            //return size;
            return components.Length;
        }

        private void SetSize(int n) // не нужен
        {
            if (n <= 0)
            {
                throw new ArgumentException($"n must be > 0. Current value = {n}", nameof(n));
            }

            size = n;
        }

        public double[] GetComponents() // не нужен
        {
            return components;
        }

        private void SetComponents(double[] inputComponents) // не нужен
        {
            int vectorLength = inputComponents.Length;

            if (size < vectorLength)
            {
                vectorLength = size;
            }

            components = new double[size];

            Array.Copy(inputComponents, components, vectorLength);
        }

        public void SumToVector(Vector secondVector)
        {
            int secondVectorSize = secondVector.GetSize();
            double[] secondVectorComponents = secondVector.GetComponents();

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
                    tempElement1 = components[i];
                }

                if (i < secondVectorSize)
                {
                    tempElement2 = secondVectorComponents[i];
                }

                resultVectorComponents[i] = tempElement1 + tempElement2;
            }

            SetSize(maxSize);

            SetComponents(resultVectorComponents);
        }

        public void SubtractFromVector(Vector secondVector)
        {
            int secondVectorSize = secondVector.GetSize();
            double[] secondVectorComponents = secondVector.GetComponents();

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
                    tempElement1 = components[i];
                }

                if (i < secondVectorSize)
                {
                    tempElement2 = secondVectorComponents[i];
                }

                resultVectorComponents[i] = tempElement1 - tempElement2;
            }

            SetSize(maxSize);

            SetComponents(resultVectorComponents);
        }

        public void MultiplyVectorOnScalar(double scalarNumber)
        {
            for (int i = 0; i < size; i++)
            {
                components[i] *= scalarNumber;
            }
        }

        public void ExpandVector()
        {
            for (int i = 0; i < size; i++)
            {
                components[i] *= -1;
            }
        }

        public double GetLength()
        {
            double squaresSum = 0;

            for (int i = 0; i < size; i++)
            {
                squaresSum += components[i] * components[i];
            }

            return Math.Sqrt(squaresSum);
        }

        public double? GetByIndexComponent(int index)
        {
            if (index >= 0 && index <= size)
            {
                return components[index];
            }

            return null;
        }

        public void SetByIndexComponent(int index, double component)
        {
            if (index >= 0 && index <= size)
            {
                components[index] = component;
            }
        }

        public static Vector GetSumVectorsVector(Vector firstVector, Vector secondVector)
        {
            double[] firstVectorComponents = firstVector.GetComponents();
            double[] secondVectorComponents = secondVector.GetComponents();

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
            double[] firstVectorComponents = firstVector.GetComponents();
            double[] secondVectorComponents = secondVector.GetComponents();

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
            double[] firstVectorComponents = firstVector.GetComponents();
            double[] secondVectorComponents = secondVector.GetComponents();

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
            return "{" + string.Join("; ", components) + "}";
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

            double[] checkingVectorComponents = v.GetComponents();

            for (int i = 0; i < size; i++)
            {
                if (!Equals(components[i], checkingVectorComponents[i]))
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

            foreach (double component in components)
            {
                hash = prime * hash + component.GetHashCode();
            }

            return hash;
        }
    }
}