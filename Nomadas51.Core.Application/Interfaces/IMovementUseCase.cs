using System;
using System.Collections.Generic;
using System.Text;
using Nomadas51.Core.Domain.Interfaces;
namespace Nomadas51.Core.Application.Interfaces
{
    public interface IMovementUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>
    {
        void Cancel(EntityId entityId);
    }
}
