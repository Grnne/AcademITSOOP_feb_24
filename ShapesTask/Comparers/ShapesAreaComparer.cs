using ShapesTask.Shapes;

namespace ShapesTask.Comparers;

public class ShapesAreaComparer : Comparer<IShape>
{
    public override int Compare(IShape? shape1, IShape? shape2) => shape1!.GetArea().CompareTo(shape2!.GetArea());
}