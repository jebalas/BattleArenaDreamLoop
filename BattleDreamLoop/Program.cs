using System;

namespace BattleDreamLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("You have entered the DreamWorld Battlefield!\n");
                Console.Write("Please enter your character name: ");
                var playerName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"You have 10 rounds to defeat your enemies... Good Luck {playerName}!\n");
                

                var battlefield1 = new Battlefield();
                battlefield1.PlayRounds(playerName);
            }
        }
    }
}
