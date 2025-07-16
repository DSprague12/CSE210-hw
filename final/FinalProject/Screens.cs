using Raylib_cs;
class Screen
{
    public void DrawStart()
    {
        Raylib.BeginDrawing();
        Raylib.DrawRectangle(0, 0, (int)Program.screenSize, (int)Program.screenSize, Color.DarkGreen);
        Raylib.DrawText("Press any button to start", (int)Program.screenSize/5, (int)Program.screenSize/2, 50, Color.Black);
        Raylib.EndDrawing();
    }
    public void DrawLoser()
    {
        Raylib.BeginDrawing();
        Raylib.DrawRectangle(0, 0, (int)Program.screenSize, (int)Program.screenSize, Color.DarkGreen);
        Raylib.DrawText("Haha you lost", (int)Program.screenSize/5, (int)Program.screenSize/2, 50, Color.Black);
        Raylib.EndDrawing();
    }
}