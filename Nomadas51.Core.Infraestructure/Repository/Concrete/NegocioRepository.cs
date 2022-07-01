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
    public class NegocioRepository : IBaseRepository<Negocio, Guid>
    {
        private NomadasDB db;
        public NegocioRepository(NomadasDB db)
        {
            this.db = db;
        }
        public Negocio Create(Negocio negocio)
        {
            negocio.id_negocio = Guid.NewGuid();
            //Define nuevo identificador unico
            db.Negocios.Add(negocio);
            return negocio;
        }

        public void Delete(Guid entityId)
        {
            var selectedNegocio = db.Negocios
                .Where(n => n.id_negocio == entityId).FirstOrDefault();
            //Selecciona el negocio a aliminar atraves del Id
            if (selectedNegocio != null)
                //Verifica si el negocio existe
                db.Negocios.Remove(selectedNegocio);
        }

        public List<Negocio> GetAll()
        {
            return db.Negocios.ToList();
        }

        public Negocio GetById(Guid entityId)
        {
            var selectedNegocio = db.Negocios
                .Where(n => n.id_negocio == entityId).FirstOrDefault();
            return selectedNegocio;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Negocio Update(Negocio negocio)
        {
            var selectedNegocio = db.Negocios
                 .Where(n => n.id_negocio == negocio.id_negocio)
                 .FirstOrDefault();

            if (selectedNegocio != null)
            {
                selectedNegocio.nombre = negocio.nombre;
                selectedNegocio.descripcion = negocio.descripcion;
                selectedNegocio.imagen_local = negocio.imagen_local;
                selectedNegocio.direccion = negocio.direccion;
                selectedNegocio.ubicacion = negocio.ubicacion;
                selectedNegocio.telefono = negocio.telefono;
                selectedNegocio.dir_correoElectronico = negocio.dir_correoElectronico;

                db.Entry(selectedNegocio).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            return selectedNegocio;
        }
    }
}
