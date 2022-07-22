using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Common.Logging;

namespace Highway.Data
{
    public class DbContextBase : DbContext
    {
        private readonly bool _databaseFirst;

        private readonly IMappingConfiguration _mapping;

        public DbContextBase(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log)
            : base(connectionString)
        {
            Log = log;
            _mapping = mapping;
            Database.Log = Log.Debug;
            contextConfiguration?.ConfigureContext(this);
        }

        public DbContextBase(string databaseFirstConnectionString, ILog log)
            : base(databaseFirstConnectionString)
        {
            _databaseFirst = true;
            Log = log;
        }

        public DbContextBase(DbConnection dbConnection, bool contextOwnsConnection, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log)
            : base(dbConnection, contextOwnsConnection)
        {
            Log = log;
            _mapping = mapping;
            Database.Log = Log.Debug;
            contextConfiguration?.ConfigureContext(this);
        }

        protected internal ILog Log { get; }

        internal IEnumerable<T> ExecuteSqlQuery<T>(string sql, params DbParameter[] dbParams)
        {
            var parameters = dbParams.Select(x => $"{x.ParameterName} : {x.Value} : {x.DbType}\t").ToArray();

            Log.Trace($"Executing SQL {sql}, with parameters {string.Join(",", parameters)}");

            return Database.SqlQuery<T>(sql, dbParams);
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (_databaseFirst)
            {
                throw new UnintentionalCodeFirstException();
            }

            Log.Debug("\tOnModelCreating");
            if (_mapping != null)
            {
                Log.Trace($"\t\tMapping : {_mapping.GetType().Name}");
                _mapping.ConfigureModelBuilder(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
