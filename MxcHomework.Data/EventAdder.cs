using Microsoft.EntityFrameworkCore;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;

namespace MxcHomework.Data
{
    public class EventAdder
    {
        private readonly IMxcHomeworkContext _context;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public EventAdder(IMxcHomeworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add an event
        /// </summary>
        /// <param name="e">The event to add</param>
        public void Add(Event e)
        {
            var validator = new EventValidator(e);
            validator.Validate();

            _context.Events.Add(e);
            try
            {
                ((DbContext)_context).SaveChanges();
            }
            catch (InvalidCastException ex) // Catching InvalidCastException, because casting fails if a mocked context is provided
            {
                Logger.Warn(ex);
            }
        }
    }
}
