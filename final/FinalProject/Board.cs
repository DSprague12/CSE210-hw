using System.Numerics;
using Raylib_cs;
class Board
{
    Texture2D _image1;
    Texture2D _image2;
    Texture2D tempImg;
    public Board()
    {
        _image1 = Raylib.LoadTexture("images/bord1.png");
        _image2 = Raylib.LoadTexture("images/bord2.png");
    }

    // draws board (idk what to do about converting stuff to ints, it'll pan out when I use textures)
    public void buildBoard()
    {
        float scale = Program.squareSize / _image1.Width;
        for (int i = 0; i < Program.boardSize; i ++)
        {
            for (int j = 0; j < Program.boardSize; j += 2)
            {
                Raylib.DrawTexturePro(
                    _image1,
                    new Rectangle(0, 0, _image1.Width, _image1.Height),
                    new Rectangle(j * Program.squareSize+Program.squareSize,
                    i * Program.squareSize + Program.squareSize / 2,
                    _image1.Width * scale, _image1.Height * scale),
                    new Vector2(Program.squareSize,
                    _image1.Height * scale / 2),
                    0,
                    Color.White
                );
                Raylib.DrawTexturePro(
                    _image2,
                    new Rectangle(0, 0, _image2.Width, _image2.Height),
                    new Rectangle((j + 1) * Program.squareSize+Program.squareSize,
                    i * Program.squareSize + Program.squareSize / 2,
                    _image2.Width * scale, _image2.Height * scale),
                    new Vector2(Program.squareSize,
                    _image2.Height * scale / 2),
                    0,
                    Color.White
                );
            }
            tempImg = _image1;
            _image1 = _image2;
            _image2 = tempImg;
        }
        
    }
}