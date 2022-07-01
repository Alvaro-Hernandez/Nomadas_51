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

    public class HabitacionImagenesController : ControllerBase
    {
        public HabitacionImagenesUseCase CreateService()
        {
            NomadasDB db = new NomadasDB();
            //Instancia al contexto de la base de datos
            HabitacionImagenesRepository repository = new HabitacionImagenesRepository(db);
            //Llamando al repositorio concrento y mandando como argumento al contexto
            HabitacionImagenesUseCase service = new HabitacionImagenesUseCase(repository);
            return service;
        }
        // GET: api/<HabitacionImagenesController>
        [HttpGet]
        public ActionResult<IEnumerable<Habitacion_Imagenes>> Get()
        {
            HabitacionImagenesUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<HabitacionImagenesController>/5
        [HttpGet("{id}")]
        public ActionResult<Habitacion_Imagenes> Get(Guid id)
        {
            HabitacionImagenesUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<HabitacionImagenesController>
        [HttpPost]
        public ActionResult<Habitacion_Imagenes> Post([FromBody] Habitacion_Imagenes habitacion_Imagenes)
        {
            HabitacionImagenesUseCase service = CreateService();
            var result = service.Create(habitacion_Imagenes);

            return Ok(result);
        }

        // PUT api/<HabitacionImagenesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Habitacion_Imagenes habitacion_Imagenes)
        {
            HabitacionImagenesUseCase service = CreateService();
            habitacion_Imagenes.id_imagen = id;

            service.Update(habitacion_Imagenes);

            return Ok("Imagenes Editadas Exitosamente");
        }

        // DELETE api/<HabitacionImagenesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            HabitacionImagenesUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Correctamente");
        }
    }
}
