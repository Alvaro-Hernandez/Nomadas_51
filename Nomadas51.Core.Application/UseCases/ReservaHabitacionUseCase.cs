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
    public class ReservaHabitacionUseCase : IMovementUseCase<Reserva_Habitacion, Guid>
    {
        private readonly IMovementRepository<Reserva_Habitacion, Guid> repoReserva;
        private readonly IBaseRepository<Habitacion, Guid> repoHabitacion;
        private readonly IDetailRepository<ReservaDetalles, Guid> repoReservaDetalles;

        public ReservaHabitacionUseCase(IMovementRepository<Reserva_Habitacion, Guid> repoReserva, IBaseRepository<Habitacion, Guid> repoHabitacion, IDetailRepository<ReservaDetalles, Guid> repoReservaDetalles)
        {
            this.repoReserva = repoReserva;
            this.repoHabitacion = repoHabitacion;
            this.repoReservaDetalles = repoReservaDetalles;
        }

        public void Cancel(Guid entityId)
        {
           repoReserva.Cancel(entityId);
           repoReserva.saveAllChanges();
        }

        public Reserva_Habitacion Create(Reserva_Habitacion entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("La reserva es requerida");
            }

            var reservaAgregada = repoReserva.Create(entity);

            entity.ReservaDetalles.ForEach(detail =>
            {
                var seletedHabitacion = repoHabitacion.GetById(detail.id_habitacion);
                if(seletedHabitacion == null)
                {
                    throw new NullReferenceException("Usted esta intentando reservar una habitacion que no existe");
                }

                detail.renta_por_dia = seletedHabitacion.renta_por_dia;
                detail.costo_total = detail.renta_por_dia * detail.dias_reservados;

                entity.dias_reservados = detail.dias_reservados;

                entity.costo_total += detail.costo_total;
            });
            repoReserva.saveAllChanges();
            return entity;
        }

        public List<Reserva_Habitacion> GetAll()
        {
            return repoReserva.GetAll();
        }

        public Reserva_Habitacion GetById(Guid entityId)
        {
            return repoReserva.GetById(entityId);
        }
    }
}
