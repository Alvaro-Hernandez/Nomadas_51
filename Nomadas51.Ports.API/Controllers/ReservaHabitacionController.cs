using Microsoft.AspNetCore.Mvc;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;
using Nomadas51.Core.Application.UseCases;
using Nomadas51.Core.Infraestructure.Repository.Concrete;
using Nomadas51.Core.Domain.Models;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nomadas51.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaHabitacionController : ControllerBase
    {
        public ReservaHabitacionUseCase CreateService()
        {
            NomadasDB db = new NomadasDB();
            //Instancia al contexto de la base de datos
            ReservaHabitacionRepository repoReserva = new ReservaHabitacionRepository(db);
            HabitacionRepository repoHabitacion = new HabitacionRepository(db);
            ReservaDetallesRepository repoDetalle = new ReservaDetallesRepository(db);
            //Llamando al repositorio concreto y mandando como argumento al contexto
            ReservaHabitacionUseCase service = new ReservaHabitacionUseCase(repoReserva, repoHabitacion, repoDetalle);
            //Define el servicio y pasando como servicio el respositorio
            return service;
        }
        // GET: api/<ReservaHabitacionController>
        [HttpGet]
        public ActionResult<IEnumerable<Reserva_Habitacion>> Get()
        {
            ReservaHabitacionUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<ReservaHabitacionController>/5
        [HttpGet("{id}")]
        public ActionResult<Reserva_Habitacion> Get(Guid id)
        {
            ReservaHabitacionUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<ReservaHabitacionController>
        [HttpPost]
        public ActionResult Post([FromBody] Reserva_Habitacion reserva_Habitacion)
        {
            ReservaHabitacionUseCase service = CreateService();

            service.Create(reserva_Habitacion);

            return Ok("Venta Agregada Correctamente");
        }

        // DELETE api/<ReservaHabitacionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ReservaHabitacionUseCase service = CreateService();
            
            service.Cancel(id);

            return Ok("Reserva Eliminada Exitosamente");
        }
    }
}
