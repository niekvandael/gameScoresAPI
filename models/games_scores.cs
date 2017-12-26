using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game_scores.models
{
    public class games_scores
    {
        public int id { get; set; }
        public int game_id { get; set; }
        public int player_id { get; set; }
        public int score { get; set; }
    }
}
