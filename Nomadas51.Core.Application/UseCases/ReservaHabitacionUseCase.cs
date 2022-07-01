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
    public class ReservaHabitacionUseCase : IBaseUseCase<Reserva_Habitacion, Guid>
    {
        private readonly IBaseRepository<Reserva_Habitacion, Guid> repository;

        public ReservaHabitacionUseCase(IBaseRepository<Reserva_Habitacion, Guid> repository)
        {
            this.repository = repository;
        }
        public Reserva_Habitacion Create(Reserva_Habitacion entity)
        {
            if(entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
            {
                throw new Exception("Error. La Reserva de Habitacion no puede ser nula");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Reserva_Habitacion> GetAll()
        {
            return repository.GetAll();
        }

        public Reserva_Habitacion GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Reserva_Habitacion Update(Reserva_Habitacion entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
