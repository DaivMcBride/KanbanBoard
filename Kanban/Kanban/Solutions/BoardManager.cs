using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Models;

namespace Kanban.Solutions
{
    public class BoardManager : IBoardManager
    {
        public Board SetUpBoard(List<Card> Cards)
        {
            var board = new Board();
           
            board.Backlog = new SwimLane(LaneType.Backlog);
            board.Backlog.Cards = Cards.Where(x => x.CardProgress == LaneType.Backlog).ToList();
            board.InProgress = new SwimLane(LaneType.InProgress);
            board.InProgress.Cards = Cards.Where(x => x.CardProgress == LaneType.InProgress).ToList();
            board.Complete = new SwimLane(LaneType.Complete);
            board.Complete.Cards = Cards.Where(x => x.CardProgress == LaneType.Complete).ToList();
            board.AllCards = Cards.OrderBy(x => x.ID).ToList();
            board.LastID = board.AllCards.Count() == 0 ? 0 : board.AllCards[board.AllCards.Count() - 1].ID;

            return board;
        }
        public void RestLanes (Board board)
        {
            var Cards = board.AllCards;
            board.Backlog = new SwimLane(LaneType.Backlog);
            board.Backlog.Cards = Cards.Where(x => x.CardProgress == LaneType.Backlog).ToList();
            board.InProgress = new SwimLane(LaneType.InProgress);
            board.InProgress.Cards = Cards.Where(x => x.CardProgress == LaneType.InProgress).ToList();
            board.Complete = new SwimLane(LaneType.Complete);
            board.Complete.Cards = Cards.Where(x => x.CardProgress == LaneType.Complete).ToList();
            
        }
        public void SetCardToNewLane(Board board, int CardID, LaneType lane)
        {
            Card card = board.AllCards.Select(x => x).Where(y=>y.ID == CardID).First();
            card.SetCardType(lane);
            RestLanes(board);
        }
        public void AddCardToBoard(Board board, Card card)
        {
            board.AllCards.Add(card);
            board.LastID = card.ID;
            RestLanes(board);

        }
    }
}
