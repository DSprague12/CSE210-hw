using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assign1 = new Assignment("Bob", "Cool assignment");
        assign1.GetSummary();

        MathAssignment math1 = new MathAssignment("Joe", "matematica", "Radicals", "Chapter 1");
        math1.GetSummary();
        math1.GetHomeworkList();

        WritingAssignment write1 = new WritingAssignment("Dave", "writing1", "Revolutions");
        write1.GetSummary();
        write1.GetWritingSummary();
    }
}

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public void GetSummary()
    {
        Console.WriteLine($"{_studentName} - {_topic}");
    }
}

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public void GetHomeworkList()
    {
        Console.WriteLine($"{_textbookSection} - {_problems}");
    }
}

public class WritingAssignment : Assignment
{
    private string _title;
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }
    public void GetWritingSummary()
    {
        Console.WriteLine(_title);
    }
}