using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [new Square("green", 5), new Rectangle("blue", [3, 4]), new Circle("yellow", 6)];
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.getColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}