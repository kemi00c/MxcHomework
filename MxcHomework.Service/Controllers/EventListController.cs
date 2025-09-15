using Microsoft.AspNetCore.Mvc;
using MxcHomework.Data;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;

namespace MxcHomework.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventListController : ControllerBase
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
        public ObjectResult ListEventsPaged(int pageSize, int page)
        {
            var lister = new EventLister(_context);
            try
            {
                return Ok(lister.ListEventsPaged(pageSize, page));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpGet("ListPagedOrdered")]
        public ObjectResult ListEventsPagedOrdered(int pageSize, int page, string columnName, bool ascending = true)
        {
            var lister = new EventLister(_context);
            try
            {
                return Ok(lister.ListEventsPaged(pageSize, page, columnName, ascending));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound(ex.ToString());
            }
        }
    }
}
