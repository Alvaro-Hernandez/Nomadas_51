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
    public class ReseñaNegocioController : ControllerBase
    {
        public ReseñaNegocioUseCase CreateService()
        {
            NomadasDB db = new NomadasDB();
            //Instancia al contexto de la base de datos
            ReseñaNegocioRepository repository = new ReseñaNegocioRepository(db);
            //Llamando al repositorio concrento y mandando como argumento al contexto
            ReseñaNegocioUseCase service = new ReseñaNegocioUseCase(repository);
            //Define el servicio y pasando como servicio el respositorio
            return service;
        }
        // GET: api/<ReseñaNegocioController>
        [HttpGet]
        public ActionResult<IEnumerable<Reseña_Negocio>> Get()
        {
            ReseñaNegocioUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<ReseñaNegocioController>/5
        [HttpGet("{id}")]
        public ActionResult<Reseña_Negocio> Get(Guid id)
        {
            ReseñaNegocioUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<ReseñaNegocioController>
        [HttpPost]
        public ActionResult<Reseña_Negocio> Post([FromBody] Reseña_Negocio reseña_Negocio)
        {
            ReseñaNegocioUseCase service = CreateService();
            var result = service.Create(reseña_Negocio);

            return Ok(result);
        }

        // PUT api/<ReseñaNegocioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Reseña_Negocio reseña_Negocio)
        {
            ReseñaNegocioUseCase service = CreateService();
            reseña_Negocio.id_reseña = id;

            service.Update(reseña_Negocio);

            return Ok("Reseña Editada Exitosamente");
        }

        // DELETE api/<ReseñaNegocioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ReseñaNegocioUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}
