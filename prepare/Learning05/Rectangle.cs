class Rectangle : Shape
{
    private float[] _sides;
    public Rectangle(string color, float[] sides) : base(color)
    {
        _sides = sides;
    }

    public override float GetArea()
    {
        return _sides[0]*_sides[1];
    }
}