using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Frog Caretaker";
        job1._company = "Amphibian International";
        job1._startYear = 1992;
        job1._endYear = 2011;

        Job job2 = new Job();
        job2._jobTitle = "Plant Physician";
        job2._company = "Wealthy Gardening Inc";
        job2._startYear = 2009;
        job2._endYear = 2022;

        List<Job> jobs = new List<Job>();
        jobs.Add(job1);
        jobs.Add(job2);

        Resume person1 = new Resume();
        person1._name = "Joe Generic";
        person1._jobs = jobs;
        person1.Display(false);

    }
}