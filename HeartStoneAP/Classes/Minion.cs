using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartStoneAP.Classes
{
    class Minion: Card
    {
        public int ActualHealth { get; set; } //Todo maak fullprop + IsDood

        public void DoAttack(Minion target)
        {
            target.ActualHealth -= Attack;
            ActualHealth -= target.Attack;
        }

        

    }
}
