using System;
using System.Security.Cryptography.X509Certificates;

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
                journal.writeInJournal(promptEntry());
            }else if(input =="2"){
                journal.readJournal();
            }else if(input =="3"){
                journal.saveJournal(fileName());
            }else if(input == "4"){
                journal.fetchJournal(fileName());
            }else if(input=="0"){
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
    static string promptEntry(){
        Entry currentEntry = new Entry();
        string prompt =getPrompt();
        Console.WriteLine("Your prompt is:");
        Console.WriteLine(prompt);
        currentEntry.date=Convert.ToString(DateTime.Now);
        currentEntry.prompt=prompt;
        Console.WriteLine("Write your entry:");
        currentEntry.userEntry = Console.ReadLine();
        return currentEntry.fullEntry();
    }
}