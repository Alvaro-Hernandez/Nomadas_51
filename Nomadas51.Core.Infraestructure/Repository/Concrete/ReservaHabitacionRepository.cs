using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Core.Infraestructure.Repository.Abstract;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Nomadas51.Core.Infraestructure.Repository.Concrete
{
    public class ReservaHabitacionRepository : IBaseRepository<Reserva_Habitacion, Guid>
    {
        private NomadasDB db;

        public ReservaHabitacionRepository(NomadasDB db)
        {
            this.db = db;
        }

        public Reserva_Habitacion Create(Reserva_Habitacion reserva_Habitacion)
        {
            reserva_Habitacion.id_reserva = Guid.NewGuid();
            //Define nuevo idenfitificador unico
            db.Reserva_Habitaciones.Add(reserva_Habitacion);
            return reserva_Habitacion;
        }

        public void Delete(Guid entityId)
        {
            var selectedReservaHabitacion = db.Reserva_Habitaciones
                .Where(r => r.id_reserva == entityId)
                .FirstOrDefault();
            //Selecciona la reserva a eliminar atraves del Id
            if(selectedReservaHabitacion != null)
            {
                //Verifica si la reserva existe
                db.Reserva_Habitaciones.Remove(selectedReservaHabitacion);
            }
        }

        public List<Reserva_Habitacion> GetAll()
        {
            return db.Reserva_Habitaciones.ToList();
        }

        public Reserva_Habitacion GetById(Guid entityId)
        {
            var selectedReservaHabitacion = db.Reserva_Habitaciones
                .Where(r => r.id_reserva == entityId)
                .FirstOrDefault();
            return selectedReservaHabitacion;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Reserva_Habitacion Update(Reserva_Habitacion reserva_Habitacion)
        {
            var selectedReservaHabitacion = db.Reserva_Habitaciones
                .Where( r => r.id_reserva == reserva_Habitacion.id_reserva)
                .FirstOrDefault();
            if(selectedReservaHabitacion != null)
            {
                selectedReservaHabitacion.dias_reservados = reserva_Habitacion.dias_reservados;
                selectedReservaHabitacion.fecha_entrada = reserva_Habitacion.fecha_entrada;
                selectedReservaHabitacion.fecha_salida = reserva_Habitacion.fecha_salida;
                selectedReservaHabitacion.costo_total = reserva_Habitacion.costo_total;
                //Modifica los datos de la reserva con los valores del parametro

                db.Entry(selectedReservaHabitacion).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado de la reserva como modificado
            }
            return selectedReservaHabitacion;
        }
    }
}
