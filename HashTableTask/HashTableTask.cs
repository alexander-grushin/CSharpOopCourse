namespace HashTableTask
{
    internal class HashTableTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача HashTable.");
            Console.WriteLine();

            HashTable<double?> numbersHashTable = new HashTable<double?>(40)
            {
                0.5,
                0.9,
                null,
                0.9,
                0.11,
                105.6,
                25.1,
                null,
                null,
                0.91,
                0.6
            };

            Console.WriteLine(numbersHashTable);
            Console.WriteLine($"Кол-во элементов = {numbersHashTable.Count}");
            Console.WriteLine();

            double number1 = 25.1;
            Console.WriteLine($"Поиск в хэш-таблице - {number1}: {numbersHashTable.Contains(number1)}");
            Console.WriteLine();

            double number2 = 0.9;
            Console.WriteLine($"Удаление из хэш-таблице - {number2}: {numbersHashTable.Remove(number2)}");

            Console.WriteLine(numbersHashTable);
            Console.WriteLine($"Кол-во элементов = {numbersHashTable.Count}");
            Console.WriteLine();

            double?[] numbers = new double?[12];
            numbersHashTable.CopyTo(numbers, 0);

            Console.WriteLine($"Копирует список хэш-таблицы в массив: [{string.Join("; ", numbers)}]");
        }
    }
}