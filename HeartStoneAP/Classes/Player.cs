using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartStoneAP.Classes
{
    class Player
    {
        public Player(string nameIn)
        {
            Name = nameIn;
        }
        public List<Card> Hand { get; set; } = new List<Card>();
        public List<Minion> ActiveMinions { get; set; } = new List<Minion>();
        public string Name { get;private set; }
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
            
            if (ActiveMinions.Count == 0 || ActiveMinions.Count(p=>p.IsDead)== ActiveMinions.Count) return;
            if (lastAttackIndex >= ActiveMinions.Count)
                lastAttackIndex = 0;

            Utility.PrintLogMessage($"{Name} attack {defender.Name} with minion no. {lastAttackIndex}");


            var target = GetRandomTarget(defender);
            ActiveMinions[lastAttackIndex].AttackMinion(target);
            
            lastAttackIndex++;
        }

        private Minion GetRandomTarget(Player defender)
        {
            //Choose random target
            Random rng = new Random();
            var alive = defender.ActiveMinions.Where(p => !p.IsDead).ToList();
            int deftarg = rng.Next(0, alive.Count);
            return alive[deftarg];
        }

        internal void EndOfTurnCleanUp()
        {

            foreach (var surv in ActiveMinions)
            {
                surv.IsDefending = false;
                surv.IsAttacking = false;
            }

            List<Minion> survivors = new List<Minion>();
            survivors = ActiveMinions.Where(p => !p.IsDead).ToList();
            
        }

        public override string ToString()
        {
            return $"{Name} (Alive Minions ={ActiveMinions.Count(p => !p.IsDead)})";
        }
    }
}
