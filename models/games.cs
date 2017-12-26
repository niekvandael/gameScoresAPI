using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace game_scores.models
{
    public class games
    {
        [Key]
        public int id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int finished { get; set; }
        public int game_type { get; set; }
        public int user_id { get; set; }
    }
}
