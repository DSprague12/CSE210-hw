public class Resume(){
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display(bool sameLine){
        if(sameLine){
            Console.WriteLine($"Name: {_name} Jobs: ");
            foreach (Job job in _jobs){
                Console.Write(" ");
                job.Display();
            }
        }else {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Jobs:");
            foreach (Job job in _jobs){
                job.Display();
                Console.WriteLine();
            }
        }
    }
}