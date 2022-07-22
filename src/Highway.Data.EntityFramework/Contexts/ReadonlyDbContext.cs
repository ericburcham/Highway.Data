using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;

using Common.Logging;

namespace Highway.Data
{
    public class ReadonlyDbContext : DbContextBase
    {
        public ReadonlyDbContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log)
            : base(connectionString, mapping, contextConfiguration, log)
        {
            contextConfiguration?.ConfigureContext(this);
        }

        public ReadonlyDbContext(string databaseFirstConnectionString, ILog log)
            : base(databaseFirstConnectionString, log)
        {
        }

        public ReadonlyDbContext(DbConnection dbConnection, bool contextOwnsConnection, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log)
            : base(dbConnection, contextOwnsConnection, mapping, contextConfiguration, log)
        {
            contextConfiguration?.ConfigureContext(this);
        }

        public sealed override int SaveChanges()
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChanges)} on a {nameof(ReadonlyDbContext)}.");
        }

        public sealed override Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChangesAsync)} on a {nameof(ReadonlyDbContext)}.");
        }

        public sealed override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChangesAsync)} on a {nameof(ReadonlyDbContext)}.");
        }

        public sealed override DbSet<TEntity> Set<TEntity>()
        {
            throw new NotImplementedException($"Do not call {nameof(Set)} on a {nameof(ReadonlyDbContext)}.");
        }

        public sealed override DbSet Set(Type entityType)
        {
            throw new NotImplementedException($"Do not call {nameof(Set)} on a {nameof(ReadonlyDbContext)}.");
        }

        internal DbSet<TEntity> InnerSet<TEntity>()
            where TEntity : class
        {
            Log.Debug($"Querying Object {typeof(TEntity).Name}");
            var result = base.Set<TEntity>();
            Log.Trace($"Queried Object {typeof(TEntity).Name}");

            return result;
        }

        protected sealed override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            throw new NotImplementedException($"Do not call {nameof(ShouldValidateEntity)} on a {nameof(ReadonlyDbContext)}.");
        }

        protected sealed override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            throw new NotImplementedException($"Do not call {nameof(ValidateEntity)} on a {nameof(ReadonlyDbContext)}.");
        }
    }
}
