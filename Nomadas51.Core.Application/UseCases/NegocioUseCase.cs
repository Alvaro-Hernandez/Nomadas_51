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
    public class NegocioUseCase : IBaseUseCase<Negocio, Guid>
    {
        private readonly IBaseRepository<Negocio, Guid> repository;

        public NegocioUseCase(IBaseRepository<Negocio, Guid> repository)
        {
            this.repository = repository;
        }
        public Negocio Create(Negocio entity)
        {
            if (entity != null) //Verifica que el objeto sea valido
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else //Devuelve nueva excepcion en caso de error
            {
                throw new Exception("Error. El Negocio no puede ser nulo");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Negocio> GetAll()
        {
            return repository.GetAll();
        }

        public Negocio GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Negocio Update(Negocio entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
