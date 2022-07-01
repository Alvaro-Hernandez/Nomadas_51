using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomadas51.Core.Infraestructure.Repository.Abstract;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;

namespace Nomadas51.Core.Infraestructure.Repository.Concrete
{
    public class HabitacionImagenesRepository : IBaseRepository<Habitacion_Imagenes, Guid>
    {
        private NomadasDB db;

        public HabitacionImagenesRepository(NomadasDB db)
        {
            this.db = db;
        }
        public Habitacion_Imagenes Create(Habitacion_Imagenes habitacion_Imagenes)
        {
            habitacion_Imagenes.id_imagen = Guid.NewGuid();
            db.Habitacion_Imagenes.Add(habitacion_Imagenes);
            return habitacion_Imagenes;
        }

        public void Delete(Guid entityId)
        {
            var selectedhabitacion_img = db.Habitacion_Imagenes
                .Where(hi => hi.id_imagen == entityId).FirstOrDefault();

            if(selectedhabitacion_img != null)
            {
                db.Habitacion_Imagenes.Remove(selectedhabitacion_img);
            }
        }

        public List<Habitacion_Imagenes> GetAll()
        {
            return db.Habitacion_Imagenes.ToList();
        }

        public Habitacion_Imagenes GetById(Guid entityId)
        {
            var selectedhabitacion_img = db.Habitacion_Imagenes
                .Where(hi => hi.id_imagen == entityId).FirstOrDefault();
            return selectedhabitacion_img;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Habitacion_Imagenes Update(Habitacion_Imagenes habitacion_Imagenes)
        {
            var selectedhabitacion_img = db.Habitacion_Imagenes
                .Where(hi => hi.id_imagen == habitacion_Imagenes.id_imagen)
                .FirstOrDefault();
            if(selectedhabitacion_img != null)
            {
                selectedhabitacion_img.imagen_habitacion = habitacion_Imagenes.imagen_habitacion;

                db.Entry(selectedhabitacion_img).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            return selectedhabitacion_img;
        }
    }
}

