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
    [Route("api/GamesScores")]
    public class GamesScoresController : Controller
    {
        private readonly WebAPIDataContext _context;

        public GamesScoresController(WebAPIDataContext context)
        {
            _context = context;
        }

        // GET: api/GamesScores
        [HttpGet]
        public IEnumerable<games_scores> Getgames_scores()
        {
            return _context.games_scores;
        }

        // GET: api/GamesScores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getgames_scores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games_scores = await _context.games_scores.SingleOrDefaultAsync(m => m.id == id);

            if (games_scores == null)
            {
                return NotFound();
            }

            return Ok(games_scores);
        }

        // PUT: api/GamesScores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgames_scores([FromRoute] int id, [FromBody] games_scores games_scores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != games_scores.id)
            {
                return BadRequest();
            }

            _context.Entry(games_scores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!games_scoresExists(id))
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

        // POST: api/GamesScores
        [HttpPost]
        public async Task<IActionResult> Postgames_scores([FromBody] games_scores games_scores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.games_scores.Add(games_scores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgames_scores", new { id = games_scores.id }, games_scores);
        }

        // DELETE: api/GamesScores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegames_scores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games_scores = await _context.games_scores.SingleOrDefaultAsync(m => m.id == id);
            if (games_scores == null)
            {
                return NotFound();
            }

            _context.games_scores.Remove(games_scores);
            await _context.SaveChangesAsync();

            return Ok(games_scores);
        }

        private bool games_scoresExists(int id)
        {
            return _context.games_scores.Any(e => e.id == id);
        }
    }
}