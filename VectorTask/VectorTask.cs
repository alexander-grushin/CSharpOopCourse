﻿using System.Numerics;

namespace VectorTask
{
    internal class VectorTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование программы Vector.");
            Console.WriteLine("Тестирование Конструкторов:");
            //1
            Vector vector1 = new(5);

            Console.WriteLine(vector1);
            Console.WriteLine(vector1.GetSize());

            //2
            double[] v1 = new double[] { 2, 3, -8, 10 };

            Vector vector2 = new(v1);

            Console.WriteLine();
            Console.WriteLine(vector2);
            Console.WriteLine(vector2.GetSize());

            Console.WriteLine();
            Console.WriteLine($"Длина вектора = {vector2.GetVectorLength()}");

            vector2.ExpandVector();
            Console.WriteLine($"После разворота = {vector2}");

            int index = 1;
            Console.WriteLine($"Получить комномента по индеку ({index}) = [{vector2.GetByIndexComponent(index)}]");
            Console.WriteLine($"Установить комномент по индеку ({index}):");

            vector2.SetByIndexComponent(index, 25);
            Console.WriteLine(vector2);

            Console.WriteLine("Умножить вектор на скаляр (-3.45)");
            vector2.MultiplyVectorOnScalar(-3.45);
            Console.WriteLine(vector2);

            //3
            Vector vector3 = new(2, v1);

            Console.WriteLine();
            Console.WriteLine(vector3 + " -> 3 вид конструктора");
            Console.WriteLine(vector3.GetSize());

            //4                          0  1  2  3   4  5   6  7
            double[] v2 = new double[] { 0, 1, 3, 6, 13, 9, 20, 2 };
            
            Vector vectorForCopy = new Vector(v2);
            Vector vector4 = new(vectorForCopy);

            Console.WriteLine();
            Console.WriteLine(vector4);
            Console.WriteLine(vector4.GetSize());
            
        }
    }
}