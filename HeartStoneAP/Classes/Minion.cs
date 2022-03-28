using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartStoneAP.Classes
{
    class Minion: Card
    {
        public Minion(string inTitle, TierType inTier, int actualHealth): base(inTitle, inTier)
        {
            ActualHealth = actualHealth;
        }

        private int actualHealth;
        public int ActualHealth 
        {
            get
            {
                return actualHealth;
            } 
            set
            {
                actualHealth = value;

                if(actualHealth <= 0)
                {
                    IsDead = true;
                }
                else
                {
                    IsDead = false; //Todo: opletten, kan problemen.
                }
            }
        
        } //Todo maak fullprop + IsDood

        public bool IsDead { get; set; } = false;

        public void DoAttack(Minion target)
        {
            target.ActualHealth -= Attack;
            ActualHealth -= target.Attack;
        }

        public override void Draw(int x, int y)
        {
            base.Draw(x, y);

            //Health
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x + 10, y + 1);
            Console.Write(ActualHealth);
            Console.ResetColor();

        }

    }
}
