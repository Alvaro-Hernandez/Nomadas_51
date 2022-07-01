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
    public class UsuarioClienteRepository : IBaseRepository<Usuario_Cliente, Guid>
    {
        private NomadasDB db;
        public UsuarioClienteRepository(NomadasDB db)
        {
            this.db = db;
        }

        public Usuario_Cliente Create(Usuario_Cliente usuario_Cliente)
        {
            usuario_Cliente.id_usuario_cliente = Guid.NewGuid();
            db.Usuarios_Cliente.Add(usuario_Cliente);
            return usuario_Cliente;
        }

        public void Delete(Guid entityId)
        {
            var selecteddUsuarioCliente = db.Usuarios_Cliente
                .Where(u => u.id_usuario_cliente == entityId).FirstOrDefault();
            if (selecteddUsuarioCliente != null)
            {
                db.Usuarios_Cliente.Remove(selecteddUsuarioCliente);
            }
        }

        public List<Usuario_Cliente> GetAll()
        {
            return db.Usuarios_Cliente.ToList();
        }

        public Usuario_Cliente GetById(Guid entityId)
        {
            var selectedUsuarioCliente = db.Usuarios_Cliente
                .Where(u => u.id_usuario_cliente == entityId).FirstOrDefault();
            return selectedUsuarioCliente;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Usuario_Cliente Update(Usuario_Cliente usuario_Cliente)
        {
            var selectedUsuarioCliente = db.Usuarios_Cliente
                .Where(u => u.id_usuario_cliente == usuario_Cliente.id_usuario_cliente)
                .FirstOrDefault();

            if (selectedUsuarioCliente != null)
            {
                selectedUsuarioCliente.nombres = usuario_Cliente.nombres;
                selectedUsuarioCliente.apellidos = usuario_Cliente.apellidos;
                selectedUsuarioCliente.dir_correoElectronico = usuario_Cliente.dir_correoElectronico;
                selectedUsuarioCliente.usuario = usuario_Cliente.usuario;
                selectedUsuarioCliente.contraseña = usuario_Cliente.contraseña;
                selectedUsuarioCliente.telefono = usuario_Cliente.telefono;


                db.Entry(selectedUsuarioCliente).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            return selectedUsuarioCliente;
        }
    }
}
