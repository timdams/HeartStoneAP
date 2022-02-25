﻿using System;

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
            Minion target = defender.ActiveMinions[rng.Next(0, defender.ActiveMinions.Count)];

            target.CurrentHealth -= Attack;
            CurrentHealth -= target.Attack;
        }
    }
}
