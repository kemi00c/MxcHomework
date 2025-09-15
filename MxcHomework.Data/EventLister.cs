using MxcHomework.Database.Data;
using MxcHomework.Database.Models;

namespace MxcHomework.Data
{
    public class EventLister
    {
        private readonly IMxcHomeworkContext _context;

        public EventLister(IMxcHomeworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// List all events
        /// </summary>
        /// <returns></returns>
        public List<Event> ListEvents()
        {
            return _context.Events.ToList();
        }

        /// <summary>
        /// List all events, order by a specified column name
        /// </summary>
        /// <param name="columnName">The column name to order by</param>
        /// <param name="ascending">If true, the returned list is ordered ascending or descending otherwise</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public List<Event> ListEvents(string columnName, bool ascending = true)
        {
            var prop = typeof(Event).GetProperty(columnName);
            if (prop == null)
            {
                throw new ArgumentException($"No property {columnName} found.");
            }

            if (ascending)
            {
                return _context.Events.AsEnumerable().OrderBy(e => prop.GetValue(e)).ToList();
            }
            else
            {
                return _context.Events.AsEnumerable().OrderByDescending(e => prop.GetValue(e)).ToList();
            }
        }

        /// <summary>
        /// Return all events in pages of a specified size, returns the page number provided in the "page" argument
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">The page to return</param>
        /// <returns></returns>
        public List<Event> ListEventsPaged(int pageSize, int page)
        {
            var pages = new List<List<Event>>();

            var events = _context.Events.ToList();

            for (var i = 0; i < events.Count; i += pageSize)
            {
                pages.Add(events.GetRange(i, Math.Min(pageSize, events.Count - i)));
            }

            return pages[page];
        }

        /// <summary>
        /// List all events, order by a specified column name, create a paged list of a specified size returns the page number provided in the "page" argument
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">The page to return</param>
        /// <param name="columnName">The column name to order by</param>
        /// <param name="ascending">If true, the returned list is ordered ascending or descending otherwise</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public List<Event> ListEventsPaged(int pageSize, int page, string columnName, bool ascending = true)
        {
            var prop = typeof(Event).GetProperty(columnName);
            if (prop == null)
            {
                throw new ArgumentException($"No property {columnName} found.");
            }

            List<Event> events;

            if (ascending)
            {
                events = _context.Events.AsEnumerable().OrderBy(e => prop.GetValue(e)).ToList();
            }
            else
            {
                events = _context.Events.AsEnumerable().OrderByDescending(e => prop.GetValue(e)).ToList();
            }


            var pages = new List<List<Event>>();


            for (var i = 0; i < events.Count; i += pageSize)
            {
                pages.Add(events.GetRange(i, Math.Min(pageSize, events.Count - i)));
            }

            return pages[page];
        }


        /// <summary>
        /// Get the number of pages of the paged event list with the provided page size
        /// </summary>
        /// <param name="pageSize">The page size</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            return (int)Math.Ceiling(_context.Events.Count() / (double)pageSize);
        }
    }
}
