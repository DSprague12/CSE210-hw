using System.Numerics;
using Raylib_cs;
class Wall : Snack
{
    Texture2D image;

    public Wall()
    {
        image = Raylib.LoadTexture("images/brik.png");
    }
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
        float scale = Program.squareSize / image.Width;
        Raylib.DrawTexturePro(
            image,
            new Rectangle(0,0,image.Width,image.Height),
            new Rectangle(_position.X*Program.squareSize+Program.squareSize/2,
            _position.Y*Program.squareSize+Program.squareSize/2,
            image.Width*scale, image.Height*scale),
            new Vector2(image.Width * scale / 2,
            image.Height * scale / 2),
            0,
            Color.White
        );
    }
}