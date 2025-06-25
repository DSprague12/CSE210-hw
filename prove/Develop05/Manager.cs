class Manager
{
    private string _filename;
    int userScore = 0;
    private string input = "";
    List<Goal> goalList = [new Simple("Example goal",100,1)];
    public Manager(string filename)
    {
        _filename = filename;
    }

    public void DisplayList()
    {
        foreach (Goal item in goalList)
        {
            if (!item.finished())
            {
                Console.WriteLine($"[ ] {item.getGoalText()}");
            }
            else
            {
                Console.WriteLine($"[X] {item.getGoalText()}");
            }
        }

    }
    public void DisplayPoints()
    {
        Console.WriteLine($"You have {userScore} points");
    }
    public void GetInput()
    {
        input = Console.ReadLine();
        Console.Clear();
    }

    public string returnInput()
    {
        return input;
    }

    public void CreateGoal()
    {
        Console.WriteLine("What kind?\n1. Simple goal\n2. Eternal goal\n3. Checklist goal");
        GetInput();
        Console.WriteLine("What is your goal?");
        string text = Console.ReadLine();
        Console.WriteLine("How many points is it worth?");
        int pontos = int.Parse(Console.ReadLine());
        if (input == "1")
        {
            goalList.Add(new Simple(text, pontos, 1));
        }
        else if (input == "2")
        {
            goalList.Add(new Eternal(text, pontos, -1));
        }
        else if (input == "3")
        {
            Console.WriteLine("How many times?");
            string it = Console.ReadLine();
            goalList.Add(new Checklist(text, pontos, int.Parse(it)));
        }
    }

    public void WriteFile()
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            foreach (Goal goal in goalList)
            {
                outputFile.WriteLine(goal.ReturnClassifier());
                outputFile.WriteLine(goal.getGoalText());
                if (goal.ReturnClassifier() == "c")
                {
                    outputFile.WriteLine($"{goal.getPoints()},{goal.getIterations()}");
                }
                else
                {
                    outputFile.WriteLine(goal.getPoints());
                }
            }
        }
    }

    public void ReadFile()
    {
        string[] lines = System.IO.File.ReadAllLines(_filename);
        List<Goal> ogList = [];
        for (int i = 0; i < lines.Length; i += 3)
        {
            if (lines[i][0] == char.Parse("s"))
            {
                ogList.Add(new Simple(lines[i + 1], int.Parse(lines[i + 2]), 1));
            }
            else if (lines[i] == "e")
            {
                ogList.Add(new Eternal(lines[i + 1], int.Parse(lines[i + 2]), -1));
            }
            else if (lines[i] == "c")
            {
                string[] numbers = lines[i + 2].Split(",");
                ogList.Add(new Checklist(lines[i + 1], int.Parse(numbers[0]), int.Parse(numbers[1])));
            }
        }
        goalList = ogList;
    }

    public void RecordEvent()
    {
        DisplayList();
        Console.WriteLine("Which one did you complete?");
        input = Console.ReadLine();
        Goal currentGoal = goalList[int.Parse(input) - 1];
        if (currentGoal.ReturnClassifier() == "s")
        {
            goalList[int.Parse(input) - 1].setDone();
        }
        else if (currentGoal.ReturnClassifier() == "c")
        {
            currentGoal.MoveIteration();
            if (currentGoal.getIterations() < 1)
            {
                currentGoal.setDone();
            }
        }
        userScore += currentGoal.getPoints();
}

}
