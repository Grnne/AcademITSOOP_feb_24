namespace RangeTask;

public class RangeTask
{
    public double From { get; set; }

    public double To { get; set; }

    public RangeTask(double from, double to)
    {
        From = from;
        To = to;
    }

    public double GetLength() => To - From;

    public bool IsInside(double number) => number >= From && number <= To;

    public RangeTask? IsIntersect(RangeTask range)
    {
        if (To <= range.From)
        {
            return null;
        }

        return new RangeTask(range.From, To);
    }

    public RangeTask[] GetSum(RangeTask range)
    {
        if (IsIntersect(range) == null)
        {
            RangeTask[] result = [new RangeTask(From, To), range];
            return result;
        }

        range.From = From;

        if (range.To < To)
        {
            range.To = To;
        }

        return [range];
    }

    public RangeTask[] GetDifference(RangeTask range)
    {
        if (IsIntersect(range) == null)
        {
            RangeTask[] result = [new RangeTask(From, To), range];
            return result;
        }

        range.To = range.From;
        range.From = From;

        if (range.To == range.From)
        {
            return new RangeTask[0];
        }

        return [range];
    }
}