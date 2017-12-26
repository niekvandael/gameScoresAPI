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
    [Route("api/GameTypes")]
    public class GameTypesController : Controller
    {
        private readonly WebAPIDataContext _context;

        public GameTypesController(WebAPIDataContext context)
        {
            _context = context;
        }

        // GET: api/GameTypes
        [HttpGet]
        public IEnumerable<game_types> Getgame_types()
        {
            return _context.game_types;
        }

        // GET: api/GameTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getgame_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game_types = await _context.game_types.SingleOrDefaultAsync(m => m.id == id);

            if (game_types == null)
            {
                return NotFound();
            }

            return Ok(game_types);
        }

        // PUT: api/GameTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgame_types([FromRoute] int id, [FromBody] game_types game_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game_types.id)
            {
                return BadRequest();
            }

            _context.Entry(game_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!game_typesExists(id))
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

        // POST: api/GameTypes
        [HttpPost]
        public async Task<IActionResult> Postgame_types([FromBody] game_types game_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.game_types.Add(game_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgame_types", new { id = game_types.id }, game_types);
        }

        // DELETE: api/GameTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegame_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game_types = await _context.game_types.SingleOrDefaultAsync(m => m.id == id);
            if (game_types == null)
            {
                return NotFound();
            }

            _context.game_types.Remove(game_types);
            await _context.SaveChangesAsync();

            return Ok(game_types);
        }

        private bool game_typesExists(int id)
        {
            return _context.game_types.Any(e => e.id == id);
        }
    }
}