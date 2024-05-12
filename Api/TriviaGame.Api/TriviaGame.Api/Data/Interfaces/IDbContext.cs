using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.Interfaces;

public interface IDbContext : IDisposable
{
     DbSet<CategoryEntity> Categories { get; set; }
     DbSet<GameEntity> Games { get; set; }
     DbSet<RoundEntity> Rounds { get; set; }
     DbSet<QuestionEntity> Questions { get; set; }

     // Not Sure if these will help
     EntityEntry Entry(object entity);
     EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
         where TEntity : class;

     DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
