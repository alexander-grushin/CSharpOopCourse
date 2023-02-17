namespace RangeTask
{
    internal class RangeTask
    {
        static void PrintRanges(Range[] ranges)
        {
            int rangesLength = ranges.Length;

            if (rangesLength == 0)
            {
                Console.Write("[]");

                return;
            }

            Console.Write("[");

            for (int i = 0; i < rangesLength - 1; i++)
            {
                Console.Write($"{ranges[i]}, ");
            }

            Console.Write(ranges[rangesLength - 1]);

            Console.Write("]");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Использование класса Range*.");

            Console.WriteLine("Введите начало первого диапазона:");
            double from1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец первого диапазона:");
            double to1 = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(from1, to1);

            Console.WriteLine("Введите начало второго диапазона:");
            double from2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец второго диапазона:");
            double to2 = Convert.ToDouble(Console.ReadLine());

            Console.Clear();

            Range range2 = new Range(from2, to2);

            Console.WriteLine($"Диапазон 1 = {range1}");
            Console.WriteLine($"Диапазон 2 = {range2}");
            Console.WriteLine();

            Range? intersectionRange = range1.GetIntersection(range2);

            if (intersectionRange is not null)
            {
                Console.WriteLine($"Пересечения: {intersectionRange}");
            }
            else
            {
                Console.WriteLine("Пересечения нет (Range is null).");
            }

            Range[] unionRanges = range1.GetUnion(range2);

            Console.WriteLine();
            Console.Write("Объединения: ");

            PrintRanges(unionRanges);
            Console.WriteLine();

            Range[] differenceRanges = range1.GetDifference(range2);

            Console.WriteLine();
            Console.Write("Разность: ");

            PrintRanges(differenceRanges);
        }
    }
}