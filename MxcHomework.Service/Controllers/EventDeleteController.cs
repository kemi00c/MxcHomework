using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
