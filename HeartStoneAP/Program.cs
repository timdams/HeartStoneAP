using HeartStoneAP.Classes;
using System;
using System.Collections.Generic;

namespace HeartStoneAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Card myFirstCard = new Card("Rockpool Hunter", TierType.Tier1); //playerA
            myFirstCard.MaxHealth = 3;
            myFirstCard.Attack = 2;
            myFirstCard.TribeType = CategoryType.Murloc;
            myFirstCard.Abilities = new string[] { "BattleCry: Give a friendly Murloc +1/+1" };
         //   myFirstCard.Draw(5,5);

            Card mySecondCard = new Card("Nathrezim Overseer", TierType.Tier2); //playerB
            mySecondCard.MaxHealth = 4;
            mySecondCard.Attack = 2;
            mySecondCard.TribeType = CategoryType.Demon;
            mySecondCard.Abilities = new string[] { "BattleCry: Give a friendly Demon +2/+2" };
            //   mySecondCard.Draw(20, 8);

            Player humanPlayer = new Player("Tim");
            humanPlayer.Deck.Add(myFirstCard);
            humanPlayer.Deck.Add(myFirstCard);
            humanPlayer.Deck.Add(myFirstCard);
            //humanPlayer.ShowDeck(2);


            
            Player aiPlayer = new Player("AI");
            aiPlayer.Deck.Add(mySecondCard);
            aiPlayer.Deck.Add(mySecondCard);
            aiPlayer.Deck.Add(mySecondCard);
            aiPlayer.Deck.Add(mySecondCard);
            aiPlayer.Deck.Add(mySecondCard);
            //aiPlayer.ShowDeck(20);

            Minion showoff = myFirstCard.Summon();
            showoff.Draw(5,5);
            showoff.ActualHealth--;
            showoff.Draw(25, 5);
        

            Console.ReadKey();

        }
    }
}
