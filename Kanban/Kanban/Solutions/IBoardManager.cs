using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Models;

namespace Kanban.Solutions
{
    public interface IBoardManager
    {
        Board SetUpBoard(List<Card> Cards);
        void RestLanes(Board board);
        void SetCardToNewLane(Board board, int CardID, LaneType lane);
        void AddCardToBoard(Board board, Card card);
    }
}
