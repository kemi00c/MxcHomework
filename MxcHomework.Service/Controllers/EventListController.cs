using Microsoft.AspNetCore.Mvc;
using MxcHomework.Data;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;

namespace MxcHomework.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventListController
    {
        private readonly IMxcHomeworkContext _context;
        public EventListController(IMxcHomeworkContext context)
        {
            _context = context;
        }

        [HttpGet("List")]
        public List<Event> ListEvents()
        {
            var lister = new EventLister(_context);
            return lister.ListEvents();
        }

        [HttpGet("ListOrdered")]
        public List<Event> ListEventsOrdered(string columnName, bool ascending = true)
        {
            var lister = new EventLister(_context);
            return lister.ListEvents(columnName, ascending);
        }

        [HttpGet("ListPaged")]
        public List<List<Event>> ListEventsPaged(int pageSize)
        {
            var lister = new EventLister(_context);
            return lister.ListEventsPaged(pageSize);
        }

        [HttpGet("ListPagedOrdered")]
        public List<List<Event>> ListEventsPagedOrdered(int pageSize, string columnName, bool ascending = true)
        {
            var lister = new EventLister(_context);
            return lister.ListEventsPaged(pageSize, columnName, ascending);
        }
    }
}
