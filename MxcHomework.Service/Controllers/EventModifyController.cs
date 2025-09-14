using Microsoft.AspNetCore.Http.HttpResults;
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
