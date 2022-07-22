using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

using Common.Logging;
using Common.Logging.Simple;

using Highway.Data.Interceptors.Events;

namespace Highway.Data
{
    /// <summary>
    ///     A base implementation of the Code First Data DataContext for Entity Framework
    /// </summary>
    public class DataContext : IEntityDataContext
    {
        private readonly HighwayDbContext _context;

        /// <summary>
        ///     Constructs a context
        /// </summary>
        /// <param name="connectionString">The standard SQL connection string for the Database</param>
        /// <param name="mapping">The Mapping Configuration that will determine how the tables and objects interact</param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(string connectionString, IMappingConfiguration mapping, string cacheKey = null)
            : this(connectionString, mapping, new DefaultContextConfiguration(), new NoOpLogger(), cacheKey)
        {
        }

        /// <summary>
        ///     Constructs a context
        /// </summary>
        /// <param name="connectionString">The standard SQL connection string for the Database</param>
        /// <param name="mapping">The Mapping Configuration that will determine how the tables and objects interact</param>
        /// <param name="log">The logger being supplied for this context ( Optional )</param>
        public DataContext(string connectionString, IMappingConfiguration mapping, ILog log, string cacheKey = null)
            : this(connectionString, mapping, new DefaultContextConfiguration(), log, cacheKey)
        {
        }

        /// <summary>
        ///     Constructs a context
        /// </summary>
        /// <param name="connectionString">The standard SQL connection string for the Database</param>
        /// <param name="mapping">The Mapping Configuration that will determine how the tables and objects interact</param>
        /// <param name="contextConfiguration">
        ///     The context specific configuration that will change context level behavior (
        ///     Optional )
        /// </param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(
            string connectionString,
            IMappingConfiguration mapping,
            IContextConfiguration contextConfiguration,
            string cacheKey = null)
            : this(connectionString, mapping, contextConfiguration, new NoOpLogger(), cacheKey)
        {
        }

        /// <summary>
        ///     Constructs a context
        /// </summary>
        /// <param name="connectionString">The standard SQL connection string for the Database</param>
        /// <param name="mapping">The Mapping Configuration that will determine how the tables and objects interact</param>
        /// <param name="contextConfiguration">The context specific configuration that will change context level behavior</param>
        /// <param name="log">The logger being supplied for this context ( Optional )</param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(
            string connectionString,
            IMappingConfiguration mapping,
            IContextConfiguration contextConfiguration,
            ILog log,
            string cacheKey = null)
        {
            _context = new HighwayDbContext(connectionString, mapping, contextConfiguration, log);
            if (!cacheKey.IsNullOrEmpty())
            {
                _context.CacheKey = cacheKey;
            }
        }

        /// <summary>
        ///     Database first way to construct the data context for Highway.Data.EntityFramework
        /// </summary>
        /// <param name="databaseFirstConnectionString">
        ///     The metadata embedded connection string from database first Entity
        ///     Framework
        /// </param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(string databaseFirstConnectionString, string cacheKey = null)
            : this(databaseFirstConnectionString, new NoOpLogger(), cacheKey)
        {
        }

        /// <summary>
        ///     Database first way to construct the data context for Highway.Data.EntityFramework
        /// </summary>
        /// <param name="databaseFirstConnectionString">
        ///     The metadata embedded connection string from database first Entity
        ///     Framework
        /// </param>
        /// <param name="log">The logger for the database first context</param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(string databaseFirstConnectionString, ILog log, string cacheKey = null)
        {
            _context = new HighwayDbContext(databaseFirstConnectionString, log);
            if (!cacheKey.IsNullOrEmpty())
            {
                _context.CacheKey = cacheKey;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataContext" /> class.
        /// </summary>
        /// <param name="dbConnection">The db connection.</param>
        /// <param name="contextOwnsConnection">The context owns connection.</param>
        /// <param name="mapping">The Mapping Configuration that will determine how the tables and objects interact</param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(DbConnection dbConnection, bool contextOwnsConnection, IMappingConfiguration mapping, string cacheKey = null)
            : this(dbConnection, contextOwnsConnection, mapping, new DefaultContextConfiguration(), new NoOpLogger(), cacheKey)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataContext" /> class.
        /// </summary>
        /// <param name="dbConnection">The db connection.</param>
        /// <param name="contextOwnsConnection">The context owns connection.</param>
        /// <param name="mapping">The Mapping Configuration that will determine how the tables and objects interact</param>
        /// <param name="log">The logger being supplied for this context ( Optional )</param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(
            DbConnection dbConnection,
            bool contextOwnsConnection,
            IMappingConfiguration mapping,
            ILog log,
            string cacheKey = null)
            : this(dbConnection, contextOwnsConnection, mapping, new DefaultContextConfiguration(), log, cacheKey)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataContext" /> class.
        /// </summary>
        /// <param name="dbConnection">The db connection.</param>
        /// <param name="contextOwnsConnection">The context owns connection.</param>
        /// <param name="mapping">The Mapping Configuration that will determine how the tables and objects interact</param>
        /// <param name="contextConfiguration">The context specific configuration that will change context level behavior</param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(
            DbConnection dbConnection,
            bool contextOwnsConnection,
            IMappingConfiguration mapping,
            IContextConfiguration contextConfiguration,
            string cacheKey = null)
            : this(dbConnection, contextOwnsConnection, mapping, contextConfiguration, new NoOpLogger(), cacheKey)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataContext" /> class.
        /// </summary>
        /// <param name="dbConnection">The db connection.</param>
        /// <param name="contextOwnsConnection">The context owns connection.</param>
        /// <param name="mapping">The Mapping Configuration that will determine how the tables and objects interact</param>
        /// <param name="contextConfiguration">The context specific configuration that will change context level behavior</param>
        /// <param name="log">The logger being supplied for this context ( Optional )</param>
        /// <param name="cacheKey">The Cache Key used by the DbModelBuilder to determine if the private DbContext instance needs to invoke its OnModelCreating method.</param>
        public DataContext(
            DbConnection dbConnection,
            bool contextOwnsConnection,
            IMappingConfiguration mapping,
            IContextConfiguration contextConfiguration,
            ILog log,
            string cacheKey = null)
        {
            _context = new HighwayDbContext(dbConnection, contextOwnsConnection, mapping, contextConfiguration, log);
            if (!cacheKey.IsNullOrEmpty())
            {
                _context.CacheKey = cacheKey;
            }
        }

        public event EventHandler<BeforeSave> BeforeSave;

        public event EventHandler<AfterSave> AfterSave;

        /// <summary>
        ///     Adds the provided instance of <typeparamref name="T" /> to the data context
        /// </summary>
        /// <typeparam name="T">The Entity Type being added</typeparam>
        /// <param name="item">The <typeparamref name="T" /> you want to add</param>
        /// <returns>The <typeparamref name="T" /> you added</returns>
        public virtual T Add<T>(T item)
            where T : class
        {
            _context.Log.DebugFormat("Adding Object {0}", item);
            _context.Set<T>().Add(item);
            _context.Log.TraceFormat("Added Object {0}", item);

            return item;
        }

        /// <summary>
        ///     This gives a mockable wrapper around the normal <see cref="DbSet{T}" /> method that allows for testability
        ///     This method is now virtual to allow for the injection of cross cutting concerns.
        /// </summary>
        /// <typeparam name="T">The Entity being queried</typeparam>
        /// <returns>
        ///     <see cref="IQueryable{T}" />
        /// </returns>
        public virtual IQueryable<T> AsQueryable<T>()
            where T : class
        {
            _context.Log.DebugFormat("Querying Object {0}", typeof(T).Name);
            var result = _context.Set<T>();
            _context.Log.TraceFormat("Queried Object {0}", typeof(T).Name);

            return result;
        }

        /// <summary>
        ///     Attaches the provided instance of <typeparamref name="T" /> to the data context
        /// </summary>
        /// <typeparam name="T">The Entity Type being attached</typeparam>
        /// <param name="item">The <typeparamref name="T" /> you want to attach</param>
        /// <returns>The <typeparamref name="T" /> you attached</returns>
        public virtual T Attach<T>(T item)
            where T : class
        {
            _context.Log.DebugFormat("Attaching Object {0}", item);
            _context.Set<T>().Attach(item);
            _context.Log.TraceFormat("Attached Object {0}", item);

            return item;
        }

        /// <summary>
        ///     Commits all currently tracked entity changes
        /// </summary>
        /// <returns>the number of rows affected</returns>
        public virtual int Commit()
        {
            OnBeforeSave();
            _context.Log.Trace("\tCommit");
            _context.ChangeTracker.DetectChanges();
            var result = _context.SaveChanges();
            _context.Log.DebugFormat("\tCommitted {0} Changes", result);
            OnAfterSave();

            return result;
        }

        /// <summary>
        ///     Commits all currently tracked entity changes asynchronously
        /// </summary>
        /// <returns>the number of rows affected</returns>
        public virtual async Task<int> CommitAsync()
        {
            OnBeforeSave();
            _context.Log.Trace("\tCommit");
            _context.ChangeTracker.DetectChanges();
            var result = await _context.SaveChangesAsync();
            _context.Log.DebugFormat("\tCommitted {0} Changes", result);
            OnAfterSave();

            return result;
        }

        /// <summary>
        ///     Detaches the provided instance of <typeparamref name="T" /> from the data context
        /// </summary>
        /// <typeparam name="T">The Entity Type being detached</typeparam>
        /// <param name="item">The <typeparamref name="T" /> you want to detach</param>
        /// <returns>The <typeparamref name="T" /> you detached</returns>
        public virtual T Detach<T>(T item)
            where T : class
        {
            _context.Log.TraceFormat("Retrieving State Entry For Object {0}", item);
            var entry = GetChangeTrackingEntry(item);
            _context.Log.DebugFormat("Detaching Object {0}", item);
            if (entry == null)
            {
                throw new InvalidOperationException("Cannot detach an object that is not attached to the current context.");
            }

            entry.State = EntityState.Detached;
            _context.Log.TraceFormat("Detached Object {0}", item);

            return item;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        /// <summary>
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="dbParams"></param>
        /// <returns></returns>
        public virtual int ExecuteFunction(string procedureName, params ObjectParameter[] dbParams)
        {
            var parameters =
                dbParams.Select(x => $"{x.Name} : {x.Value} : {x.ParameterType}\t").ToArray();

            _context.Log.TraceFormat("Executing Procedure {0}, with parameters {1}", procedureName, string.Join(",", parameters));

            return _context.Database.SqlQuery<int>(procedureName, dbParams).FirstOrDefault();
        }

        /// <summary>
        ///     Executes a SQL command and returns the standard int return from the query
        /// </summary>
        /// <param name="sql">The Sql Statement</param>
        /// <param name="dbParams">A List of Database Parameters for the Query</param>
        /// <returns>The rows affected</returns>
        public virtual int ExecuteSqlCommand(string sql, params DbParameter[] dbParams)
        {
            var parameters =
                dbParams.Select(x => $"{x.ParameterName} : {x.Value} : {x.DbType}\t").ToArray();

            _context.Log.TraceFormat("Executing SQL {0}, with parameters {1}", sql, string.Join(",", parameters));

            return _context.Database.ExecuteSqlCommand(sql, dbParams);
        }

        /// <summary>
        ///     Executes a SQL command and tries to map the returned dataset into an <see cref="IEnumerable{T}" />
        ///     The results should have the same column names as the Entity Type has properties
        /// </summary>
        /// <typeparam name="T">The Entity Type that the return should be mapped to</typeparam>
        /// <param name="sql">The Sql Statement</param>
        /// <param name="dbParams">A List of Database Parameters for the Query</param>
        /// <returns>An <see cref="IEnumerable{T}" /> from the query return</returns>
        public virtual IEnumerable<T> ExecuteSqlQuery<T>(string sql, params DbParameter[] dbParams)
        {
            return _context.ExecuteSqlQuery<T>(sql, dbParams);
        }

        /// <summary>
        ///     Reloads the provided instance of <typeparamref name="T" /> from the database
        /// </summary>
        /// <typeparam name="T">The Entity Type being reloaded</typeparam>
        /// <param name="item">The <typeparamref name="T" /> you want to reload</param>
        /// <returns>The <typeparamref name="T" /> you reloaded</returns>
        public virtual T Reload<T>(T item)
            where T : class
        {
            _context.Log.TraceFormat("Retrieving State Entry For Object {0}", item);
            var entry = GetChangeTrackingEntry(item);
            _context.Log.DebugFormat("Reloading Object {0}", item);
            if (entry == null)
            {
                throw new InvalidOperationException("You cannot reload an object that is not in the current Entity Framework data context");
            }

            entry.Reload();
            _context.Log.TraceFormat("Reloaded Object {0}", item);

            return item;
        }

        /// <summary>
        ///     Removes the provided instance of <typeparamref name="T" /> from the data context
        /// </summary>
        /// <typeparam name="T">The Entity Type being removed</typeparam>
        /// <param name="item">The <typeparamref name="T" /> you want to remove</param>
        /// <returns>The <typeparamref name="T" /> you removed</returns>
        public virtual T Remove<T>(T item)
            where T : class
        {
            _context.Log.DebugFormat("Removing Object {0}", item);
            _context.Set<T>().Remove(item);
            _context.Log.TraceFormat("Removed Object {0}", item);

            return item;
        }

        /// <summary>
        ///     Updates the provided instance of <typeparamref name="T" /> in the data context
        /// </summary>
        /// <typeparam name="T">The Entity Type being updated</typeparam>
        /// <param name="item">The <typeparamref name="T" /> you want to update</param>
        /// <returns>The <typeparamref name="T" /> you updated</returns>
        public virtual T Update<T>(T item)
            where T : class
        {
            _context.Log.TraceFormat("Retrieving State Entry For Object {0}", item);
            var entry = GetChangeTrackingEntry(item);
            _context.Log.DebugFormat("Updating Object {0}", item);
            if (entry == null)
            {
                throw new InvalidOperationException("Cannot Update an object that is not attacched to the current Entity Framework data context");
            }

            entry.State = EntityState.Modified;
            _context.Log.TraceFormat("Updated Object {0}", item);

            return item;
        }

        protected virtual DbEntityEntry<T> GetChangeTrackingEntry<T>(T item)
            where T : class
        {
            return _context.Entry(item);
        }

        protected void OnAfterSave()
        {
            AfterSave?.Invoke(this, new AfterSave());
        }

        protected void OnBeforeSave()
        {
            BeforeSave?.Invoke(this, new BeforeSave());
        }
    }
}
