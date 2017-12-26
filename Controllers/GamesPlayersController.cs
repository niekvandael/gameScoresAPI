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
    [Route("api/GamesPlayers")]
    public class GamesPlayersController : Controller
    {
        private readonly WebAPIDataContext _context;

        public GamesPlayersController(WebAPIDataContext context)
        {
            _context = context;
        }

        // GET: api/GamesPlayers
        [HttpGet]
        public IEnumerable<games_players> Getgames_players()
        {
            return _context.games_players;
        }

        // GET: api/GamesPlayers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getgames_players([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games_players = await _context.games_players.SingleOrDefaultAsync(m => m.id == id);

            if (games_players == null)
            {
                return NotFound();
            }

            return Ok(games_players);
        }

        // PUT: api/GamesPlayers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgames_players([FromRoute] int id, [FromBody] games_players games_players)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != games_players.id)
            {
                return BadRequest();
            }

            _context.Entry(games_players).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!games_playersExists(id))
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

        // POST: api/GamesPlayers
        [HttpPost]
        public async Task<IActionResult> Postgames_players([FromBody] games_players games_players)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.games_players.Add(games_players);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgames_players", new { id = games_players.id }, games_players);
        }

        // DELETE: api/GamesPlayers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegames_players([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games_players = await _context.games_players.SingleOrDefaultAsync(m => m.id == id);
            if (games_players == null)
            {
                return NotFound();
            }

            _context.games_players.Remove(games_players);
            await _context.SaveChangesAsync();

            return Ok(games_players);
        }

        private bool games_playersExists(int id)
        {
            return _context.games_players.Any(e => e.id == id);
        }
    }
}