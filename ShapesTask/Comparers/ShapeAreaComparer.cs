﻿using ShapesTask.Shapes;

namespace ShapesTask.Comparers;

public class ShapeAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 is null)
        {
            throw new ArgumentNullException(nameof(shape1), "Shapes must be not null");
        }

        if (shape2 is null)
        {
            throw new ArgumentNullException(nameof(shape2), "Shapes must be not null");
        }

        return shape1.GetArea().CompareTo(shape2.GetArea());
    }
}