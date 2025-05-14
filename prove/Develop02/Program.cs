using System;
using System.Security.Cryptography.X509Certificates;

/* 
This it the journal project. I have fulfilled all requirements, but for the stretch activity, I struggled on properly handly commas in csv files.
So I figured out a way to encode the text into bit64, which is pretty simple to do, and save that in the file instead of the plain text.
It removes the need to handles commas and it functions to make your journal unreadable in a normal text editor without converting it back, which I count as a bonus.
The con there is that you can't read it in excel, but I don't think that's a big deal I guess.
*/

class Program
{ 
    //Fetch prompts and random
    public static string[] promptList = System.IO.File.ReadAllLines("prompts.txt");
    public static Random rnd = new Random();

    static void Main(string[] args)
    {
        bool continuePrompting = true;
        Journal journal = new Journal();

        //Prompt the user for the choice
        while(continuePrompting){
            Console.WriteLine("Would you like to:\n0: End program\n1: Write an entry\n2: Display the journal\n3: Save the journal\n4: Load the journal\nType the number to select your option");
            string input = Console.ReadLine();

            if(input == "1"){
                journal.journalStage.Add(promptEntry());
            }else if(input == "2"){
                journal.readJournal();
            }else if(input == "3"){
                journal.saveJournal(fileName());
            }else if(input == "4"){
                journal.fetchJournal(fileName());
            }else if(input == "0"){
                continuePrompting = false;
            }else{
                Console.WriteLine("Bad input");
            }
        }
    }

//Returns a random prompt
    static string getPrompt(){
        return promptList[rnd.Next(promptList.Length)];
    }

//Prompts for the file path, null is default
    static string fileName(){
        Console.WriteLine("What is the file location? Press enter for default journal.csv");
        string input = Console.ReadLine();
        if(string.IsNullOrEmpty(input)){
            input="journal.csv";
        }
        return input;
    }

//What happens when the user wants to write an entry, it returns what will be written in the file
    static string[] promptEntry(){
        Entry currentEntry = new Entry();
        currentEntry.prompt = getPrompt();
        Console.WriteLine($"Your prompt is: {currentEntry.prompt}");
        currentEntry.date = Convert.ToString(DateTime.Now);
        Console.WriteLine("Write your entry:");
        currentEntry.userEntry = Console.ReadLine();
        return currentEntry.fullEntry();
    }
}