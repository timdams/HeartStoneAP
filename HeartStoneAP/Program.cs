using HeartStoneAP.Classes;
using System;

namespace HeartStoneAP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Huiswerk:
                     
            Card myFirstCard = new Card("Rockpool Hunter", TierType.Tier1); //playerA
            myFirstCard.MaxHealth = 3;
            myFirstCard.Attack = 2;
            myFirstCard.TribeType = CategoryType.Murloc;
            myFirstCard.Abilities = new string[] { "BattleCry: Give a friendly Murloc +1/+1" };
            myFirstCard.Draw(5,5);

            Card mySecondCard = new Card("Nathrezim Overseer", TierType.Tier2); //playerB

            mySecondCard.MaxHealth = 4;
            mySecondCard.Attack = 2;
            mySecondCard.TribeType = CategoryType.Demon;
            mySecondCard.Abilities = new string[] { "BattleCry: Give a friendly Demon +2/+2" };
            mySecondCard.Draw(20, 8);

            Console.Clear();
            Minion minionPlayerA = myFirstCard.Summon();
            Minion minionPlayerB = mySecondCard.Summon();

            minionPlayerA.Draw(1, 5);
            minionPlayerB.Draw(1, 20);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine(minionPlayerA.ActualHealth);
            minionPlayerA.DoAttack(minionPlayerB);
            Console.SetCursorPosition(1, 2);
            Console.WriteLine(minionPlayerA.ActualHealth);


            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.ReadLine();
          

        }
    }
}
