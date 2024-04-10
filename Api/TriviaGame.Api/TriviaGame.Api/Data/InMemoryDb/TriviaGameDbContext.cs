using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Data.InMemoryDb;

public class TriviaGameDbContext : DbContext
{
    public TriviaGameDbContext(DbContextOptions<TriviaGameDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Round> Rounds { get; set; }
    public DbSet<Question> Questions { get; set; }
}
