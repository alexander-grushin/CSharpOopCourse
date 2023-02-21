using System;
using System.Numerics;

namespace VectorTask
{
    public class Vector
    {
        private int size;

        private double[] vectorComponents = Array.Empty<double>(); // под вопросом, избежать CS8618 (new double[0])

        public Vector(int n)
        {
            SetSize(n);

            vectorComponents = new double[n];
        }

        public Vector(double[] vector)
        {
            int vectorLength = vector.Length;

            SetSize(vectorLength);

            SetVectorComponents(vector, vectorLength);
            /*
            vectorComponents = new double[vectorLength];
            Array.Copy(vector, vectorComponents, vectorLength);*/
        }

        public Vector(int n, double[] vector)
        {
            SetSize(n);

            SetVectorComponents(vector, n);

            /*int vectorLength = vector.Length;
            
            if (n < vectorLength)
            {
                vectorLength = n;
            }

            vectorComponents = new double[n];

            Array.Copy(vector, vectorComponents, vectorLength);*/
        }
        
        public Vector(Vector vector)
        {
            SetSize(vector.GetSize());

            SetVectorComponents(vector.GetVectorComponents(), size);
            /*
            vectorComponents = new double[size];

            Array.Copy(vector.GetVectorComponents(), vectorComponents, size);*/
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

        private void SetVectorComponents(double[] inputComponents, int n) // param ? or override method
        {
            int vectorLength = inputComponents.Length;

            if (n < vectorLength)
            {
                vectorLength = n;
            }

            vectorComponents = new double[n];

            Array.Copy(inputComponents, vectorComponents, vectorLength);
        }

        public void SumToVector(Vector vector)
        {
            int minLength = Math.Min(vector.GetSize(), GetSize());

            for (int i = 0; i < minLength; i++)
            {
                vectorComponents[i] = vectorComponents[i]; 
            }

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

        public override string ToString()
        {
            return "{" + string.Join(", ", vectorComponents) + "}";
        }

    }
}