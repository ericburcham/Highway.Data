using System.Collections.Generic;

using Highway.Data.EventManagement.Interfaces;

namespace Highway.Data.EntityFramework.ReadonlyTests
{
    public class Domain : IDomain
    {
        public string ConnectionString { get; } = Configuration.Instance.TestDatabaseConnectionString;

        public IContextConfiguration Context { get; } = new DefaultContextConfiguration();

        public List<IInterceptor> Events { get; } = new();

        public IMappingConfiguration Mappings { get; } = new MappingConfiguration();
    }
}
