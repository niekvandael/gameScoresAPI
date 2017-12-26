using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MySqlDemo.Models;
using game_scores.models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly WebAPIDataContext _context;

        public PlayersController(WebAPIDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<players> GetAll()
        {
            return _context.players.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.players.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }  
    }
}