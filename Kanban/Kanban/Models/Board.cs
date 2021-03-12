using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class Board
    {
        public SwimLane Backlog { get; set; }
        public SwimLane InProgress { get; set; }
        public SwimLane Complete { get; set; }
        public List<Card> AllCards { get; set; }
        public int LastID { get; set; }
    }
}
