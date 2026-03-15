using BibliotecaAPI.Enitities;

namespace BibliotecaAPI.Repositories
{
    public interface IValoresRepositories
    {
        IEnumerable<Valor> ObtenerValores();
    }
}
