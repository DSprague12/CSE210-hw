using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        
        while (true)
        {
            scripture.DisplayScripture();
            
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden!");
                break;
            }

            Console.WriteLine("Press enter to continue or type anything to quit:");
            string input = Console.ReadLine();

            if (input == "")
            {
                scripture.HideRandomWords();
            }
            else
            {
                break;
            }
        }
    }
}