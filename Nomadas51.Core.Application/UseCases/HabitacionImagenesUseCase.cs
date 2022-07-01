using System;
using System.Collections.Generic;
using System.Text;
using Nomadas51.Core.Application.Interfaces;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Core.Infraestructure.Repository.Abstract;
namespace Nomadas51.Core.Application.UseCases
{
    public class HabitacionImagenesUseCase : IBaseUseCase<Habitacion_Imagenes, Guid>
    {
        private readonly IBaseRepository<Habitacion_Imagenes, Guid> repository;

        public HabitacionImagenesUseCase(IBaseRepository<Habitacion_Imagenes, Guid> repository)
        {
            this.repository = repository;
        }
        public Habitacion_Imagenes Create(Habitacion_Imagenes entity)
        {
            if(entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else{
                throw new Exception("Error. la Reserva no puede ser nula");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Habitacion_Imagenes> GetAll()
        {
            return repository.GetAll();
        }

        public Habitacion_Imagenes GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Habitacion_Imagenes Update(Habitacion_Imagenes entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
