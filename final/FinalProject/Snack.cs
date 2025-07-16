using System.Numerics;
using Raylib_cs;

abstract class Snack
{
    protected Vector2 _position;
    Random rnd = new Random();
    protected bool _ded = false;
    public Snack()
    {
        _position = new Vector2(rnd.Next(0, Program.boardSize), rnd.Next(0, Program.boardSize));
    }
    public Vector2 getPosition()
    {
        return _position;
    }

    public abstract void Draw();
    public abstract int getType();
    public bool isDed()
    {
        return _ded;
    }
    public abstract void Eaten();
}