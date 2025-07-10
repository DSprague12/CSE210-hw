using Raylib_cs;

class GameController
{
    Random rnd = new Random();
    Snake snek = new Snake();
    Board board = new Board();
    List<Snack> munchies = new List<Snack>();
    Screen screen = new Screen();
    public GameController()
    {
        munchies.Add(new Food());
        munchies.Add(new Food());
        munchies.Add(new Food());
    }

    public void Loop(float alpha)
    {
        if (snek.isDed())
        {
            Program.gameOver = true;
        }

        if (alpha>0)
        {
            snek.animateSubstep(alpha);
            return;
        }
        else
        {
            snek.iterateStep();
        }

        List<int> toDelete = new();
 
        for (int i = 0; i < munchies.Count; i++)
        {
            if (snek.getPosition()[0] == munchies[i].getPosition())
            {
                snek.Grow();
                munchies[i].Eaten();
                toDelete.Add(i);

                if (munchies[i].isDed()) snek.setDed();
                if (munchies[i].getType() == 1) munchies.Add(new Wall());
                if (munchies[i].getType() == 2) snek.setDed();
            }
        }

        // remove snacks in reverse
        foreach (int index in toDelete.OrderByDescending(i => i))
            munchies.RemoveAt(index);

        // adds snacks back
        for (int i = 0; i < toDelete.Count; i++)
        {
            int type = rnd.Next(0, 2);
            if (type == 0)
            {
                munchies.Add(new Food());
            }
            else if (type == 1)
            {
                munchies.Add(new WallFood());
            }
        }
    }
    public void runningBackground()
    {
        snek.runningInputQueue();
    }
    // draws graphics
    public void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        board.buildBoard();
        snek.drawSnek();
        foreach (Snack munchie in munchies) munchie.Draw();
        Raylib.EndDrawing();
    }

}