using System.Data.Common;

using Common.Logging;

namespace Highway.Data
{
    public class HighwayDbContext : DbContextBase
    {
        public HighwayDbContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log)
            : base(connectionString, mapping, contextConfiguration, log)
        {
            contextConfiguration?.ConfigureContext(this);
        }

        public HighwayDbContext(string databaseFirstConnectionString, ILog log)
            : base(databaseFirstConnectionString, log)
        {
        }

        public HighwayDbContext(DbConnection dbConnection, bool contextOwnsConnection, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log)
            : base(dbConnection, contextOwnsConnection, mapping, contextConfiguration, log)
        {
            contextConfiguration?.ConfigureContext(this);
        }
    }
}