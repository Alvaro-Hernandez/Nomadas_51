using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomadas51.Core.Domain.Interfaces;

namespace Nomadas51.Core.Infraestructure.Repository.Abstract
{
    public interface IMovementRepository<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity,EntityId>, ITransaction
    {
        void Cancel(Guid entityId);
    }
}
