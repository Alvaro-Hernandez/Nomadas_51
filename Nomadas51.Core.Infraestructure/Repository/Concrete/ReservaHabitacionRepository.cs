using System;
using System.Collections.Generic;
using System.Text;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Core.Infraestructure.Repository.Abstract;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Nomadas51.Core.Infraestructure.Repository.Concrete
{
    public class ReservaHabitacionRepository : IMovementRepository<Reserva_Habitacion, Guid>
    {
        private NomadasDB db;

        public ReservaHabitacionRepository(NomadasDB db)
        {
            this.db = db;
        }

        public void Cancel(Guid entityId)
        {
            var selectedReserva = db.Reserva_Habitaciones
                .Where( r => r.id_reserva == entityId).FirstOrDefault();

            if (selectedReserva == null)
            {
                throw new NullReferenceException("Esta intentando anular una venta que no existe");
            }

            selectedReserva.cancelado = true;
            db.Entry(selectedReserva).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Reserva_Habitacion Create(Reserva_Habitacion reserva_Habitacion)
        {
            reserva_Habitacion.id_reserva = Guid.NewGuid();
            db.Reserva_Habitaciones.Add(reserva_Habitacion);

            return reserva_Habitacion;
        }

        public List<Reserva_Habitacion> GetAll()
        {
            return db.Reserva_Habitaciones.ToList();
        }

        public Reserva_Habitacion GetById(Guid entityId)
        {
            var selectedReserva = db.Reserva_Habitaciones
                .Where(r => r.id_reserva == entityId).FirstOrDefault();
            return selectedReserva;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
