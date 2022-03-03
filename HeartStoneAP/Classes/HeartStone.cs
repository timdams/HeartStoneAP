using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartStoneAP.Classes
{
    class HeartStone
    {

        static public void PlayGame()
        {
            StartIntro();
            Player human = CreateHumanPlayer();
            int level = 1;
            bool humanIsWinning = true;
            while(humanIsWinning)
            {
                Console.Clear();
                Console.WriteLine($"Ready for level {level}");
                Console.ReadKey();

                Playground pl = new Playground(human, CreateAIPlayer(level));
                if (pl.StartBattle() == human)
                    level++;
                else humanIsWinning = false;

            }
            Console.WriteLine($"U made it to level {level}");


        }

        private static Player CreateHumanPlayer()
        {
            Player p = new Player("HUMAN");
            Card myFirstCard = new Card();
            myFirstCard.Tier = TierType.Tier1;
            myFirstCard.Title = "Rockpool Hunter";
            myFirstCard.MaxHealth = 8;
            myFirstCard.Attack = 2;
            myFirstCard.TribeType = CategoryType.Murloc;
            myFirstCard.Abilities = new string[] { "BattleCry: Give a friendly Murloc +1/+1" };
    
            for (int i = 0; i < 5; i++)
            {
                p.Hand.Add(myFirstCard);
            }
            return p;
        }

        private static Player CreateAIPlayer(int level)
        {
            Card myFirstCard = new Card();
            myFirstCard.Tier = TierType.Tier1;
            myFirstCard.Title = "Rockpool Hunter";
            myFirstCard.MaxHealth = 8;
            myFirstCard.Attack = 2;
            myFirstCard.TribeType = CategoryType.Murloc;
            myFirstCard.Abilities = new string[] { "BattleCry: Give a friendly Murloc +1/+1" };
            Player AI = new Player($"AI level {level}");
            for (int i = 0; i < level; i++)
            {
                AI.Hand.Add(myFirstCard);
            }
            return AI;
        }

        private static void StartIntro()
        {
            //throw new NotImplementedException();
        }
    }
}
