namespace RangeTask
{
    internal class RangeTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Использование класса Range.");

            Console.WriteLine("Введите начало диапазона:");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец диапазона:");
            double to = Convert.ToDouble(Console.ReadLine());

            Range range = new Range(from, to);

            Console.WriteLine($"Длина диапазона от {range.From} до {range.To} => {range.GetLength()}");

            Console.WriteLine("Введите число для проверки принадлежности к данному диапазону:");
            double number = Convert.ToDouble(Console.ReadLine());

            if (range.IsInside(number))
            {
                Console.WriteLine("Число в диапазоне!");
            }
            else
            {
                Console.WriteLine("Число не в диапазоне!");
            }
        }
    }
}