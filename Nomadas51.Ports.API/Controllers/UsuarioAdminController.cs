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
    public class UsuarioAdminController : ControllerBase
    {
        public UserAdminUseCase CreateService()
        {
            NomadasDB db = new NomadasDB();
            //Instanciando el contexto de la bases de datos
            UsuarioAdminRepository repository = new UsuarioAdminRepository(db);
            //Llamando al repositorio concreto y mandando como argumento el contexto
            UserAdminUseCase service = new UserAdminUseCase(repository);
            return service;
        }

        // GET: api/<UsuarioAdminController>
        [HttpGet]
        public ActionResult<IEnumerable<Usuario_Admin>> Get()
        {
            UserAdminUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioAdminController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario_Admin> Get(Guid id)
        {
            UserAdminUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioAdminController>
        [HttpPost]
        public ActionResult<Usuario_Admin> Post([FromBody] Usuario_Admin usuario_Admin)
        {
            UserAdminUseCase service = CreateService();

            var result = service.Create(usuario_Admin);

            return Ok(result);
        }

        // PUT api/<UsuarioAdminController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario_Admin usuario_Admin)
        {
            UserAdminUseCase service = CreateService();
            usuario_Admin.id_usuario_admin = id;
            service.Update(usuario_Admin);

            return Ok("Editado Exitosamente");
        }

        // DELETE api/<UsuarioAdminController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            UserAdminUseCase service = CreateService();
            service.Delete(id);

            return Ok("Eliminado Exitosamente");
        }
    }
}
