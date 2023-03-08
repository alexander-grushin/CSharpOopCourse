namespace HashTableTask
{
    internal class HashTableTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача HashTable.");

            HashTable<double> hashTable = new HashTable<double>(20);

            Console.WriteLine($"Кол-во HashTable = {hashTable.Count}");

            hashTable.Add(0.5);
            hashTable.Add(0.9);
            hashTable.Add(0.9);

            //hashTable.GetEnumerator();
            
            foreach (double item in hashTable)
            {
                /*if (item == null)
                {
                    Console.WriteLine("null");
                    continue;
                }*/

                Console.WriteLine(string.Join(", ", item));
            }

             Console.WriteLine();

            List<int>[] numbers = new List<int>[5];
            /*{
                new List<int> { 1 },
                new List<int> { 6 },
                new List<int> { 0, 3 },
                null,
                null
            };*/

            numbers[1] = new List<int> { 25 };

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
        }
    }
}