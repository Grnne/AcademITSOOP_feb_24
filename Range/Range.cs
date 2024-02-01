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


    public double GetLength(double From, double To) => From - To;

    public bool IsInside()
    {
        return true;
    }

    public Range Intersect()
    {
        return new Range();
    }

    public Range[] Sum()
    {
        return new Range[0];
    }

    public Range[] GetDifference()
    {
        return new Range[0];
    }

}
