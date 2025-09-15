using Microsoft.AspNetCore.Mvc;
using MxcHomework.Data;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;

namespace MxcHomework.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventModifyController : ControllerBase
    {
        private readonly IMxcHomeworkContext _context;
        public EventModifyController(IMxcHomeworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Modify an existing event. The event is searched in the database, if found and valid, modifies the event with the provided new event.
        /// If the event is not found, Not Found is returned. If the event is invalid, Bad Request is returned.
        /// </summary>
        /// <param name="e">The event with the new properties to replace</param>
        /// <returns></returns>
        [HttpPatch("Modify")]
        public ActionResult ModifyEvent(Event e)
        {
            var modifier = new EventModifier(_context);

            try
            {
                modifier.Modify(e);
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
