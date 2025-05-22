using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedditPoster.Data;
using RedditPoster.Models;

namespace RedditPoster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubredditController : ControllerBase
    {
        private readonly HarmonyDbContext _db;

        public SubredditController(HarmonyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageTarget>>> GetAll()
        {
            return await _db.MessageTargets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageTarget>> Get(int id)
        {
            var target = await _db.MessageTargets.FindAsync(id);
            if (target == null)
                return NotFound();
            return target;
        }

        [HttpPost]
        public async Task<ActionResult<MessageTarget>> Create(MessageTarget target)
        {
            _db.MessageTargets.Add(target);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = target.Id }, target);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MessageTarget target)
        {
            if (id != target.Id)
                return BadRequest();

            _db.Entry(target).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.MessageTargets.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var target = await _db.MessageTargets.FindAsync(id);
            if (target == null)
                return NotFound();

            _db.MessageTargets.Remove(target);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
