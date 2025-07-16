using System.Numerics;
using Raylib_cs;
class Board
{
    Texture2D image1;
    Texture2D image2;
    Texture2D tempImg;
    public Board()
    {
        image1 = Raylib.LoadTexture("images/bord1.png");
        image2 = Raylib.LoadTexture("images/bord2.png");
    }

    // draws board (idk what to do about converting stuff to ints, it'll pan out when I use textures)
    public void buildBoard()
    {
        float scale = Program.squareSize / image1.Width;
        for (int i = 0; i < Program.boardSize; i ++)
        {
            for (int j = 0; j < Program.boardSize; j += 2)
            {
                Raylib.DrawTexturePro(
                    image1,
                    new Rectangle(0, 0, image1.Width, image1.Height),
                    new Rectangle(j * Program.squareSize+Program.squareSize,
                    i * Program.squareSize + Program.squareSize / 2,
                    image1.Width * scale, image1.Height * scale),
                    new Vector2(Program.squareSize,
                    image1.Height * scale / 2),
                    0,
                    Color.White
                );
                Raylib.DrawTexturePro(
                    image2,
                    new Rectangle(0, 0, image2.Width, image2.Height),
                    new Rectangle((j + 1) * Program.squareSize+Program.squareSize,
                    i * Program.squareSize + Program.squareSize / 2,
                    image2.Width * scale, image2.Height * scale),
                    new Vector2(Program.squareSize,
                    image2.Height * scale / 2),
                    0,
                    Color.White
                );
            }
            tempImg = image1;
            image1 = image2;
            image2 = tempImg;
        }
        
    }
}