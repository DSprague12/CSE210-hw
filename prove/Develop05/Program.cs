using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Manager manager = new Manager("GoalList.txt");
            string loopInput = "";
            while (loopInput != "6")
            {
                Console.WriteLine("Select an option:\n1. Create new goal\n2. List Goals\n3. Save goals\n4. Load goals\n5. Record event\n6. Quit");
                loopInput = Console.ReadLine();
                if (loopInput == "1")
                {
                    manager.CreateGoal();
                }
                else if (loopInput == "2")
                {
                    manager.DisplayList();
                    manager.DisplayPoints();
                }
                else if (loopInput == "3")
                {
                    manager.WriteFile();
                }
                else if (loopInput == "4")
                {
                    manager.ReadFile();
                }

                else if (loopInput == "5")
                {
                    manager.RecordEvent();
                }

            }
        }
        catch
        {
            Console.WriteLine("You typed something wrong, do better my friend");
        }
    }
}