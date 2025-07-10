using Raylib_cs;
class Board
{    
    public Board()
    {

    }

// draws board (idk what to do about converting stuff to ints, it'll pan out when I use textures)
    public void buildBoard()
    {
        for (int i = 0; i < Program.boardSize; i++)
        {
            for (int j = 0; j < Program.boardSize; j++)
            {
                Raylib.DrawRectangle(j * (int)Program.squareSize + 1, i * (int)Program.squareSize + 1, (int)Program.squareSize - 2, (int)Program.squareSize - 2, Color.Black);
            }
        }
    }
}