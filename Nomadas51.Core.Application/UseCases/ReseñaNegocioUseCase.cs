using System;
using System.Collections.Generic;
using System.Text;
using Nomadas51.Core.Application.Interfaces;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Core.Infraestructure.Repository.Abstract;

namespace Nomadas51.Core.Application.UseCases
{
    public class ReseñaNegocioUseCase : IBaseUseCase<Reseña_Negocio, Guid>
    {
        private readonly IBaseRepository<Reseña_Negocio, Guid> repository;

        public ReseñaNegocioUseCase(IBaseRepository<Reseña_Negocio, Guid> repository)
        {
            this.repository = repository;
        }

        public Reseña_Negocio Create(Reseña_Negocio entity)
        {
            if(entity != null)
            {
                //Verifica que el objeto sea valido
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
            {
                //Devuelve nueva excepcion en caso de error
                throw new Exception("Error. La reseña no puede ser nula");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Reseña_Negocio> GetAll()
        {
            return repository.GetAll();
        }

        public Reseña_Negocio GetById(Guid entityId)
        {
            return repository.GetById(entityId);    
        }

        public Reseña_Negocio Update(Reseña_Negocio entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
