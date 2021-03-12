using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class Card
    {
        public string User { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public LaneType CardProgress { get; set; }
        public int ID { get; set; }
        public Card()
        {

        }
        public void SetCardType(LaneType Type)
        {
            CardProgress = Type;
        }
    }
}
