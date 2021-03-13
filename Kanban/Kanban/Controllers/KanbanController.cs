using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kanban.Models;
using Kanban.Solutions;
using System.IO; // for File operation  
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace Kanban.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        private IMemoryCache _cache;

        public KanbanController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        private  IEncription _encription;
        public IEncription Encription
        {
            get { return _encription ?? (_encription =  new Encription()); }
            set { _encription = value; }
        }
        private IBoardManager _boardManager;
        public IBoardManager BoardManager
        {
            get { return _boardManager ?? (_boardManager = new BoardManager()); }
            set { _boardManager = value; }
        }
        // GET: api/Kanban
        [HttpGet]
        public Board Get()
        {
            string allText = System.IO.File.ReadAllText("configuration.json");
                  
            EncriptionKey key = JsonConvert.DeserializeObject< EncriptionKey>(allText);
            var filekey = Encription.GetEncriptedFile(key);
            Encription.DeEncriptedFile(filekey);
            List<Card> cards = JsonConvert.DeserializeObject<List<Card>>(filekey.Description);
            if (cards == null)
            {
                cards = new List<Card>();
            }
            Board board = BoardManager.SetUpBoard(cards);
            _cache.Set("currentState", board, TimeSpan.FromDays(1));
            //return View(personlist);
            return board;
        }

        // GET: api/Kanban/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {


           Card cards = JsonConvert.DeserializeObject<Card>(id);
            cards.CardProgress = LaneType.Backlog;
            cards.Date = DateTime.Now.ToShortDateString();
            var board = _cache.Get<Board>("currentState");
            cards.ID = board.LastID + 1;
            board.LastID = cards.ID;
            BoardManager.AddCardToBoard(board, cards);

            _cache.Set("currentState", board, TimeSpan.FromDays(1));
            var serlizedList = JsonConvert.SerializeObject(board.AllCards);
            string allText = System.IO.File.ReadAllText("configuration.json");
            EncriptionKey key = JsonConvert.DeserializeObject<EncriptionKey>(allText);
            var filekey = Encription.GetEncriptedFile(key);
            filekey.Description = serlizedList;
            Encription.EncriptedFile(filekey);
            Encription.SaveDataSet(filekey);

            return "";
        }

        // POST: api/Kanban/6
        [HttpPost("{id}")]
        public void Post(string id)
        {
            Card cards = JsonConvert.DeserializeObject<Card>(id);
            var board = _cache.Get<Board>("currentState");
            BoardManager.SetCardToNewLane(board, cards.ID, cards.CardProgress);

            _cache.Set("currentState", board, TimeSpan.FromDays(1));
            var serlizedList = JsonConvert.SerializeObject(board.AllCards);
            string allText = System.IO.File.ReadAllText("configuration.json");
            EncriptionKey key = JsonConvert.DeserializeObject<EncriptionKey>(allText);
            var filekey = Encription.GetEncriptedFile(key);
            filekey.Description = serlizedList;
            Encription.EncriptedFile(filekey);
            Encription.SaveDataSet(filekey);
        }

        // PUT: api/Kanban/5
        [HttpPut("{id}")]
        public void Put(string id )
        {
           // Card cards = value;
            Card cards = JsonConvert.DeserializeObject<Card>(id);
            cards.CardProgress = LaneType.Backlog;
            cards.Date = DateTime.Now.ToShortDateString();
            var board = _cache.Get<Board>("currentState");
            cards.ID = board.LastID + 1;
            board.LastID = cards.ID;
            BoardManager.AddCardToBoard(board, cards);

            _cache.Set("currentState", board, TimeSpan.FromDays(1));
            var serlizedList = JsonConvert.SerializeObject(board.AllCards);
            string allText = System.IO.File.ReadAllText("configuration.json");
            EncriptionKey key = JsonConvert.DeserializeObject<EncriptionKey>(allText);
            var filekey = Encription.GetEncriptedFile(key);
            filekey.Description = serlizedList;
            Encription.EncriptedFile(filekey);
            Encription.SaveDataSet(filekey);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
