using System.Numerics;
using Raylib_cs;
using System.Collections.Generic;

class Snake
{
    List<Vector2> _positions;
    List<int> _rotations;
    List<Vector2> _previousPositions;
    List<Vector2> _renderPositions;
    private Vector2 lastInput = new Vector2(1, 0);
    private bool ded = false;
    Texture2D image;
    Texture2D imageSeg;

    public Snake()
    {
        image = Raylib.LoadTexture("images/snekhead.png");
        imageSeg = Raylib.LoadTexture("images/segment.png");
        _positions = new List<Vector2>()
        {
            new Vector2(Program.boardSize / 2, Program.boardSize / 2),
            new Vector2(Program.boardSize / 2, Program.boardSize / 2),
            new Vector2(Program.boardSize / 2, Program.boardSize / 2)
        };
        _previousPositions = new List<Vector2>(_positions);

        _rotations = new List<int>(){90,90,90};
        // Initialize render positions the same
        _renderPositions = new List<Vector2>(_positions.Count);
        for (int i = 0; i < _positions.Count; i++)
            _renderPositions.Add(_positions[i]);
    }

    public List<Vector2> getPosition()
    {
        return _positions;
    }

    public void Grow()
    {
        Vector2 newPosition = _positions[_positions.Count - 1];
        _positions.Add(newPosition);
        _previousPositions.Add(newPosition);
        _renderPositions.Add(newPosition);
        _rotations.Add(_rotations[_rotations.Count-1]);
    }

    public bool isDed()
    {
        return ded;
    }
    public void setDed()
    {
        ded = true;
    }

    public void iterateStep()
    {
        // copy previous positions or whatever
        _previousPositions = new List<Vector2>(_positions);

        Vector2 head = _positions[0];
        lastInput = getInput();

        // follow the next segment
        for (int i = _positions.Count - 1; i > 0; i--)
        {
            _positions[i] = _positions[i - 1];
        }
        for (int i = _rotations.Count - 1; i > 0; i--)
        {
            _rotations[i] = _rotations[i - 1];
        }

        head += lastInput;

        // kill snake if you hit wall weh weh
        if (head.X < 0 || head.X >= Program.boardSize) ded = true;
        if (head.Y < 0 || head.Y >= Program.boardSize) ded = true;

        // self collision, doesn't work, later problem
        for (int i = 1; i < _positions.Count - 1; i++)
        {
            if (head == _positions[i]) ded = true;
        }

        _positions[0] = head;
    }

    public void animateSubstep(float alpha)
    {
        // interpolate between positions (idk what lerp does, but it works and it's cool)
        for (int i = 0; i < _positions.Count; i++)
        {
            Vector2 interp = Vector2.Lerp(_previousPositions[i], _positions[i], alpha);
            _renderPositions[i] = interp;
        }
    }

    public void drawSnek()
    {
        // draw head
        float scale = Program.squareSize / image.Width;
        Vector2 headPos = _renderPositions[0] * Program.squareSize;
        Raylib.DrawTexturePro(
            image,
            new Rectangle(0, 0, image.Width, image.Height),
            new Rectangle(
            headPos.X + Program.squareSize / 2,
            headPos.Y + Program.squareSize / 2,
            image.Width * scale,
            image.Height * scale),
            new Vector2(image.Width * scale / 2, image.Height * scale / 2),
            _rotations[0],
            Color.White);

        // draw body circles
        for (int i = 1; i < _renderPositions.Count; i++)
        {
            Vector2 bodyPos = _renderPositions[i] * Program.squareSize;
            Raylib.DrawTexturePro(
            imageSeg,
            new Rectangle(0, 0, imageSeg.Width, imageSeg.Height),
            new Rectangle(
            bodyPos.X + Program.squareSize / 2,
            bodyPos.Y + Program.squareSize / 2,
            imageSeg.Width * scale,
            imageSeg.Height * scale),
            new Vector2(imageSeg.Width * scale / 2, imageSeg.Height * scale / 2),
            _rotations[i-1],
            Color.White);
        }
    }
    public void runningInputQueue()
    {
        lastInput = getInput();
    }
    public Vector2 getInput()
    {
        Vector2 newInput = lastInput;

        if (Raylib.IsKeyPressed(KeyboardKey.Right)) { newInput = new Vector2(1, 0); _rotations[0] = 90; }
        if (Raylib.IsKeyPressed(KeyboardKey.Left)) { newInput = new Vector2(-1, 0); _rotations[0] = -90; }
        if (Raylib.IsKeyPressed(KeyboardKey.Up)) { newInput = new Vector2(0, -1); _rotations[0] = 0; }
        if (Raylib.IsKeyPressed(KeyboardKey.Down)) { newInput = new Vector2(0, 1); _rotations[0] = 180; }


        // no backwards
        if (newInput + lastInput != Vector2.Zero)
        {
            return newInput;
        }

        return lastInput;
    }
}