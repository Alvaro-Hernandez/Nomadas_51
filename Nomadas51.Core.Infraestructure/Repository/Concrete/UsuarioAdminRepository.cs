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
    public class UsuarioAdminRepository : IBaseRepository<Usuario_Admin, Guid>
    {
        private NomadasDB db;
        public UsuarioAdminRepository(NomadasDB db)
        {
            this.db = db;
        }
        public Usuario_Admin Create(Usuario_Admin usuario_Admin)
        {
           usuario_Admin.id_usuario_admin = Guid.NewGuid();
           db.Usuarios_Admin.Add(usuario_Admin);
           return usuario_Admin;
        }

        public void Delete(Guid entityId)
        {
            var selectedUsuarioAdmin = db.Usuarios_Admin
                .Where(u => u.id_usuario_admin == entityId).FirstOrDefault();
            if(selectedUsuarioAdmin != null)
            {
                db.Usuarios_Admin.Remove(selectedUsuarioAdmin);
            }
        }

        public List<Usuario_Admin> GetAll()
        {
            return db.Usuarios_Admin.ToList();
        }

        public Usuario_Admin GetById(Guid entityId)
        {
            var selectedUsuarioAdmin = db.Usuarios_Admin
                .Where(u => u.id_usuario_admin == entityId).FirstOrDefault();
            return selectedUsuarioAdmin;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Usuario_Admin Update(Usuario_Admin usuario_Admin)
        {
            var selectedUsuarioAdmin = db.Usuarios_Admin
                .Where(u => u.id_usuario_admin == usuario_Admin.id_usuario_admin)
                .FirstOrDefault();

            if(selectedUsuarioAdmin != null)
            {
                selectedUsuarioAdmin.nombres = usuario_Admin.nombres;
                selectedUsuarioAdmin.apellidos = usuario_Admin.apellidos;
                selectedUsuarioAdmin.dir_correoElectronico = usuario_Admin.dir_correoElectronico;
                selectedUsuarioAdmin.usuario = usuario_Admin.usuario;
                selectedUsuarioAdmin.contraseña = usuario_Admin.contraseña;
                selectedUsuarioAdmin.telefono = usuario_Admin.telefono;


                db.Entry(selectedUsuarioAdmin).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedUsuarioAdmin;
        }
    }
}
