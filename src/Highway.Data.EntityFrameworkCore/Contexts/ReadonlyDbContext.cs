using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Highway.Data.EntityFrameworkCore.Contexts
{
    internal class ReadonlyDbContext : DbContext
    {
        public ReadonlyDbContext()
        {
        }

        public ReadonlyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public override ChangeTracker ChangeTracker => throw new NotImplementedException($"Do not call {nameof(ChangeTracker)} on a {nameof(ReadonlyDbContext)}.");

        public override DatabaseFacade Database => throw new NotImplementedException($"Do not call {nameof(Database)} on a {nameof(ReadonlyDbContext)}.");

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChanges)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override EntityEntry Add(object entity)
        {
            throw new NotImplementedException($"Do not call {nameof(Add)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException($"Do not call {nameof(AddAsync)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException($"Do not call {nameof(AddAsync)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override void AddRange(params object[] entities)
        {
            throw new NotImplementedException($"Do not call {nameof(AddRange)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override void AddRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException($"Do not call {nameof(AddRange)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override Task AddRangeAsync(params object[] entities)
        {
            throw new NotImplementedException($"Do not call {nameof(AddRangeAsync)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException($"Do not call {nameof(AddRangeAsync)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
        {
            throw new NotImplementedException($"Do not call {nameof(Attach)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override EntityEntry Attach(object entity)
        {
            throw new NotImplementedException($"Do not call {nameof(Attach)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override void AttachRange(params object[] entities)
        {
            throw new NotImplementedException($"Do not call {nameof(AttachRange)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override void AttachRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException($"Do not call {nameof(AttachRange)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            throw new NotImplementedException($"Do not call {nameof(Remove)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override EntityEntry Remove(object entity)
        {
            throw new NotImplementedException($"Do not call {nameof(Remove)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override void RemoveRange(params object[] entities)
        {
            throw new NotImplementedException($"Do not call {nameof(RemoveRange)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override void RemoveRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException($"Do not call {nameof(RemoveRange)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChanges)} on a {nameof(ReadonlyDbContext)}.");
        }

        public sealed override int SaveChanges()
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChanges)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChangesAsync)} on a {nameof(ReadonlyDbContext)}.");
        }

        public sealed override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChangesAsync)} on a {nameof(ReadonlyDbContext)}.");
        }

        public sealed override DbSet<TEntity> Set<TEntity>()
        {
            throw new NotImplementedException($"Do not call {nameof(Set)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override DbSet<TEntity> Set<TEntity>(string name)
        {
            throw new NotImplementedException($"Do not call {nameof(Set)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            throw new NotImplementedException($"Do not call {nameof(Update)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override EntityEntry Update(object entity)
        {
            throw new NotImplementedException($"Do not call {nameof(Update)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override void UpdateRange(params object[] entities)
        {
            throw new NotImplementedException($"Do not call {nameof(UpdateRange)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override void UpdateRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException($"Do not call {nameof(UpdateRange)} on a {nameof(ReadonlyDbContext)}.");
        }
    }
}
