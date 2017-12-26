using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace game_scores.models
{
    public class players
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }
}
