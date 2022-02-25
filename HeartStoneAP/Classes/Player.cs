using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartStoneAP.Classes
{
    class Player
    {
        public List<Card> Hand { get; set; } = new List<Card>();
        public List<Minion> ActiveMinions { get; set; } = new List<Minion>();

        internal void SummonMinions()
        {
            ActiveMinions = new List<Minion>();
            lastAttackIndex = 0;
            foreach (var card in Hand)
            {
                ActiveMinions.Add(card.Summon());
            }
        }

        private int lastAttackIndex = 0;
        internal void NextAttack(Player defender)
        {
            if (ActiveMinions.Count == 0) return;
            if (lastAttackIndex > ActiveMinions.Count)
                lastAttackIndex = 0;

            ActiveMinions[lastAttackIndex].AttackMinion(defender);
           
        }

        internal void RemoveDead()
        {
            List<Minion> survivors = new List<Minion>();
            survivors = ActiveMinions.Where(p => !p.IsDead).ToList();
        }
    }
}
