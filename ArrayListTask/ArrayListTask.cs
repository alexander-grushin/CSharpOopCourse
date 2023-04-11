namespace ArrayListTask
{
    class ArrayListTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Реализация ArrayList.");
            Console.WriteLine("Проверка конструкторов. Создание списков:");

            ArrayList<int> numbers1 = new ArrayList<int> { 1, 2, 3, -6, 0, 1, 44, 3, 6, 9, 88, 10, 0, 9, -5, 7 };

            Console.WriteLine($"Count = {numbers1.Count} / Capacity = {numbers1.Capacity}");
            Console.WriteLine(numbers1);

            ArrayList<string> lines = new ArrayList<string>(25);

            Console.WriteLine($"Count = {lines.Count} / Capacity = {lines.Capacity}");
            Console.WriteLine(lines);

            ArrayList<int> numbers2 = new ArrayList<int>();

            Console.WriteLine($"Count = {numbers2.Count} / Capacity = {numbers2.Capacity}");
            Console.WriteLine(numbers2);

            Console.WriteLine();
            Console.WriteLine("Работа с операциями.");

            int index1 = 16;
            int number1 = 100;

            int number2 = 101;

            Console.WriteLine($"Добавление {number2} и вставка {number1} индексом = {index1} в список чисел:");

            numbers1.Add(number2);
            numbers1.Insert(index1, number1);

            Console.WriteLine(numbers1);

            int index2 = 5;
            int number3 = 3;

            Console.WriteLine();
            Console.WriteLine($"Удаление первого вхождения {number3} и удаление по индексу {index2}:");

            numbers1.Remove(number3);
            numbers1.RemoveAt(index2);

            Console.WriteLine(numbers1);

            Console.WriteLine();
            Console.WriteLine($"Определяем, содержит ли список число {number1} => {numbers1.Contains(number1)}");

            int index3 = 7;
            int[] numbers3 = new int[numbers1.Count + index3];

            Console.WriteLine();
            Console.WriteLine($"Копируем список чисел в массив с индеса = {index3}:");

            numbers1.CopyTo(numbers3, index3);

            Console.WriteLine($"[{string.Join(", ", numbers3)}]");

            Console.WriteLine();
            Console.WriteLine("Изменить свойства Capacity и использовать метод TrimExcess:");

            Console.WriteLine($"Исходный Capacity = {numbers1.Capacity} и Count = {numbers1.Count}");

            numbers1.Capacity = 155;
            Console.WriteLine($"Задаем новый Capacity = {numbers1.Capacity}");

            numbers1.TrimExcess();
            Console.WriteLine($"После метода TrimExcess. Capacity = {numbers1.Capacity}. Count = {numbers1.Count}");

            Console.WriteLine();
            Console.WriteLine($"Обращение к элементу списка через индекс: {numbers1[13]}");
        }
    }
}