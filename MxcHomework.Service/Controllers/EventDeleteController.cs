using Microsoft.AspNetCore.Mvc;
using MxcHomework.Data;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;

namespace MxcHomework.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventDeleteController : ControllerBase
    {
        private readonly IMxcHomeworkContext _context;

        public EventDeleteController(IMxcHomeworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Removes an event from the database. The provided event is searched in the database, if found it is removed and OK is returned.
        /// If the event is invalid Bad Request is returned.
        /// If the event is not found, Not Found is returned.
        /// </summary>
        /// <param name="e">The event to delete</param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public ActionResult DeleteEvent(Event e)
        {
            var deleter = new EventDeleter(_context);

            try
            {
                deleter.Delete(e);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message.StartsWith("Event not found"))
                {
                    return NotFound(ex.ToString());
                }
                else
                {
                    throw;
                }
            }
            catch (EventValidatorException ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok();
        }
    }
}
