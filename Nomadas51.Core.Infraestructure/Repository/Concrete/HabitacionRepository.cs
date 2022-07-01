using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Core.Infraestructure.Repository.Abstract;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;

namespace Nomadas51.Core.Infraestructure.Repository.Concrete
{
    public class HabitacionRepository : IBaseRepository<Habitacion, Guid>
    {
        private NomadasDB db;
        public HabitacionRepository(NomadasDB db)
        {
            this.db = db;
        }
        public Habitacion Create(Habitacion habitacion)
        {
            habitacion.id_habitacion = Guid.NewGuid();
            db.Habitaciones.Add(habitacion);
            return habitacion;
        }

        public void Delete(Guid entityId)
        {
            var selectedHabitacion = db.Habitaciones
                 .Where(h => h.id_habitacion == entityId).FirstOrDefault();
            if (selectedHabitacion != null)
                db.Habitaciones.Remove(selectedHabitacion);
        }

        public List<Habitacion> GetAll()
        {
            return db.Habitaciones.ToList();
        }

        public Habitacion GetById(Guid entityId)
        {
            var selectedHabitacion = db.Habitaciones
                .Where(h => h.id_habitacion == entityId).FirstOrDefault();
            return selectedHabitacion;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Habitacion Update(Habitacion habitacion)
        {
            var selectedHabitacion = db.Habitaciones
                 .Where(h => h.id_habitacion == habitacion.id_habitacion)
                 .FirstOrDefault();
            if( selectedHabitacion!= null)
            {
                selectedHabitacion.dimensiones = habitacion.dimensiones;
                selectedHabitacion.descripcion = habitacion.descripcion;
                selectedHabitacion.renta_por_dia = habitacion.renta_por_dia;

                db.Entry(selectedHabitacion).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedHabitacion;
        }
    }
}
