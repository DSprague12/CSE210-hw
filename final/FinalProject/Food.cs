using System.Numerics;
using Raylib_cs;

class Food : Snack
{
    Texture2D _image;
    public Food(){
        _image = Raylib.LoadTexture("images/appel.png");
    }
    public override int getType()
    {
        return 0;
    }
    public override void Eaten()
    {

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