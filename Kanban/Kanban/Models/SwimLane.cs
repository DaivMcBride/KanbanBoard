using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class SwimLane
    {
        public LaneType Type { get; set; }
        public List<Card> Cards { get; set; }
        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
        public SwimLane()
        {
            Cards = new List<Card>();
        }
        public SwimLane(LaneType Board)
        {
            Type = Board;
            Cards = new List<Card>();
        }
        public Card RetrieveCard(int Place)
        {
            return Cards[Place];
        }
        public void RemoveCard(int Place)
        {
            Cards.RemoveAt(Place);
        }
    }
}