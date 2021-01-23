using System;
namespace BattleDreamLoop
{
    public class Player
    {
        public string Name { get; set; }
        public int PanicPoints { get; set; }
        public int StaminaPoints { get; set; }
        public int PanicMax { get; set; }

        public Player()
        {
            PanicPoints = 10;
            StaminaPoints = 10;
            PanicMax = 20;
        }

        public bool IsPlayerDead(Player player)
        {
            return (player.PanicPoints >= PanicMax || player.StaminaPoints <= 0);
        }
    }
}
