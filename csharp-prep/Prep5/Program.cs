using System;

class Program
{
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName(){
        Console.WriteLine("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber(){
        Console.WriteLine("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number){
        return number * number;
    }
    static void DisplayResult(string name, int number){
        Console.WriteLine($"{name}, your favorite number squared is {number}");
    }
    static void Main(string[] args)
    {
        //This looks funny lol
        DisplayResult(PromptUserName(), SquareNumber(PromptUserNumber()));
    }
}