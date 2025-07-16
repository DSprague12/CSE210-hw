using Raylib_cs;

class GameController
{
    Random rnd = new Random();
    Snake snek = new Snake();
    Board board = new Board();
    List<Snack> _munchies = new List<Snack>();
    public GameController()
    {
        _munchies.Add(new Food());
        _munchies.Add(new Food());
        _munchies.Add(new Food());
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
 
        for (int i = 0; i < _munchies.Count; i++)
        {
            if (snek.getPosition()[0] == _munchies[i].getPosition())
            {
                snek.Grow();
                _munchies[i].Eaten();
                toDelete.Add(i);

                if (_munchies[i].isDed()) snek.setDed();
                if (_munchies[i].getType() == 1) _munchies.Add(new Wall());
                if (_munchies[i].getType() == 2) snek.setDed();
            }
        }

        // remove snacks in reverse
        foreach (int index in toDelete.OrderByDescending(i => i))
            _munchies.RemoveAt(index);

        // adds snacks back
        for (int i = 0; i < toDelete.Count; i++)
        {
            int type = rnd.Next(0, 2);
            if (type == 0)
            {
                _munchies.Add(new Food());
            }
            else if (type == 1)
            {
                _munchies.Add(new WallFood());
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
        foreach (Snack munchie in _munchies) munchie.Draw();
        Raylib.EndDrawing();
    }

}