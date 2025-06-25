class Eternal : Goal
{

    public Eternal(string goalText, int points, int iterations) : base(goalText, points, iterations)
    {

    }
    
    public override string ReturnClassifier()
    {
        return "e";
    }
}