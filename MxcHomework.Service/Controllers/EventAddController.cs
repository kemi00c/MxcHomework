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
