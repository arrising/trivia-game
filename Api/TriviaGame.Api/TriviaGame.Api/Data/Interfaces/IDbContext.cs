using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.Interfaces;

public interface IDbContext : IDisposable
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<RoundEntity> Rounds { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }
}
