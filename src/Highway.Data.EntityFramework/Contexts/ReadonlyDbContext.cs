using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Common.Logging;

using Microsoft.EntityFrameworkCore;

namespace Highway.Data
{
    internal class ReadonlyDbContext : DbContext
    {
        private readonly string _connectionString;

        private readonly ILog _log;

        private readonly IMappingConfiguration _mapping;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public ReadonlyDbContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log)
        {
            _connectionString = connectionString;
            _log = log;
            _mapping = mapping;
            contextConfiguration?.ConfigureContext(this);
        }

        public sealed override int SaveChanges()
        {
            throw new NotImplementedException($"Do not call {nameof(SaveChanges)} on a {nameof(ReadonlyDbContext)}.");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
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

        public override DbSet<TEntity> Set<TEntity>(string name)
        {
            throw new NotImplementedException($"Do not call {nameof(Set)} on a {nameof(ReadonlyDbContext)}.");
        }

        internal DbSet<TEntity> InnerSet<TEntity>()
            where TEntity : class
        {
            _log.Debug($"Querying Object {typeof(TEntity).Name}");
            var result = base.Set<TEntity>();
            _log.Trace($"Queried Object {typeof(TEntity).Name}");

            return result;
        }

        /// <summary>
        ///     This method is called when the model for a derived context has been initialized, but
        ///     before the model has been locked down and used to initialize the context.  The default
        ///     implementation of this method takes the <see cref="IMappingConfiguration" /> array passed in on construction and
        ///     applies them.
        ///     If no configuration mappings were passed it it does nothing.
        /// </summary>
        /// <remarks>
        ///     Typically, this method is called only once when the first instance of a derived context
        ///     is created.  The model for that context is then cached and is for all further instances of
        ///     the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///     property on the given ModelBuilder, but note that this can seriously degrade performance.
        ///     More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///     classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _log.Debug("\tOnModelCreating");
            if (_mapping != null)
            {
                _log.Trace($"\t\tMapping : {_mapping.GetType().Name}");
                _mapping.ConfigureModelBuilder(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
