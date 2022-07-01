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
    public class HabitacionUseCase : IBaseUseCase<Habitacion, Guid>
    {
        private readonly IBaseRepository<Habitacion, Guid> repository;

        public HabitacionUseCase(IBaseRepository<Habitacion, Guid> repository)
        {
            this.repository = repository;
        }
        public Habitacion Create(Habitacion entity)
        {
            if (entity != null) //Verifica que el objeto sea valido
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else //Devuelve nueva excepcion en caso de error
            {
                throw new Exception("Error. La Habitacion no puede ser nula");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Habitacion> GetAll()
        {
            return repository.GetAll();
        }

        public Habitacion GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Habitacion Update(Habitacion entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
