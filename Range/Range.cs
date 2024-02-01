namespace Range;

public class Range
{
    public double From { get; set; }
    public double To { get; set; }

    public Range()
    {

    }

    public double GetLength()
    {
        return 0;
    }

    public bool IsInside()
    {
        return true;
    }
}
