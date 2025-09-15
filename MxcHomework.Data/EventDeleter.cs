using Microsoft.EntityFrameworkCore;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;

namespace MxcHomework.Data
{
    public class EventDeleter
    {
        private readonly IMxcHomeworkContext _context;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public EventDeleter(IMxcHomeworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Delete an event. The provided Event must be valid, its ID is searched in the database and deleted.
        /// </summary>
        /// <param name="e">The Event to delete</param>
        /// <exception cref="ArgumentException"></exception>
        public void Delete(Event e)
        {
            var validator = new EventValidator(e);
            validator.Validate();

            var eventToDelete = _context.Events.Where(x => x.Id == e.Id).FirstOrDefault();
            if (eventToDelete == null)
            {
                throw new ArgumentException($"Event not found with ID {e.Id}");
            }

            _context.Events.Remove(eventToDelete);

            try
            {
                ((DbContext)_context).SaveChanges();
            }
            catch (InvalidCastException ex)
            {
                Logger.Warn(ex);
            }
        }
    }
}
