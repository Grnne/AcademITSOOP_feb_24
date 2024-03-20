namespace RangeTask;

public class Range
{
    public double From { get; set; }

    public double To { get; set; }

    public Range(double from, double to)
    {
        From = from;
        To = to;
    }

    public double GetLength() => To - From;

    public bool IsInside(double number) => number >= From && number <= To;

    public Range GetIntersection(Range range)
    {
        if (To <= range.From || From >= range.To)
        {
            return null;
        }

        return new Range(Math.Max(range.From, From), Math.Min(range.To, To));
    }

    public Range[] GetUnion(Range range)
    {
        if (To < range.From || From > range.To)
        {
            return new Range[] { new Range(From, To), new Range(range.From, range.To) };
        }

        return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
    }

    public Range[] GetDifference(Range range)
    {
        if (To <= range.From || From >= range.To)
        {
            return new Range[] { new Range(From, To) };
        }

        if (From >= range.From && To <= range.To)
        {
            return Array.Empty<Range>();
        }

        if (From < range.From && To > range.To)
        {
            return new Range[] { new Range(From, range.From), new Range(range.To, To) };
        }

        if (From < range.From)
        {
            return new Range[] { new Range(From, range.From) };
        }

        return new Range[] { new Range(range.To, To) };
    }

    public override string ToString()
    {
        return $"({From}, {To})";
    }
}