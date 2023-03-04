using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayListHomeTask
{
    internal class ArrayListHomeTask
    {
        public static List<string> GetLinesFromFile(string filePath)
        {
            using StreamReader reader = new StreamReader(filePath);

            List<string> lines = new List<string>();

            string? currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                lines.Add(currentLine);
            }

            return lines;
        }

        public static void RemoveEvenNumbers(List<int> numbers)
        {
            int index = 0;

            while (index != numbers.Count)
            {
                if (numbers[index] % 2 == 0)
                {
                    numbers.RemoveAt(index);

                    index--;

                    if (index <= 0)
                    {
                        index = 0;
                    }
                }
                else
                {
                    index++;
                }
            }
        }

        public static List<int> GetNewNumbersWithoutRepeats(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                return new List<int>();
            }

            List<int> resultNumbers = new List<int> { numbers[0] };

            for (int i = 1; i < numbers.Count; i++)
            {
                if (!resultNumbers.Contains(numbers[i]))
                {
                    resultNumbers.Add(numbers[i]);
                }
            }

            return resultNumbers;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задача ArrayListHome.");
            Console.WriteLine();

            Console.WriteLine("1. Прочитать в список все строки из файла:");
            Console.WriteLine();

            string filePath = "..\\..\\..\\input.txt";

            List<string> lines = GetLinesFromFile(filePath);

            Console.WriteLine($"Количество строк = {lines.Count}");
            Console.WriteLine();

            Console.WriteLine(string.Join(Environment.NewLine, lines));
            Console.WriteLine();

            Console.WriteLine("2. Удалить из списка все четные числа:");
            Console.WriteLine();

            List<int> numbers1 = new List<int> { 6, 3, -4, 4, 2, 1, 1, 0, -7, 10 };

            Console.WriteLine($"Задан список чисел: {string.Join(", ", numbers1)}");

            RemoveEvenNumbers(numbers1);

            Console.WriteLine($"Результат: {string.Join(", ", numbers1)}");
            Console.WriteLine();

            Console.WriteLine("3. Создать новый список без повторений из списка с повторяющимися числами:");
            Console.WriteLine();

            List<int> numbers2 = new List<int> { 3, 3, -2, 4, -2, 1, 1, 0, 7, -5, 0, 0, 7 };

            Console.WriteLine($"Задан список чисел: {string.Join(", ", numbers2)}");

            List<int> numbersWithoutRepeats = GetNewNumbersWithoutRepeats(numbers2);

            Console.WriteLine($"Результат: {string.Join(", ", numbersWithoutRepeats)}");
        }
    }
}