using game_scores.models;
using Microsoft.EntityFrameworkCore;

namespace MySqlDemo.Models
{
    public class WebAPIDataContext : DbContext
    {
        public WebAPIDataContext(DbContextOptions<WebAPIDataContext> options)
            : base(options)
        {
        }
        public DbSet<game_types> game_types { get; set; }
        public DbSet<games> games { get; set; }
        public DbSet<games_players> games_players { get; set; }
        public DbSet<games_scores> games_scores { get; set; }
        public DbSet<players> players { get; set; }

    }
}