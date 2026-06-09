using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AppCopaHAS.Models;
using AppCopaHAS.Models.DTOs; // Ajuste para o namespace exato dos seus Models

namespace AppCopaHAS.Services
{
    public class JogoService : Request
    {
        private readonly Request _request;
        // Rota base alterada para terminar com 'Selecoes' conforme instrução da página 4
        private const string _apiUrlBase = "https://copaapi3ai.azurewebsites.net/Selecoes";

        public JogoService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<JogoDTO>> GetSelecoesAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<JogoDTO> lista = await _request.GetAsync<ObservableCollection<JogoDTO>>(_apiUrlBase + urlComplementar, string.Empty);
            return lista;
        }

        public async Task<Jogo> PostJogoAsync(Jogo j)
        {
            Jogo jogoInserido = await _request.PostAsync<Jogo>(_apiUrlBase, j, string.Empty);
            return jogoInserido;
        }
    }
}