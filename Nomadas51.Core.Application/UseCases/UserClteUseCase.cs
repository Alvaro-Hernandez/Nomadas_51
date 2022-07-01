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
    public class UserClteUseCase : IBaseUseCase<Usuario_Cliente, Guid>
    {
        private readonly IBaseRepository<Usuario_Cliente, Guid> repository;

        public UserClteUseCase(IBaseRepository<Usuario_Cliente, Guid> repository)
        {
            this.repository = repository;
        }

        public Usuario_Cliente Create(Usuario_Cliente entity)
        {
            if(entity != null) //Verifica que el objeto sea valido
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else //Devuelve nueva excepcion en caso de error
            {
                throw new Exception("Error. El Usuario o Cliente no puede ser nulo");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Usuario_Cliente> GetAll()
        {
            return repository.GetAll();
        }

        public Usuario_Cliente GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Usuario_Cliente Update(Usuario_Cliente entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
