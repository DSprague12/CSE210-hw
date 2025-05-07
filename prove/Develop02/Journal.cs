public class Journal(){
    public List<string> journalStage = new List<string>();

    //Loads journal from the file and puts it in the cleared "staging area"
    public void fetchJournal(string fileName){
        string[] lines = System.IO.File.ReadAllLines(fileName);
        journalStage = new List<string>();
        foreach (string line in lines){
            journalStage.Add(line);
        }
    }

    //Spits what the journal says
    public void readJournal(){
        foreach (string line in journalStage){
            Console.WriteLine(line);
        }
    }

    //Adds the entry into the staging journal
    public void writeInJournal(string input){
        journalStage.Add(input);
    }

    //Saves the temporary journal into the file
    public void saveJournal(string fileName){
        using(StreamWriter finalFile = new StreamWriter(fileName)){
            foreach (string item in journalStage){
                finalFile.WriteLine(item);
            }
        }
    }
}