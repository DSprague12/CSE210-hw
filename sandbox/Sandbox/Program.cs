using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What's the radius? ");
        string dog = Console.ReadLine();
        double radius = double.Parse(dog);

        double area = Math.PI * radius * radius;
        Console.WriteLine($"The area is {area}");
    }
}