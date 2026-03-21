using BibliotecaAPI.Enitities;
using BibliotecaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/valores")]
    public class ValoresController:ControllerBase
    {
        //Acoplamiento bajo
        private readonly IValoresRepositories valoresRepositories;
        private readonly ServicioTransient transient1;
        private readonly ServicioTransient transient2;
        private readonly ServicioScoped scoped1;
        private readonly ServicioScoped scoped2;
        private readonly ServicioSingleton singleton;

        public ValoresController(IValoresRepositories valoresRepositories, 
            ServicioTransient transient1, 
            ServicioTransient transient2,
            ServicioScoped scoped1,
            ServicioScoped scoped2,
            ServicioSingleton singleton)
        {
            this.valoresRepositories = valoresRepositories;
            this.transient1 = transient1;
            this.transient2 = transient2;
            this.scoped1 = scoped1;
            this.scoped2 = scoped2;
            this.singleton = singleton;
        }

        [HttpGet("servicios-tiempos-de-vida")]
        public IActionResult GetServicioTiemposdeVida()
        {
            return Ok(new
            {
                Transients = new
                {
                    transient1 = transient1.ObtenerGuid,
                    transient2 = transient2.ObtenerGuid,
                },
                //Son la misma instancia dentro de la misma petición
                Scoped = new {
                    scoped1 = scoped1.ObtenerGuid,
                    scoped2 = scoped2.ObtenerGuid,
                },
                singleton = singleton.ObtenerGuid
            });

        }

        [HttpGet]
        public IEnumerable<Valor> Get()
        {
            //Acoplamiento Fuerte
            //var valoresRepositories = new ValoresRepositories();
            return valoresRepositories.ObtenerValores();
        }

        [HttpPost]
        public IActionResult Post(Valor valor)
        {
            valoresRepositories.InsertarValor(valor);
            return Ok();
        }
    }
}
