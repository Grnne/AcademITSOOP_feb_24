namespace ShapesTask;

internal class Program
{
    static void Main(string[] args) //TODO сделать остальные оверрайды. Вопрос, можно ли как-то использовать случайную генерацию объектов для моего массива?
    {
        List<IShape> shapes = new()
        { new Circle(10),
          new Rectangle(10, 10),
          new Square(10),
          new Triangle(0, 0, 0, 1, 1, 0),
          new Square(5)
        };

        shapes.Sort(new AreaComparer());
        Console.WriteLine("Характеристики фигуры с наибольшей площадью");
        int elementIndex = shapes.Count - 1;
        Console.WriteLine(shapes.ElementAt(elementIndex));

        Console.WriteLine();

        shapes.Sort(new PerimeterComparer());
        Console.WriteLine("Характеристики фигуры с вторым по величине периметром");
        elementIndex = shapes.Count - 2;
        Console.WriteLine(shapes.ElementAt(elementIndex));


    }
}