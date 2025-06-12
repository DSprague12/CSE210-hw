using System.IO.Compression;

public class Activity
{
    private int _interval;
    private int _frequency;

    public Activity(string interval, string frequency)
    {
        _interval = int.Parse(interval);
        _frequency = int.Parse(frequency);
    }
    public Activity()
    {
        _interval = 3;
        _frequency = 2;
    }

    public void Countdown()
    {
        Thread.Sleep(3 * 1000);
    }

    public void AnimatedCountdown()
    {
        string[] animations = [
            "\\(^_^)",
            "(^_^)",
            "(^_^)/",
            "\\(^_^)/"
        ];
        for (int j = 0; j < animations.Length; j++)
        {
            Console.Write(animations[j]);
            Thread.Sleep(750);
            for (int i = 0; i < animations[j].Length; i++)
            {
                Console.Write("\b");
            }
        }
    }
    public void SetVars()
    {
        Console.WriteLine("What duration would you like? ");
        _interval = int.Parse(Console.ReadLine());
        Console.WriteLine("How many times? ");
        _frequency = int.Parse(Console.ReadLine());
    }

    public int GetFrequency()
    {
        return _frequency;
    }
    public int GetInterval()
    {
        return _interval;
    }

    public void ShowCountDown()
    {
        for (int i = 0; i < _interval; i++)
        {
            Console.Write(_interval - i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
    }

}

public class Breathing : Activity
{
    private string _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    private List<string> _messages = ["Breathe In...", "Breathe Out..."];

    public Breathing()
    {
        
    }

    public void IntroMessage()
    {
        Console.WriteLine(_description);
        Countdown();
    }

    public void Breathe()
    {
        Console.Clear();
        for (int i = 0; i < GetFrequency(); i++)
        {
            Console.WriteLine(_messages[0]);
            ShowCountDown();
            Console.WriteLine(_messages[1]);
            ShowCountDown();
            Console.Clear();
        }
    }
}

public class Reflection : Activity
{
    private string _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    private List<string> _prompts = ["Think of a time when you stood up for someone else. ", "Think of a time when you did something really difficult. ", "Think of a time when you helped someone in need. ", "Think of a time when you did something truly selfless. "];
    private List<string> _questions = ["Why was this experience meaningful to you? ","Have you ever done anything like this before? ","How did you get started? ", "How did you feel when it was complete? ","What made this time different than other times when you were not as successful? ","What is your favorite thing about this experience? ","What could you learn from this experience that applies to other situations? ","What did you learn about yourself through this experience? ","How can you keep this experience in mind in the future? "];
    Random random = new Random();

    public Reflection()
    {
        
    }

    public void IntroMessage()
    {
        Console.WriteLine(_description);
        Countdown();
    }

    public void ReflectOnPrompt()
    {
        Console.WriteLine(_prompts[random.Next(0, _prompts.Count)]);
        Countdown();
    }

    public void ReflectOnQuestion()
    {
        for (int i = 0; i < GetFrequency(); i++)
        {
            Console.WriteLine(_questions[random.Next(0, _questions.Count)]);
            Console.CursorVisible = false;
            for (double j = 0; j < GetInterval(); j += 0.75)
            {
                AnimatedCountdown();
                Console.Clear();
            }
            Console.CursorVisible = true;
        }
    }
}

public class Listing : Activity
{
    private List<string> userInput = new List<string>();
    private string _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    private List<string> _messages = ["Please list your thoughts and responses: ","You wrote: ","Seconds Remaining: "];
    private List<string> _prompts = ["Who are people that you appreciate? ","What are personal strengths of yours? ","Who are people that you have helped this week? ","When have you felt the Holy Ghost this month? ","Who are some of your personal heroes?"];
    private string currentInput;
    Random random = new Random();

    public Listing()
    {

    }

    public void IntroMessage()
    {
        Console.WriteLine(_description);
        Countdown();
    }


    public void List()
    {
        Console.WriteLine(_prompts[random.Next(0, _prompts.Count)]);
        Countdown();
        Console.WriteLine(_messages[2]);
        ShowCountDown();
        Console.WriteLine(_messages[0]);
        DateTime startTime = DateTime.Now;
        while (DateTime.Now < startTime.AddSeconds(GetInterval()))
        {
            currentInput = Console.ReadLine();
            userInput.Add(currentInput);
        }
        Console.Clear();
        if (userInput.Count != 1)
        {
            Console.WriteLine(_messages[1] + userInput.Count + " items.");
        }
        else
        {
            Console.WriteLine(_messages[1] + "1 item.");
        }
    }
}