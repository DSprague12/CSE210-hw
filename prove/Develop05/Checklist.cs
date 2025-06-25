class Checklist : Goal
{
    public Checklist(string goalText, int points, int iterations) : base(goalText, points, iterations)
    {

    }

    public override string ReturnClassifier()
    {
        return "c";
    }
    
}