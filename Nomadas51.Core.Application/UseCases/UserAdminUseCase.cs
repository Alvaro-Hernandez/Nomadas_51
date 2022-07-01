using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Core.Application.Interfaces;
using Nomadas51.Core.Infraestructure.Repository.Abstract;

namespace Nomadas51.Core.Application.UseCases
{
    public class UserAdminUseCase : IBaseUseCase<Usuario_Admin, Guid>
    {
        private readonly IBaseRepository<Usuario_Admin, Guid> repository;

        public UserAdminUseCase(IBaseRepository<Usuario_Admin, Guid> repository)
        {
            this.repository = repository;
        }

        public Usuario_Admin Create(Usuario_Admin entity)
        {
            if (entity != null) //Verifica que el objeto sea valido
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else //Devuelve nueva excepcion en caso de error
            {
                throw new Exception("Error. El Usuario Administrador no puede ser nulo");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Usuario_Admin> GetAll()
        {
            return repository.GetAll();
        }

        public Usuario_Admin GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Usuario_Admin Update(Usuario_Admin entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
