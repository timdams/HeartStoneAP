using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartStoneAP.Classes
{
    class Player
    {
        public Player(string naamIn)
        {
            Naam = naamIn;
            //Deck = new List<Card>();
        }
        public List<Card> Deck { get; set; } = new List<Card>();
        public string Naam { get; set; }

        public void ShowDeck(int yOffset)
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                Deck[i].Draw(1 + i * 15, yOffset);
            }
        }
    }
}
