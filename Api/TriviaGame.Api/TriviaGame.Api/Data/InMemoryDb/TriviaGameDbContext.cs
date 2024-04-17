using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.InMemoryDb;

public class TriviaGameDbContext : DbContext
{
    public TriviaGameDbContext(DbContextOptions<TriviaGameDbContext> options) : base(options) { }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<RoundEntity> Rounds { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }
}
