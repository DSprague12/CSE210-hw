using System.Numerics;
using Raylib_cs;

class Food : Snack
{
    public override int getType()
    {
        return 0;
    }
    public override void Eaten()
    {

    }
    public override void Draw()
    {
        Raylib.DrawCircle((int)(_position.X * Program.squareSize + Program.squareSize / 2),
        (int)(_position.Y * Program.squareSize + Program.squareSize / 2), Program.squareSize / 2, Color.Green);
    }
}