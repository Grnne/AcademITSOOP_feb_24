using ShapesTask.Comparers;
using ShapesTask.Shapes;

namespace ShapesTask;

internal class Program
{
    static void Main(string[] args)
    {
        List<IShape> shapes = new()
        { new Circle(10),
          new Rectangle(10, 10),
          new Square(10),
          new Triangle(0, 0, 0, 1, 1, 0),
          new Square(5)
        };

        foreach (IShape shape in shapes)
        {
            Console.WriteLine(shape);
        }

        Console.WriteLine();

        shapes.Sort(new ShapesAreaComparer());
        Console.WriteLine("Характеристики фигуры с наибольшей площадью");
        int elementIndex = shapes.Count - 1;
        Console.WriteLine(shapes[elementIndex]);

        Console.WriteLine();

        shapes.Sort(new ShapesPerimeterComparer());
        Console.WriteLine("Характеристики фигуры с вторым по величине периметром");
        elementIndex = shapes.Count - 2;
        Console.WriteLine(shapes[elementIndex]);
    }
}