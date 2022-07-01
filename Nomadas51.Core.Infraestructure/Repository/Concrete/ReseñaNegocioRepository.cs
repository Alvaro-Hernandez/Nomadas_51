using System;
using System.Collections.Generic;
using System.Text;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Core.Infraestructure.Repository.Abstract;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Nomadas51.Core.Infraestructure.Repository.Concrete
{
    public class ReseñaNegocioRepository : IBaseRepository<Reseña_Negocio, Guid>
    {
        private NomadasDB db;
        public ReseñaNegocioRepository(NomadasDB db)
        {
            this.db = db;
        }
        public Reseña_Negocio Create(Reseña_Negocio reseña_Negocio)
        {
            reseña_Negocio.id_reseña = Guid.NewGuid();
            //Define nuevo identificador unico
            db.Reseña_Negocios.Add(reseña_Negocio);
            return reseña_Negocio;
        }

        public void Delete(Guid entityId)
        {
            var selectedReseñaNegocio = db.Reseña_Negocios
                .Where(r => r.id_reseña == entityId)
                .FirstOrDefault();
            //Selecciona el negocio a eliminar atravez del id
            if(selectedReseñaNegocio != null)
            {
                //Verifica si el negocio existe
                db.Reseña_Negocios.Remove(selectedReseñaNegocio);
            }
        }

        public List<Reseña_Negocio> GetAll()
        {
            return db.Reseña_Negocios.ToList();
        }

        public Reseña_Negocio GetById(Guid entityId)
        {
            var selectedReseñaNegocio = db.Reseña_Negocios
                .Where(r => r.id_reseña == entityId)
                .FirstOrDefault();
            return selectedReseñaNegocio;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Reseña_Negocio Update(Reseña_Negocio reseña_Negocio)
        {
            var selectedReseñaNegocio = db.Reseña_Negocios
                .Where(r => r.id_reseña == reseña_Negocio.id_reseña)
                .FirstOrDefault();
            //Seleccionar el usuario por id desde la BD
            if(selectedReseñaNegocio != null)
            {
                //Verifica que la reseña existe
                selectedReseñaNegocio.opinion = reseña_Negocio.opinion;
                selectedReseñaNegocio.valoracion = reseña_Negocio.valoracion;
                //Modifica los datos de la reseña con los valores del parametro

                db.Entry(selectedReseñaNegocio).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarca el estado de la reseña como modificado
            }
            return selectedReseñaNegocio;
        }
    }
}
