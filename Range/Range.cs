namespace Range;

public class Range
{
    public double From { get; set; }
    public double To { get; set; }

    public Range()
    {

    }

    public Range(double from, double to)
    {
        From = from;
        To = to;
    }

    public double GetLength() => To - From;

    public bool IsInside(double number) => number >= From && number <= To;

    public Range? IsIntersect(Range range)
    {
        if (To <= range.From)
        {
            return null;
        }

        return new Range(range.From, To);
    }

    public Range[] GetSum(Range range)
    {
        if (IsIntersect(range) == null)
        {
            Range[] result = [new Range(From, To), range];
            return result;
        }

        range.From = From;

        if (range.To < To)
        {
            range.To = To;
        }

        return [range];
    }

    public Range[] GetDifference(Range range)
    {
        if (IsIntersect(range) == null)
        {
            Range[] result = [new Range(From, To), range];
            return result;
        }

        range.To = range.From;
        range.From = From;

        if (range.To == range.From)
        {
            return new Range[0];
        }

        return [range];
    }
}