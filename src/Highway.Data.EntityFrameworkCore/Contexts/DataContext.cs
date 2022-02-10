using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

using Highway.Data.EntityFrameworkCore.Interfaces;
using Highway.Data.Interceptors.Events;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Highway.Data.EntityFrameworkCore.Contexts
{
    public class DataContext : DbContext, IEntityDataContext
    {
        private readonly string _connectionString;

        private readonly IMappingConfiguration _mapping;

        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DataContext(string connectionString, IMappingConfiguration mapping)
        {
            _connectionString = connectionString;
            _mapping = mapping;
        }

        public DataContext(DbContextOptions options, string connectionString, IMappingConfiguration mapping)
            : base(options)
        {
            _connectionString = connectionString;
            _mapping = mapping;
        }

        public event EventHandler<BeforeSave> BeforeSave;

        public event EventHandler<AfterSave> AfterSave;

        public virtual IQueryable<T> AsQueryable<T>()
            where T : class
        {
            return Set<T>();
        }

        public virtual T Attach<T>(T item)
            where T : class
        {
            // CODE REVIEW
            return base.Attach(item).Entity;
        }

        public virtual int Commit()
        {
            OnBeforeSave();
            ChangeTracker.DetectChanges();
            var results = SaveChanges();
            OnAfterSave();

            return results;
        }

        public virtual async Task<int> CommitAsync()
        {
            OnBeforeSave();
            ChangeTracker.DetectChanges();
            var results = await SaveChangesAsync();
            OnAfterSave();

            return results;
        }

        public virtual T Detach<T>(T item)
            where T : class
        {
            var entry = GetChangeTrackingEntry(item);
            if (entry == null)
            {
                throw new InvalidOperationException("Cannot detach an object that is not attached to the current context.");
            }

            entry.State = EntityState.Detached;

            return item;
        }

        public virtual int ExecuteSqlCommand(string sql, params DbParameter[] dbParams)
        {
            return Database.ExecuteSqlRaw(sql, dbParams);
        }

        public virtual IEnumerable<T> ExecuteSqlQuery<T>(string sql, params DbParameter[] dbParams)
            where T : class
        {
            return Set<T>().FromSqlRaw(sql, dbParams);
        }

        public virtual T Reload<T>(T item)
            where T : class
        {
            var entry = GetChangeTrackingEntry(item);

            if (entry == null)
            {
                throw new InvalidOperationException("You cannot reload an object that is not in the current Entity Framework data context");
            }

            entry.Reload();

            return item;
        }

        protected virtual EntityEntry<T> GetChangeTrackingEntry<T>(T item)
            where T : class
        {
            return Entry(item);
        }

        protected void OnAfterSave()
        {
            AfterSave?.Invoke(this, new AfterSave());
        }

        protected void OnBeforeSave()
        {
            BeforeSave?.Invoke(this, new BeforeSave());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_mapping != null)
            {
                _mapping.ConfigureModelBuilder(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        T IUnitOfWork.Add<T>(T item)
        {
            // CODE REVIEW:  Call Set<T>.Add?
            Add(item);

            return item;
        }

        T IUnitOfWork.Remove<T>(T item)
        {
            // CODE REVIEW:  Call Set<T>.Remove?
            Remove(item);

            return item;
        }

        T IUnitOfWork.Update<T>(T item)
        {
            // CODE REVIEW:  Call Set<T>.Update?
            Update(item);

            return item;
        }
    }
}
