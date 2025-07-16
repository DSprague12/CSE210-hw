using System.Numerics;
using Raylib_cs;
class Wall : Snack
{
    private Texture2D _image;

    public Wall()
    {
        _image = Raylib.LoadTexture("images/brik.png");
    }
    public override int getType()
    {
        return 2;
    }
    public override void Eaten()
    {
        _ded = true;
    }
    public override void Draw()
    {
        float scale = Program.squareSize / _image.Width;
        Raylib.DrawTexturePro(
            _image,
            new Rectangle(0,0,_image.Width,_image.Height),
            new Rectangle(_position.X*Program.squareSize+Program.squareSize/2,
            _position.Y*Program.squareSize+Program.squareSize/2,
            _image.Width*scale, _image.Height*scale),
            new Vector2(_image.Width * scale / 2,
            _image.Height * scale / 2),
            0,
            Color.White
        );
    }
}