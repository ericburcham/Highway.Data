using System.Collections.Generic;

using Highway.Data.EventManagement.Interfaces;

namespace Highway.Data.EntityFrameworkCore.Interfaces
{
    public interface IDomain
    {
        string ConnectionString { get; }

        // IContextConfiguration ContextConfiguration { get; }

        List<IInterceptor> Events { get; }

        IMappingConfiguration Mappings { get; }
    }
}
