using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] components;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size must be > 0. Current value = {size}", nameof(size));
            }

            components = new double[size];
        }

        public Vector(double[] vector) : this(vector.Length)
        {
            Array.Copy(vector, components, components.Length);
        }

        public Vector(int size, double[] vector) : this(size)
        {
            int copySize = vector.Length;

            if (components.Length < copySize)
            {
                copySize = components.Length;
            }

            Array.Copy(vector, components, copySize);
        }

        public Vector(Vector vector)
        {
            int vectorSize2 = vector.components.Length;

            components = new double[vectorSize2];
            Array.Copy(vector.components, components, vectorSize2);
        }

        public int GetSize()
        {
            return components.Length;
        }

        public void Add(Vector vector2)
        {
            int vectorSize1 = components.Length;

            double[] vectorComponents2 = vector2.components;
            int vectorSize2 = vectorComponents2.Length;

            int correctLength = Math.Min(vectorSize1, vectorSize2);

            if (vectorSize2 > vectorSize1)
            {
                correctLength = vectorSize2;
                Array.Resize(ref components, correctLength);
            }

            for (int i = 0; i < correctLength; i++)
            {
                components[i] += vectorComponents2[i];
            }
        }

        public void Subtract(Vector vector2)
        {
            int vectorSize1 = components.Length;

            double[] vectorComponents2 = vector2.components;
            int vectorSize2 = vectorComponents2.Length;

            int correctLength = Math.Min(vectorSize1, vectorSize2);

            if (vectorSize2 > vectorSize1)
            {
                correctLength = vectorSize2;
                Array.Resize(ref components, correctLength);
            }

            for (int i = 0; i < correctLength; i++)
            {
                components[i] -= vectorComponents2[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= scalar;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double squaresSum = 0;

            for (int i = 0; i < components.Length; i++)
            {
                squaresSum += components[i] * components[i];
            }

            return Math.Sqrt(squaresSum);
        }

        public double GetComponentByIndex(int index)
        {
            return components[index];
        }

        public void SetComponentByIndex(int index, double component)
        {
            components[index] = component;
        }

        /*public static Vector GetSumVectorsVector(Vector firstVector, Vector secondVector)
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
        }*/

        /*public static Vector GetSubtractionVectorsVector(Vector firstVector, Vector secondVector)
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
        }*/

        /*public static Vector GetMultiplicationVectorsVector(Vector firstVector, Vector secondVector)
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
        }*/

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{");

            stringBuilder.AppendJoin(", ", components);

            stringBuilder.Append("}");

            return stringBuilder.ToString();
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

            if (components.Length != v.components.Length)
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != v.components[i])
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

            foreach (double component in components)
            {
                hash = prime * hash + component.GetHashCode();
            }

            return hash;
        }
    }
}