using System.Collections.Generic;

using Highway.Data.EntityFrameworkCore.Interfaces;
using Highway.Data.EventManagement.Interfaces;

namespace Highway.Data.EntityFrameworkCore.ReadonlyTests
{
    internal class Domain : IDomain
    {
        public string ConnectionString { get; }

        public List<IInterceptor> Events { get; } = new();

        public IMappingConfiguration Mappings { get; } = new MappingConfiguration();
    }
}
