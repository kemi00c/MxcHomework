using Microsoft.AspNetCore.Mvc;
using MxcHomework.Data;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;

namespace MxcHomework.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventAddController : ControllerBase
    {
        private readonly IMxcHomeworkContext _context;

        public EventAddController(IMxcHomeworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add an event. The event is validated, if it is valid, it is added to the database, HTTP OK is returned.
        /// If the event is invalid HTTP Bad Request is returned
        /// </summary>
        /// <param name="e">The event to add</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public ActionResult AddEvent(Event e)
        {
            var adder = new EventAdder(_context);

            try
            {
                adder.Add(e);
            }
            catch (EventValidatorException ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok();
        }
    }
}
