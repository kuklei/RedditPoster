using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedditPoster.Data;
using RedditPoster.Models;

namespace RedditPoster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly HarmonyDbContext _db;

        public MessagesController(HarmonyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _db.Messages.Include(m => m.Targets).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var message = await _db.Messages.Include(m => m.Targets).FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
                return NotFound();
            return message;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _db.Messages.Add(message);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMessage), new { id = message.Id }, message);
        }
    }
}
