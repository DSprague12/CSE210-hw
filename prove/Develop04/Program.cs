using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("What option would yo like to do? ");
        Console.WriteLine("0 Quit\n1 Breathe\n2 Reflect\n3 List");
        string input = Console.ReadLine();
        Console.Clear();
        if (input == "1")
        {
            Breathing breathing = new Breathing();
            breathing.IntroMessage();
            breathing.SetVars();
            breathing.Breathe();
        }
        else if (input == "2")
        {
            Reflection reflection = new Reflection();
            reflection.IntroMessage();
            reflection.SetVars();
            reflection.ReflectOnPrompt();
            reflection.ReflectOnQuestion();
        }
        else if (input == "3")
        {
            Listing listing = new Listing();
            listing.IntroMessage();
            listing.SetVars();
            listing.List();
        }
        Console.WriteLine("Thank you for participating");
    }
}