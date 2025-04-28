using System;

class Program
{
    static void Main(string[] args)
    {
        string input;
        int num = 1;
        int sum = 0;
        float avg = 0.00f;
        int smallestPositive = -1;

        List<int> list = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while(num != 0){
            input = Console.ReadLine();
            num = int.Parse(input);

            if(num != 0){
                list.Add(num);
            }
            if(num > 0 && (num < smallestPositive) || (smallestPositive < 0)){
                smallestPositive = num;
            }
            sum += num;
        }
        list.Sort();
        int max = list[list.Count - 1];

        avg = (float)sum / list.Count;

        Console.WriteLine($"The sum is {sum}. The average is {avg}. The maximum is {max}. The smallest positive is {smallestPositive}.");
        Console.WriteLine("The sorted list is:");

        foreach(int number in list){
            Console.WriteLine(number);
        }
    }
}