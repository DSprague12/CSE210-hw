using System;

class Program
{
    static void Main(string[] args)
    {
        string letter;
        bool passed = true;
        Console.WriteLine("Hello Prep2 World!");

        Console.WriteLine("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int gradePercent = int.Parse(userInput);

        Console.WriteLine(gradePercent);

        if (gradePercent >= 90){
            letter = "A";
        }else if (gradePercent <= 60){
            letter = "F";
            passed = false;
        }else if (gradePercent < 70){
            letter = "D";
            passed = false;
        }else if (gradePercent < 80){
            letter = "C";
        }else{
            letter = "B";
        }

        if(gradePercent!= 100){
            if(gradePercent % 10 < 3 && letter != "F"){
                letter += "-";
            }else if(gradePercent % 10 >= 7 && letter != "A" || letter != "F"){
                letter+= "+";
            }
        }

        Console.WriteLine($"Your letter grade is {letter}");

        if(passed){
            Console.WriteLine("Congrats! You passed!");
        }else {
            Console.WriteLine("You failed the class you blockhead");
        }
    }
}