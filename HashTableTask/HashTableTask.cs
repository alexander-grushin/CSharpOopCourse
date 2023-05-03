namespace HashTableTask
{
    internal class HashTableTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача HashTable.");
            Console.WriteLine();

            HashTable<int?> numbersHashTable = new HashTable<int?>(50)
            {
                5,
                9,
                null,
                9,
                11,
                105,
                25,
                null,
                null,
                3,
                6
            };

            Console.WriteLine(numbersHashTable);
            Console.WriteLine($"Кол-во элементов = {numbersHashTable.Count}");
            Console.WriteLine();

            int number1 = 25;
            Console.WriteLine($"Поиск в хэш-таблице - {number1}: {numbersHashTable.Contains(number1)}");
            Console.WriteLine();

            int number2 = 9;
            Console.WriteLine($"Удаление из хэш-таблице - {number2}: {numbersHashTable.Remove(number2)}");

            Console.WriteLine(numbersHashTable);
            Console.WriteLine($"Кол-во элементов = {numbersHashTable.Count}");
            Console.WriteLine();

            Console.WriteLine($"Добвление в хэш-таблицу - {number2}");
            numbersHashTable.Add(number2);

            Console.WriteLine(numbersHashTable);
            Console.WriteLine($"Кол-во элементов = {numbersHashTable.Count}");
            Console.WriteLine();

            int?[] numbers = new int?[12];
            numbersHashTable.CopyTo(numbers, 0);

            Console.WriteLine($"Копирует список хэш-таблицы в массив: [{string.Join("; ", numbers)}]");
        }
    }
}