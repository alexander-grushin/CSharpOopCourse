namespace RangeTask
{
    internal class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public Range() : this(0, 0)
        {
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersections(Range range)
        {
            Range newRange = new Range();

            if (range.From >= From && range.From <= To)
            {
                newRange.From = range.From;

                if (range.To < To)
                {
                    newRange.To = range.To;

                    return newRange;
                }

                newRange.To = To;

                return newRange;
            }

            return null;
        }

        public Range[] GetMerger(Range range)
        {
            Range[] newRanges = new Range[2];

            newRanges[0] = new Range();
            newRanges[1] = new Range();

            if (To < range.From || From > range.To)
            {
                newRanges[0].From = From;
                newRanges[0].To = To;
                
                newRanges[1].From = range.From;
                newRanges[1].To = range.To;

                return newRanges;
            }

            newRanges[0].From = Math.Min(From, range.From);
            newRanges[0].To = Math.Max(To, range.To);
            
            return newRanges;
        }

        public Range[] GetDifference(Range range)
        {
            Range[] newRanges = new Range[2];
            
            newRanges[0] = new Range();
            newRanges[1] = new Range();

            if (From == range.From && range.To >= To)
            {
                return newRanges;
            }

            if (GetIntersections(range) is null)
            {
                newRanges[0].From = From;
                newRanges[0].To = To;

                return newRanges;
            }

            newRanges[0].From = From; 
            newRanges[0].To = range.From;
                
            if (range.To < To)
            {
                newRanges[1].From = range.To;
                newRanges[1].To = To;
            }

            return newRanges;
        }
    }
}
