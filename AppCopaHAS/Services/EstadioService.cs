using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AppCopaHAS.Models; // Ajuste para o namespace exato dos seus Models

namespace AppCopaHAS.Services
{
    public class EstadioService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://copaapi3ai.azurewebsites.net/Estadios";

        public EstadioService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<Estadio>> GetEstadiosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Estadio> lista = await _request.GetAsync<ObservableCollection<Estadio>>(_apiUrlBase + urlComplementar, string.Empty);
            return lista;
        }
    }
}