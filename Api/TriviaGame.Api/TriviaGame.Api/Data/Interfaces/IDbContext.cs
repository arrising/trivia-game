using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.Interfaces;

public interface IDbContext : IDisposable
{
     DbSet<CategoryEntity> Categories { get; set; }
     DbSet<GameEntity> Games { get; set; }
     DbSet<RoundEntity> Rounds { get; set; }
     DbSet<QuestionEntity> Questions { get; set; }

     Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
