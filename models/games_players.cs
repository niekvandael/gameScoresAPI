using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace game_scores.models
{
    public class games_players
    {
        [Key]
        public int id { get; set; }
        public int game_id { get; set; }
        public int player_id { get; set; }
    }
}
