using Microsoft.AspNetCore.Mvc;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;
using Nomadas51.Core.Application.UseCases;
using Nomadas51.Core.Infraestructure.Repository.Concrete;
using System.Collections.Generic;
using System;
using Nomadas51.Core.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nomadas51.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioClienteController : ControllerBase
    {
        public UserClteUseCase CreateService()
        {
            NomadasDB db = new NomadasDB();
            //Instanciando el contexto de la bases de datos
            UsuarioClienteRepository repository = new UsuarioClienteRepository(db);
            //Llamando al repositorio concreto y mandando como argumento el contexto
            UserClteUseCase service = new UserClteUseCase(repository);
            return service;
        }

        //GET-SIN ARGUMENTOS
        // GET: api/<UsuarioClienteController>
        [HttpGet]
        public ActionResult<IEnumerable<Usuario_Cliente>> Get()
        {
            UserClteUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        //GET-CON ARGUMENTOS
        // GET api/<UsuarioClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario_Cliente> Get(Guid id)
        {
            UserClteUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioClienteController>
        [HttpPost]
        public ActionResult<Usuario_Cliente> Post([FromBody] Usuario_Cliente usuario_Cliente)
        {
            UserClteUseCase service = CreateService();

            var result = service.Create(usuario_Cliente);

            return Ok(result);
        }

        // PUT api/<UsuarioClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario_Cliente usuario_Cliente)
        {
            UserClteUseCase service = CreateService();
            usuario_Cliente.id_usuario_cliente = id;
            service.Update(usuario_Cliente);

            return Ok("Editado Exitosamente");
        }

        // DELETE api/<UsuarioClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            UserClteUseCase service = CreateService();
            service.Delete(id);

            return Ok("Eliminado Exitosamente");
        }
    }
}
