using System;
using System.Collections.Generic;
using System.Text;
using Nomadas51.Core.Domain.Interfaces;

namespace Nomadas51.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {
    }
}
