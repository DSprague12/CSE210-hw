public class Reference
{
    private static string _filename;
    public string chosenVerse;
    public string metadata;
    Random rnd = new Random();
    public Reference()
    {
        _filename = "BoM.txt";
        string[] lines = System.IO.File.ReadAllLines(_filename);
        
        //choose random scripture
        int scriptureCount = (lines.Length + 1) / 3;
        int scriptureIndex = rnd.Next(scriptureCount);
        int startLine = scriptureIndex * 3;
        
        //get reference(first line)
        metadata = lines[startLine].Trim();
        
        //get verse(second line)
        chosenVerse = lines[startLine + 1].Trim();
    }
}