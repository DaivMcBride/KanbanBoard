using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace KanbanBoard.Controllers
{
    public class KanbanController : ApiController
    {
        // GET: api/Kanban
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET: api/Kanban/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Kanban
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Kanban/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Kanban/5
        public void Delete(int id)
        {
        }
    }
}
