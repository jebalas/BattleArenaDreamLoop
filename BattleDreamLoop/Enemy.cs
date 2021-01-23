using System;
namespace BattleDreamLoop
{
    public class Enemy
    {
        public int HitPoints { get; set; }
        public string Name { get; set; }

        public Enemy()
        {
            HitPoints = 10;
        }

        public bool IsEnemyDead(Enemy enemy)
        {
            return (enemy.HitPoints <= 0); 
        }
    }
}
