using ExamenApp.Clases;
using ExamenApp.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ExamenApp.Controllers
{
    [RoutePrefix("api/Computadores")]
    public class ComputadoresController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Computador> ConsultarTodos()
        {
            clsComputador Computador = new clsComputador();
            return Computador.ConsultarTodos();
        }
        [HttpGet]
        [Route("Consultar")]
        public Computador Consultar(int ComputadorID)
        {
            clsComputador Computador = new clsComputador();
            return Computador.Consultar(ComputadorID);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Computador computador)
        {
            clsComputador Computador = new clsComputador();
            Computador.computador = computador;
            return Computador.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Computador computador)
        {
            clsComputador Computador = new clsComputador();
            Computador.computador = computador;
            return Computador.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Computador computador)
        {
            clsComputador Computador = new clsComputador();
            Computador.computador = computador;
            return Computador.Eliminar();
        }
    }
}