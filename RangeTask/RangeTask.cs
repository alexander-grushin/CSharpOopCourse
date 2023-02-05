using System;

namespace RangeTask
{
    internal class RangeTask
    {
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

            Range range2 = new Range(from2, to2);

            Console.WriteLine($"Диапазон 1 = ({range1.From}, {range1.To})");
            Console.WriteLine($"Диапазон 2 = ({range2.From}, {range2.To})");
            Console.WriteLine();

            Range intersectionsRange = new Range();
            intersectionsRange = range1.GetIntersections(range2);

            if (intersectionsRange is not null)
            {
                Console.WriteLine($"Пересечения: ({intersectionsRange.From}, {intersectionsRange.To})");
            }
            else
            {
                Console.WriteLine("Пересечения нет (Range is null).");
            }

            Range[] mergerRanges = new Range[2];
            mergerRanges = range1.GetMerger(range2);

            Console.WriteLine();
            Console.WriteLine($"Объединения:");

            foreach (var range in mergerRanges)
            {
                Console.WriteLine($"({range.From}, {range.To})");
            }

            Range[] differenceRanges = new Range[2];
            differenceRanges = range1.GetDifference(range2);

            Console.WriteLine();
            Console.WriteLine($"Разность:");

            foreach (var range in differenceRanges)
            {
                Console.WriteLine($"({range.From}, {range.To})");
            }
        }
    }
}