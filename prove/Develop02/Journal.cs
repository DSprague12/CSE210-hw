public class Journal(){
    public List<string[]> journalStage = new List<string[]>();

    //Loads journal from the file and puts it in the cleared "staging area"
    public void fetchJournal(string fileName){
        string[] lines = System.IO.File.ReadAllLines(fileName);
        journalStage = new List<string[]>();
        foreach (string line in lines){
            journalStage.Add(deobsfucate(line));
        }
    }

    //Spits out what the journal says
    public void readJournal(){
        foreach (string[] line in journalStage){
            string printedOutput = "";
            for(int i = 0; i < line.Length; i++){
                printedOutput += line[i] + " ";
            }
            Console.WriteLine(printedOutput);
        }
    }

    //Saves the temporary journal into the file
    public void saveJournal(string fileName){
        using(StreamWriter finalFile = new StreamWriter(fileName)){
            foreach (string[] item in journalStage){
                finalFile.WriteLine($"{obsfucate(item[0])},{obsfucate(item[1])},{obsfucate(item[2])}");
            }
        }
    }

    //Converts from bit64 to plaintext ;)
    string[] deobsfucate(string data){
        string[] splitData = data.Split(",");
        string[] goodData = ["","",""];
        for(int i=0; i<3; i++){
            var tempData = System.Convert.FromBase64String(splitData[i]);
            goodData[i] = (System.Text.Encoding.UTF8.GetString(tempData));
        }
        return goodData;
    }

    //Converts from plaintext to bit64 (stretch challenge? it resolves the issue with commas in the csv file)
    public string obsfucate(string plainText){
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

}