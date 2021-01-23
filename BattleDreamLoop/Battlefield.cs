using System;
namespace BattleDreamLoop
{
    public class Battlefield
    {
        private string[] EnemyNames = new string[] { "NightTerror", "Lucidity", "Chimera", "REMwrecker", "Speckter", "Wraith" };
       
        public void PlayRounds(string playerName)
        {
            var player = new Player();
            var enemy = new Enemy();
            var numRounds = 10;
            var enemyNum = 0;

            player.Name = playerName;
            enemy.Name = EnemyNames[enemyNum];
            
            for (int i=0; i < numRounds; i++)
            {
                var rollDieResult = RollDie();
                Console.WriteLine();
                Console.WriteLine($"Round {i + 1}");
                PrintStats(player, enemy);
                UpdateStats(rollDieResult, player, enemy);
                
                if (enemy.IsEnemyDead(enemy))
                {
                    Console.WriteLine($"Congratulations! {enemy.Name} is dead!");
                    enemyNum++;
                    enemy.HitPoints = 10;
                    enemy.Name = EnemyNames[enemyNum];
                    Console.WriteLine($"The battle continues... {enemy.Name} has entered the arena!");
                } else
                {
                    Console.WriteLine($"{enemy.Name} is still alive! Gain 1 panic point and lose 1 stamina point.");
                    player.PanicPoints += 1;
                    player.StaminaPoints -= 1;
                }

                if (i == (numRounds-1))
                {
                    player.PanicPoints = player.PanicMax;
                    Console.WriteLine("Sorry... you have no rounds left to fight");
                }

                if (player.IsPlayerDead(player))
                {
                    Console.WriteLine($"{player.Name} is dead! The enemy is victorious!");
                    i = numRounds;
                } 
            }
        }

        public int RollDie()
        {
            return (new Random().Next(1, 7));
        }

        public void PrintStats(Player player, Enemy enemy)
        {
            Console.WriteLine($"{player.Name} Stamina:{player.StaminaPoints} /Panic:{player.PanicPoints}");
            Console.WriteLine($"{enemy.Name} Hit Points: {enemy.HitPoints}");
            Console.WriteLine();
        }

        public void UpdateStats(int rollDieResult, Player player,Enemy enemy)
        {
            switch (rollDieResult)
            {
                case 1:
                    {
                        player.PanicPoints += 2;
                        Console.WriteLine($"{player.Name} is hit! Gain 2 panic points.");
                        break;
                    }
                case 2:
                    {
                        player.StaminaPoints -= 1;
                        Console.WriteLine($"{player.Name} dodged the attack! Lose 1 stamina point.");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine($"{player.Name} deflected the attack! No change in points.");
                        break;
                    }
                case 4:
                    {
                        player.StaminaPoints += 1;
                        Console.WriteLine($"{enemy.Name} backed away! Gain 1 stamina point.");
                        break;
                    }
                case 5:
                    {
                        player.PanicPoints -= 1;
                        enemy.HitPoints -= 3;
                        Console.WriteLine($"{enemy.Name} tried to dodge but {player.Name} strikes a glancing blow! Lose 1 panic point and {enemy.Name} loses 3 hit points.");
                        break;
                    }
                case 6:
                    {
                        player.PanicPoints -= 3;
                        player.StaminaPoints += 2;
                        enemy.HitPoints -= 5;
                        Console.WriteLine($"{enemy.Name} takes significant damage! Lose 3 panic points and gain 2 stamina points. {enemy.Name} loses 5 hit points.");
                        break;
                    }
            }
        }
    }
}
