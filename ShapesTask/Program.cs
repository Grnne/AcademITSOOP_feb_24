namespace ShapesTask;

internal class Program
{
    static void Main(string[] args) //TODO сделать оверрайды. Вопрос, можно ли как-то использовать случайную генерацию объектов для моего массива?
    {
        // Можно ли объявить массив в краткой форме аля List<IShape> shapes = [ new Circle(10) ]?
        List<IShape> shapes = new List<IShape> { new Circle(10), new Rectangle(10, 10),
        new Square(10), new Triangle(0, 0, 0, 1, 1, 0), new Square(5) };

        shapes.Sort((x, y) => y.GetArea().CompareTo(x.GetArea())); // Сортировка через делегат выглядит как-то неправильно, возможно надо иначе

        Console.WriteLine("Параметры двух самых больших фигур.");
        for (int i = 0; i < 2; i++)
        {
            Console.Write($"Площадь фигуры: {shapes.ElementAt(i).GetArea():f2}; периметр: {shapes.ElementAt(i).GetPerimeter():f2};");
            Console.Write($" высота: {shapes.ElementAt(i).GetHeight():f2} и ширина {shapes.ElementAt(i).GetWidth():f2}.");
            Console.WriteLine($"Тип фигуры: { shapes.ElementAt(i).GetType()}");
        }
    }
}