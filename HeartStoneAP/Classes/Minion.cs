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
                if (currentHealth <= 0)
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
            if(IsDead)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                int startx = x + 3;
                int starty = y + 5;
                int negx = 6;
                for (int i = 0; i < 6; i++)
                {
                    Console.SetCursorPosition(startx + i, starty + i);
                    Console.Write("\\");

                    Console.SetCursorPosition(startx +negx, starty + i);
                    Console.Write("/");
                    negx--;
                }
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
