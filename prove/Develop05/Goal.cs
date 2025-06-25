public abstract class Goal
{
    private bool _completed = false;
    private int _points;
    private string _goalText;
    private int _iterations;
    public Goal(string goalText, int points)
    {
        _goalText = goalText;
        _points = points;
        _iterations = 1;
    }
    public Goal(string goalText, int points, int iterations)
    {
        _goalText = goalText;
        _points = points;
        _iterations = iterations;
    }

    public string getGoalText()
    {
        return _goalText;
    }
    public int getIterations()
    {
        return _iterations;
    }
    public int getPoints()
    {
        return _points;
    }

    public bool finished()
    {
        return _completed;
    }
    public void MoveIteration()
    {
        _iterations-=1;
    }
    public void setDone()
    {
        _completed = true;
    }

    public abstract string ReturnClassifier();
}