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
    public class HabitacionController : ControllerBase
    {
        public HabitacionUseCase CreateService()
        {
            NomadasDB db = new NomadasDB();
            //Instanciando el contexto de la bases de datos
            HabitacionRepository repository = new HabitacionRepository(db);
            //Llamando al repositorio concreto y mandando como argumento el contexto
            HabitacionUseCase service = new HabitacionUseCase(repository);
            return service;
        }
        // GET: api/<HabitacionController>
        [HttpGet]
        public ActionResult<IEnumerable<Habitacion>> Get()
        {
            HabitacionUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<HabitacionController>/5
        [HttpGet("{id}")]
        public ActionResult<Habitacion> Get(Guid id)
        {
            HabitacionUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<HabitacionController>
        [HttpPost]
        public ActionResult<Habitacion> Post([FromBody] Habitacion habitacion)
        {
            HabitacionUseCase service = CreateService();

            var result = service.Create(habitacion);

            return Ok(result);
        }

        // PUT api/<HabitacionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Habitacion habitacion)
        {
            HabitacionUseCase service = CreateService();
            habitacion.id_habitacion = id;
            service.Update(habitacion);

            return Ok("Editado Exitosamente");
        }

        // DELETE api/<HabitacionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            HabitacionUseCase service = CreateService();
            service.Delete(id);

            return Ok("Eliminado Exitosamente");
        }
    }
}
