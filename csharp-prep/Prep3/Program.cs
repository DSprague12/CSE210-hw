using System;

class Program
{
    static void Main(string[] args)
    {
        string input;
        int guess;
        int attempts = 0;

        Random random = new Random();
        do{
            int num = random.Next(0, 100);
            Console.WriteLine($"The magic number is {num}.");
            do{
                Console.WriteLine("What is your guess? ");
                input = Console.ReadLine();
                guess = int.Parse(input);

                if(guess < num){
                    Console.WriteLine("Higher");
                }else if(guess > num){
                    Console.WriteLine("Lower");
                }
                attempts++;

            } while(guess != num);

            Console.WriteLine($"Correct! You guessed in {attempts} attempts! Would you like to play again? ");
            input = Console.ReadLine();
            
        } while(input == "yes");
    }
}