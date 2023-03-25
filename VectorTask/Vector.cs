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

        public Vector(double[] vector)
        {
            if (vector.Length <= 0)
            {
                throw new ArgumentException($"Count of components in the vector must be > 0. Current value = {vector.Length}", nameof(vector.Length));
            }

            components = new double[vector.Length];

            Array.Copy(vector, components, components.Length);
        }

        public Vector(int size, double[] vector) : this(size)
        {
            Array.Copy(vector, components, Math.Min(vector.Length, components.Length));
        }

        public Vector(Vector vector)
        {
            components = new double[vector.components.Length];

            Array.Copy(vector.components, components, vector.components.Length);
        }

        public int GetSize()
        {
            return components.Length;
        }

        public void Add(Vector vector)
        {
            if (vector.components.Length > components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            int minLength = Math.Min(components.Length, vector.components.Length);

            for (int i = 0; i < minLength; i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (vector.components.Length > components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            int minLength = Math.Min(components.Length, vector.components.Length);

            for (int i = 0; i < minLength; i++)
            {
                components[i] -= vector.components[i];
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

            foreach (double component in components)
            {
                squaresSum += component * component;
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

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1.components);

            resultVector.Add(vector2);

            return resultVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1.components);

            resultVector.Subtract(vector2);

            return resultVector;
        }

        public static double GetProduct(Vector vector1, Vector vector2)
        {
            double result = 0;

            int minLength = Math.Min(vector1.components.Length, vector2.components.Length);

            for (int i = 0; i < minLength; i++)
            {
                result += vector1.components[i] * vector2.components[i];
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{");

            stringBuilder.AppendJoin(", ", components);

            stringBuilder.Append('}');

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

            Vector vector = (Vector)obj;

            if (components.Length != vector.components.Length)
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != vector.components[i])
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