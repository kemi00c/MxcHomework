using Microsoft.EntityFrameworkCore;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Data
{
    public class EventModifier
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly IMxcHomeworkContext _context;

        public EventModifier(IMxcHomeworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Modify an event. A valid Event object must be provided, whose ID is searched in the database, and the properties are replaced with the ones provided.
        /// </summary>
        /// <param name="newEvent">An Event object with the ID to search and the properties to replace</param>
        /// <exception cref="ArgumentException"></exception>
        public void Modify(Event newEvent)
        {
            var e = _context.Events.Where(x => x.Id == newEvent.Id).FirstOrDefault();

            if (e == null)
            {
                throw new ArgumentException($"Event not found with ID {newEvent.Id}");
            }

            var validator = new EventValidator(newEvent);
            validator.Validate();

            e.Name = newEvent.Name;
            e.Location = newEvent.Location;
            e.Country = newEvent.Country;
            e.Capacity = newEvent.Capacity;

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
