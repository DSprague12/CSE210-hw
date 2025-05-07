public class Entry(){
    public string date;
    public string prompt;
    public string userEntry;

    //Returns what the entry output will be
    public string fullEntry(){
        return $"{date} {prompt} {userEntry}";
    }

}