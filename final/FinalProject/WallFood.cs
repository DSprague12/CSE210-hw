using System.Numerics;
using Raylib_cs;
class WallFood : Snack
{
    Texture2D image;

    public WallFood()
    {
        image = Raylib.LoadTexture("images/pip.png");
    }
    public override int getType()
    {
        return 1;
    }
    public override void Eaten()
    {

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