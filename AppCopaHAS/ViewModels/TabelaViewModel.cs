using AppCopaHAS.Services;
using AppCopaHAS.Models.DTOs; // Adicionado para reconhecer o JogoDTO
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks; // Adicionado para reconhecer o Task
using Microsoft.Maui.Controls; // Adicionado para o Application.Current funcionar

namespace AppCopaHAS.ViewModels
{
    public class TabelaViewModel : BaseViewModel
    {
        JogoService _jogoService;

        public ObservableCollection<JogoDTO> Jogos { get; set; }

        public TabelaViewModel()
        {
            _jogoService = new JogoService();
            Jogos = new ObservableCollection<JogoDTO>();

            _ = ObterJogos();
        }

        public async Task ObterJogos()
        {
            try
            {
                Jogos = await _jogoService.GetJogosDTOAsync();
                OnPropertyChanged(nameof(Jogos));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlertAsync("Ops", ex.Message, "Detalhes" + ex.InnerException, "Ok");
            }
        }
    }
}