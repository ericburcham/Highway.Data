using System.Collections.Generic;

using Highway.Data.EventManagement.Interfaces;

namespace Highway.Data.EntityFrameworkCore.Interfaces
{
    internal interface IDomain
    {
        string ConnectionString { get; }

        List<IInterceptor> Events { get; }

        IMappingConfiguration Mappings { get; }
    }
}
