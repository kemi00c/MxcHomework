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
    public class EventAdder
    {
        private readonly IMxcHomeworkContext _context;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public EventAdder(IMxcHomeworkContext context)
        {
            _context = context;
        }

        public void Add(Event e)
        {
            var validator = new EventValidator(e);
            validator.Validate();

            _context.Events.Add(e);
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
