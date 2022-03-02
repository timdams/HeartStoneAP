using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartStoneAP.Classes
{
    class Playground
    {
        Random rng = new Random();
        private Player playerA;
        private Player playerB;
        public Playground(Player a, Player b)
        {
            playerA = a;
            playerB = b;

            playerA.SummonMinions();
            playerB.SummonMinions();
        }

        public void StartBattle()
        {

            (Player attacker, Player defender) = ChooseAttackOrder();

            DrawPlayGround();

            while (IsActive)
            {
                Console.Clear();
                DrawPlayGround();
                Attack(attacker, defender);
                RemoveDead();
                var temp = attacker;
                attacker = defender;
                defender = temp;


                Console.ReadKey();
            }
            Console.Clear();
            DrawPlayGround();
            Console.WriteLine("DONZO");
        }

        private void RemoveDead()
        {
            playerA.RemoveDead();
            playerB.RemoveDead();
        }

        public bool IsActive
        {
            get
            {
                return playerA.ActiveMinions.Where(p => !p.IsDead).Count()>0 && playerB.ActiveMinions.Where(p => !p.IsDead).Count() >0;
            }
        }



        public void DrawPlayGround()
        {
            const int ALINE = 2;
            const int BLINE = 20;
            for (int i = 0; i < playerA.ActiveMinions.Count; i++)
            {
                playerA.ActiveMinions[i].Draw(2 + i * 15, ALINE);
            }

            for (int i = 0; i < playerB.ActiveMinions.Count; i++)
            {
                playerB.ActiveMinions[i].Draw(2 + i * 15, BLINE);
            }
        }


        internal void Attack(Player attacker, Player defender)
        {
            attacker.NextAttack(defender);
        }

        private (Player, Player) ChooseAttackOrder()
        {
            if (playerA.Hand.Count > playerB.Hand.Count)
                return (playerA, playerB);
            else if (playerA.Hand.Count > playerB.Hand.Count)
                return (playerB, playerA);

            if (rng.Next(0, 2) == 0)
                return (playerA, playerB);
            return (playerB, playerA);
        }
    }
}
