using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlDemo.Models;
using game_scores.models;

namespace game_scores.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        private readonly WebAPIDataContext _context;

        public GamesController(WebAPIDataContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<games> Getgames()
        {
            return _context.games;
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getgames([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games = await _context.games.SingleOrDefaultAsync(m => m.id == id);

            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgames([FromRoute] int id, [FromBody] games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != games.id)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gamesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        [HttpPost]
        public async Task<IActionResult> Postgames([FromBody] games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.games.Add(games);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgames", new { id = games.id }, games);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegames([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games = await _context.games.SingleOrDefaultAsync(m => m.id == id);
            if (games == null)
            {
                return NotFound();
            }

            _context.games.Remove(games);
            await _context.SaveChangesAsync();

            return Ok(games);
        }

        private bool gamesExists(int id)
        {
            return _context.games.Any(e => e.id == id);
        }
    }
}