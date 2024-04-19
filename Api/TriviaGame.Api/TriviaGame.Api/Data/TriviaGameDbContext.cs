using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data;

public class TriviaGameDbContext : DbContext, IDbContext
{
    public TriviaGameDbContext(DbContextOptions<TriviaGameDbContext> options) : base(options) { }

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<RoundEntity> Rounds { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionEntity>()
            .HasOne(m => m.Category)
            .WithMany(m => m.Questions)
            .HasForeignKey(m => m.CategoryId);

        modelBuilder.Entity<CategoryEntity>()
            .HasOne(m => m.Round)
            .WithMany(m => m.Categories)
            .HasForeignKey(m => m.RoundId);

        modelBuilder.Entity<RoundEntity>()
            .HasOne(m => m.Game)
            .WithMany(m => m.Rounds)
            .HasForeignKey(m => m.GameId);
    }
}
