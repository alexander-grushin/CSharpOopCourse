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
                new Vector(new double[] { 1, 2, 3, 4, 6 }),
                new Vector(4, new double[] { -1, 5, 3, 1, 1, 1, 1, 2 }),
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

            vectors[1].Add(vectors[2]);
            Console.WriteLine(vectors[1]);

            Console.WriteLine();

            Console.WriteLine("Вычитание из вектора другого вектора:");
            Console.Write($"{vectors[1]} - {vectors[3]} = ");

            vectors[1].Subtract(vectors[3]);
            Console.WriteLine(vectors[1]);

            Console.WriteLine();

            double scalar = 1.5;

            Console.WriteLine("Умножение вектора на скаляр:");
            Console.Write($"{vectors[1]} * {scalar} = ");

            vectors[1].MultiplyByScalar(scalar);
            Console.WriteLine(vectors[1]);

            Console.WriteLine();

            Console.WriteLine("Разворот вектора:");
            Console.Write($"{vectors[4]} * (-1) = ");

            vectors[4].Reverse();
            Console.WriteLine(vectors[4]);

            Console.WriteLine();

            Console.WriteLine($"Получение длины вектора {vectors[3]} :");
            Console.WriteLine(vectors[3].GetLength());

            Console.WriteLine();

            int index = 1;

            Console.WriteLine("Получение компонента вектора по индексу:");
            Console.WriteLine($"{vectors[1]}. Задан индекс = {index}. Получен комномент => {vectors[1].GetComponentByIndex(index)}.");

            Console.WriteLine();

            double newComponent = 2.5;

            Console.WriteLine("Установить компонент вектора по индексу:");

            Console.Write($"{vectors[1]}. Задан индекс = {index}. Установить комномент => {newComponent}.");
            vectors[1].SetComponentByIndex(index, newComponent);

            Console.WriteLine($" Вектор = {vectors[1]}");

            Console.WriteLine();
            Console.WriteLine("Статические методы:");

            Console.WriteLine("Сложение двух векторов:");
            Vector vector1 = Vector.GetSum(vectors[3], vectors[4]);

            Console.WriteLine($"{vectors[3]} + {vectors[4]}");
            Console.WriteLine($"Новый вектор: {vector1}. Размерность = {vector1.GetSize()}");

            Console.WriteLine();

            Console.WriteLine("Разность двух векторов:");
            Vector vector2 = Vector.GetDifference(vectors[2], vectors[3]);

            Console.WriteLine($"{vectors[2]} - {vectors[3]}");
            Console.WriteLine($"Новый вектор: {vector2}. Размерность = {vector2.GetSize()}");

            Console.WriteLine();

            double scalarProduct = Vector.GetProduct(vectors[2], vectors[3]);

            Console.WriteLine($"Cкалярное произведение векторов: {vectors[2]} и {vectors[3]} = {scalarProduct}.");
        }
    }
}