using System;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
class Program
{
    // base variables for the game
    public static int boardSize = 10;
    public static float screenSize = 1000;
    public static float squareSize = screenSize / boardSize;
    public static bool gameOver = false;
    static void Main(string[] args)
    {
        // frame space is the time between frames
        float frameSpace = 0.5f;
        Raylib.InitWindow((int)screenSize, (int)screenSize, "Snake");
        // fps is set differently for responsiveness
        Raylib.SetTargetFPS(30);
        GameController gameController = new GameController();
        Screen screen = new Screen();
        float deltaTime;
        float accumulatedTime = 0;
        bool started = false;
        while (!Raylib.WindowShouldClose())
        {
            if (gameOver)
            {
                screen.DrawLoser();
                Thread.Sleep(1000);
                return;
            }
            deltaTime = Raylib.GetFrameTime();
            accumulatedTime += deltaTime;
            // iterate game logic after a set amount of time

            if (started)
            {
                while (accumulatedTime >= frameSpace)
                {
                    gameController.Loop(0f);
                    accumulatedTime -= frameSpace;
                }
            }

            // stuff that always runs, input and drawing the game
            if (Raylib.GetKeyPressed() != 0)
            {
                started = true;
            }
            float alpha = accumulatedTime / frameSpace;
            alpha = Math.Clamp(alpha, 0f, 1f);

            gameController.Loop(alpha);
            gameController.runningBackground();
            if (started)
            {
                gameController.Draw();
            }
            else
            {
                screen.DrawStart();
            }
        }
        Raylib.CloseWindow();
    }
}