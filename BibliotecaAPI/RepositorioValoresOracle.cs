using BibliotecaAPI.Enitities;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI
{
    public class RepositorioValoresOracle: IValoresRepositories
    {

        private List<Valor> _valores;

        public RepositorioValoresOracle() 
        {
            _valores = new List<Valor>
            {
                new Valor{Id=3, Name="Valor Oracle 1"},
                new Valor{Id=4, Name="Valor Oracle 2"},
                new Valor{Id=5, Name="Valor Oracle 3"}
            };
        }

        public IEnumerable<Valor> ObtenerValores() 
        {
            return _valores;
        }

        public void InsertarValor(Valor valor)
        {
            _valores.Add(valor);
        }
    }
}
