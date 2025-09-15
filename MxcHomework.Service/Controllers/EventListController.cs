using Microsoft.AspNetCore.Http.HttpResults;
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

        /// <summary>
        /// List all events
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        public List<Event> ListEvents()
        {
            var lister = new EventLister(_context);
            return lister.ListEvents();
        }

        /// <summary>
        /// List all events, order by a specified column name in either ascending or descending order
        /// </summary>
        /// <param name="columnName">The column to order by</param>
        /// <param name="ascending">Determines if the list should be ordered ascending or descending</param>
        /// <returns></returns>
        [HttpGet("ListOrdered")]
        public List<Event> ListEventsOrdered(string columnName, bool ascending = true)
        {
            var lister = new EventLister(_context);
            return lister.ListEvents(columnName, ascending);
        }

        /// <summary>
        /// List events in pages of the specified page size. Returns the page of the specified page number. If the page is out of range, Not Found is returned.
        /// </summary>
        /// <param name="pageSize">The page size</param>
        /// <param name="page">The page to return</param>
        /// <returns></returns>
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

        /// <summary>
        ///  List events in pages of the specified page size. Returns the page of the specified page number. If the page is out of range, Not Found is returned.
        ///  The list is ordered by a specified column name in either ascending or descending order.
        /// </summary>
        /// <param name="pageSize">The page size</param>
        /// <param name="page">The page number to return</param>
        /// <param name="columnName">The column name to order by</param>
        /// <param name="ascending">Determines if the list should be ordered ascending or descending</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the number of pages of a specified page size
        /// </summary>
        /// <param name="pageSize">The page size</param>
        /// <returns></returns>
        [HttpGet("GetPageCount")]
        public int GetPageCount(int pageSize)
        {
            var lister = new EventLister(_context);
            return lister.GetPageCount(pageSize);
        }
    }
}
