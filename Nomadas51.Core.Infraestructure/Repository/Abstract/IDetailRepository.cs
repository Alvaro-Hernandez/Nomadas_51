using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomadas51.Core.Domain.Interfaces;
using Nomadas51.Core.Domain.Models;

namespace Nomadas51.Core.Infraestructure.Repository.Abstract
{
    public interface IDetailRepository<Entity, TransactionId> : ICreate<Entity>, ITransaction
    {
        List<Entity> GetDetailsByTransaction(TransactionId transactionId);
        void Cancel(Guid entityId);
    }
}
