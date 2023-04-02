using System.Collections;

namespace HashTableTask
{
    internal class HashTableTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача HashTable.");

            HashTable<double?> hashTable = new HashTable<double?>(20);

            Console.WriteLine($"Кол-во HashTable = {hashTable.Count}");

            hashTable.Add(null);
            hashTable.Add(0.5);
            hashTable.Add(0.9);
            hashTable.Add(0.9);
            hashTable.Add(0.1);
            hashTable.Add(105.6);
            hashTable.Add(25.1);
            hashTable.Add(null);
            hashTable.Add(0.9);

            double number1 = 25.1;

            Console.WriteLine($"Поиск в хэш-таблице - {number1}: {hashTable.Contains(number1)}");

            double number2 = 0.9;
            Console.WriteLine($"Удаление в хэш-таблице - {number2}: {hashTable.Remove(number2)}");


            Console.WriteLine(hashTable);

            foreach (double? item in hashTable)
            {
                if (item == null)
                {
                    Console.WriteLine("null");
                    continue;
                }

                Console.WriteLine(string.Join(", ", item));
            }

            Console.WriteLine();



            Console.WriteLine("///////////////////////");

            List<int?>[] numbers = new List<int?>[5];
            /*{
                new List<int> { 1 },
                new List<int> { 6 },
                new List<int> { 0, 3 },
                null,
                null
            };*/

            numbers[1] = new List<int?> { 25 };

            numbers[0] = new List<int?> { null };

            if (numbers[0] == default)
            {
                numbers[0].Add(100);
            }

            foreach (var number in numbers)
            {
                if (number == null)
                {
                    Console.WriteLine("null");
                    continue;
                }

                Console.WriteLine(string.Join(", ", number));
            }

            Console.WriteLine(numbers.Length);

            Console.WriteLine();
            Console.WriteLine("////////////////////");

            Hashtable hash1 = new Hashtable();

            Dictionary<int, string> people = new Dictionary<int, string>();
        }
    }
}