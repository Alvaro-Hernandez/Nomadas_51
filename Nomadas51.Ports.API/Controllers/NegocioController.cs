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
    public class NegocioController : ControllerBase
    {
        public NegocioUseCase CreateService()
        {
            NomadasDB db = new NomadasDB();
            //Instanciando el contexto de la bases de datos
            NegocioRepository repository = new NegocioRepository(db);
            //Llamando al repositorio concreto y mandando como argumento el contexto
            NegocioUseCase service = new NegocioUseCase(repository);
            return service;
        }

        // GET: api/<NegocioController>
        [HttpGet]
        public ActionResult<IEnumerable<Negocio>> Get()
        {
            NegocioUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<NegocioController>/5
        [HttpGet("{id}")]
        public ActionResult<Negocio> Get(Guid id)
        {
            NegocioUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<NegocioController>
        [HttpPost]
        public ActionResult<Negocio> Post([FromBody] Negocio negocio)
        {
            NegocioUseCase service = CreateService();

            var result = service.Create(negocio);

            return Ok(result);
        }

        // PUT api/<NegocioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Negocio negocio)
        {
            NegocioUseCase service = CreateService();
            negocio.id_negocio = id;
            service.Update(negocio);

            return Ok("Editado Exitosamente");
        }

        // DELETE api/<NegocioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            NegocioUseCase service = CreateService();
            service.Delete(id);

            return Ok("Eliminado Exitosamente");
        }
    }
}
