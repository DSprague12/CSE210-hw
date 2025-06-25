class Simple : Goal
{
    public Simple(string goalText, int points, int iterations) : base(goalText, points, iterations)
    {

    }

    public override string ReturnClassifier()
    {
        return "s";
    }
}