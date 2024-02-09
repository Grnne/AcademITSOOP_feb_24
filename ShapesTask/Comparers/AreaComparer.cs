namespace ShapesTask;

public sealed class AreaComparer : Comparer<IShape>
{
    public override int Compare(IShape? shape1, IShape? shape2) => shape1.GetArea().CompareTo(shape2.GetArea());
}