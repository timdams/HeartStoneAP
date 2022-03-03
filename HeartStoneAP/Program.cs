using HeartStoneAP.Classes;
using System;

namespace HeartStoneAP
{
    class Program
    {
        static void Main(string[] args)
        {

            HeartStone.PlayGame();

            Card myFirstCard = new Card();
            myFirstCard.Tier = TierType.Tier1;
            myFirstCard.Title = "Rockpool Hunter";
            myFirstCard.MaxHealth = 8;
            myFirstCard.Attack = 2;
            myFirstCard.TribeType = CategoryType.Murloc;
            myFirstCard.Abilities = new string[] { "BattleCry: Give a friendly Murloc +1/+1" };


            Card mySecondCard = new Card();
            mySecondCard.Tier = TierType.Tier2;
            mySecondCard.Title = "Nathrezim Overseer";
            mySecondCard.MaxHealth = 9;
            mySecondCard.Attack = 2;
            mySecondCard.TribeType = CategoryType.Demon;
            mySecondCard.Abilities = new string[] { "BattleCry: Give a friendly Demon +2/+2" };



            Player tim = new Player("A");
            tim.Hand.Add(myFirstCard);
            tim.Hand.Add(myFirstCard);
            tim.Hand.Add(myFirstCard);
            tim.Hand.Add(myFirstCard);
            tim.Hand.Add(myFirstCard);


            Player ben = new Player("B");
            ben.Hand.Add(mySecondCard);
            ben.Hand.Add(mySecondCard);
            ben.Hand.Add(mySecondCard);
            ben.Hand.Add(mySecondCard);



            Playground hs = new Playground(tim,ben);
            hs.StartBattle();


            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.ReadLine();
          

        }
    }
}
