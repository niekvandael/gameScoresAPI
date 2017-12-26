using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace game_scores.models
{
    public class game_types
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string who_wins { get; set; }
    }
}
