using Raylib_cs;
class Wall : Snack
{
    public override int getType()
    {
        return 2;
    }
    public override void Eaten()
    {
        ded = true;
    }
    public override void Draw()
    {
        Raylib.DrawCircle((int)(_position.X * Program.squareSize + Program.squareSize / 2),
        (int)(_position.Y * Program.squareSize + Program.squareSize / 2), Program.squareSize / 2, Color.Orange);
    }
}