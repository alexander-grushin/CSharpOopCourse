namespace VectorTask
{
    internal class VectorTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование программы Vector.");
            Console.WriteLine();

            Vector[] vectors =
            {
                new Vector(5),
                new Vector(new double[] { 1, 2, 3, -4, 6 }),
                new Vector(4, new double[] { -1, 5, 3 }),
                new Vector(2, new double[] { -1, 5, 3 }),
                new Vector(new Vector(new double[] { 1, 1, 1 }))
            };

            Console.WriteLine("Тестирование создание векторов:");

            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector}. Размерность = {vector.GetSize()}");
            }

            Console.WriteLine();

            Console.WriteLine("Прибавление к вектору другого вектора:");
            Console.Write($"{vectors[1]} + {vectors[2]} = ");

            vectors[1].SumToVector(vectors[2]);
            Console.WriteLine(vectors[1]);

            Console.WriteLine();

            Console.WriteLine("Вычитание из вектора другого вектора:");
            Console.Write($"{vectors[1]} - {vectors[3]} = ");

            vectors[1].SubtractFromVector(vectors[3]);
            Console.WriteLine(vectors[1]);

            Console.WriteLine();

            double scalar = 0.9;

            Console.WriteLine("Умножение вектора на скаляр:");
            Console.Write($"{vectors[1]} * {scalar} = ");

            vectors[1].MultiplyVectorOnScalar(scalar);
            Console.WriteLine(vectors[1]);

            Console.WriteLine();

            Console.WriteLine("Разворот вектора:");
            Console.Write($"{vectors[4]} * (-1) = ");

            vectors[4].ExpandVector();
            Console.WriteLine(vectors[4]);

            Console.WriteLine();

            Console.WriteLine($"Получение длины вектора {vectors[3]} :");
            Console.WriteLine(vectors[3].GetLength());

            Console.WriteLine();

            int index = 1;

            Console.WriteLine("Получение компонента вектора по индексу:");
            Console.WriteLine($"{vectors[1]}. Задан индекс = {index}. Получен комномент => {vectors[1].GetByIndexComponent(index)}.");

            Console.WriteLine();

            double newComponent = 2.5;

            Console.WriteLine("Установить компонент вектора по индексу:");

            Console.Write($"{vectors[1]}. Задан индекс = {index}. Установить комномент => {newComponent}.");
            vectors[1].SetByIndexComponent(index, newComponent);

            Console.WriteLine($" Вектор = {vectors[1]}");

            Console.WriteLine();
            Console.WriteLine("Статические методы:");

            Console.WriteLine("Сложение двух векторов:");
            Vector vector1 = Vector.GetSumVectorsVector(vectors[3], vectors[4]);

            Console.WriteLine($"{vectors[3]} + {vectors[4]}");
            Console.WriteLine($"Новый вектор: {vector1}. Размерность = {vector1.GetSize()}");

            Console.WriteLine();

            Console.WriteLine("Вычитание двух векторов:");
            Vector vector2 = Vector.GetSubtractionVectorsVector(vectors[2], vectors[3]);

            Console.WriteLine($"{vectors[2]} - {vectors[3]}");
            Console.WriteLine($"Новый вектор: {vector2}. Размерность = {vector2.GetSize()}");

            Console.WriteLine();

            Console.WriteLine("Скалярное произведение векторов:");
            Vector vector3 = Vector.GetMultiplicationVectorsVector(vectors[2], vectors[3]);

            Console.WriteLine($"{vectors[2]} * {vectors[3]}");
            Console.WriteLine($"Новый вектор: {vector3}. Размерность = {vector3.GetSize()}");
        }
    }
}