using ShapesTask.Shapes;

namespace ShapesTask.Comparers;

public sealed class ShapesPerimeterComparer : Comparer<IShape>
{
    public override int Compare(IShape? shape1, IShape? shape2) => shape1!.GetPerimeter().CompareTo(shape2!.GetPerimeter());
}