using System;
using System.Collections.Generic;
using System.Text;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Core.Infraestructure.Repository.Abstract;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;

namespace Nomadas51.Core.Infraestructure.Repository.Concrete
{
    public class ReservaDetallesRepository : IDetailRepository<ReservaDetalles, Guid>
    {
        private NomadasDB db;

        public ReservaDetallesRepository(NomadasDB db)
        {
            this.db = db;
        }

        public ReservaDetalles Create(ReservaDetalles entity)
        {
            db.ReservaDetalles.Add(entity);
            return entity;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
