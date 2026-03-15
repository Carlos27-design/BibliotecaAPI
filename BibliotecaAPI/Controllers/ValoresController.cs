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

        public ValoresController(IValoresRepositories valoresRepositories)
        {
            this.valoresRepositories = valoresRepositories;
        }

        [HttpGet]
        public IEnumerable<Valor> Get()
        {
            //Acoplamiento Fuerte
            //var valoresRepositories = new ValoresRepositories();
            return valoresRepositories.ObtenerValores();
        }
    }
}
