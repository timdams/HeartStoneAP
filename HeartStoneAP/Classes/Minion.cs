using System;
using System.Linq;

namespace HeartStoneAP.Classes
{
    class Minion : Card
    {
        private int currentHealth;

        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
                if (currentHealth < 0)
                {
                    currentHealth = 0;
                    IsDead = true;
                }
            }
        }

        public bool IsDead { get; private set; } = false;

        internal override void Draw(int x, int y)
        {
            base.Draw(x, y);
            //Health
            if (CurrentHealth != MaxHealth)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(x + 10, y + 1);
                Console.Write(CurrentHealth);
                Console.ResetColor();
            }
        }

        internal void AttackMinion(Player defender)
        {
            //Choose random target
            Random rng = new Random();
            var alive = defender.ActiveMinions.Where(p => !p.IsDead).ToList();
            int deftarg = rng.Next(0, alive.Count);
            Minion target =alive[deftarg];

            target.CurrentHealth -= Attack;
            CurrentHealth -= target.Attack;

            Utility.PrintLogMessage($"{Title} attacks {target.Title} and deals {Attack}dmg. Target has {target.currentHealth} health left");
        }
    }
}
