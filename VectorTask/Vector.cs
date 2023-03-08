using System.Drawing;
using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] components;// = new double[1];

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

        public Vector(Vector vector)// : this(vector.components.Length) // TODO может сражу создать массив и копировать в него
        {
            int vectorSize2 = vector.components.Length;

            components = new double[vectorSize2];
            Array.Copy(vector.components, components, vectorSize2);
        }

        public int GetSize()
        {
            return components.Length;
        }

        /*private void SetComponents(double[] inputComponents) // не нужен
        {
            int vectorLength = inputComponents.Length;

            if (size < vectorLength)
            {
                vectorLength = size;
            }

            components = new double[size];

            Array.Copy(inputComponents, components, vectorLength);
        }*/

        public void Add(Vector vector2)
        {
            int vectorSize1 = components.Length;

            double[] vectorComponents2 = vector2.components;
            int vectorSize2 = vector2.components.Length;

            int maxSize = vectorSize1;

            if (vectorSize1 < vectorSize2)
            {
                //components = new double[vectorSize2];
                maxSize = vectorSize2;
            }

            double[] resultComponents = new double[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                double components1 = 0;
                double components2 = 0;

                if (i < vectorSize1)
                {
                    components1 = components[i];
                }

                if (i < vectorSize2)
                {
                    components2 = vectorComponents2[i];
                }

                resultComponents[i] = components1 + components2;
            }

            components = new double[maxSize];

            Array.Copy(resultComponents, components, resultComponents.Length);
        }

        /*public void SubtractFromVector(Vector secondVector)
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
        }*/

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

            if (components.Length != v.GetSize())
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