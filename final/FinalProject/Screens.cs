using Raylib_cs;
class Screen
{
    public void DrawStart()
    {
        Raylib.BeginDrawing();
        Raylib.DrawRectangle(0, 0, (int)Program.screenSize, (int)Program.screenSize, Color.White);
        Raylib.DrawText("Press any button to start", 0, 0, 50, Color.Black);
        Raylib.EndDrawing();
    }
    public void DrawLoser()
    {
        Raylib.BeginDrawing();
        Raylib.DrawRectangle(0, 0, (int)Program.screenSize, (int)Program.screenSize, Color.White);
        Raylib.DrawText("Haha you lost", 0, 0, 50, Color.Black);
        Raylib.EndDrawing();
    }
}