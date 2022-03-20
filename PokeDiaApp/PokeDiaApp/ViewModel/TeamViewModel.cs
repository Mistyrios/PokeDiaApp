using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PokeDiaApp.ViewModel
{
    public class TeamViewModel : BaseViewModel
    {
        private static TeamViewModel _instance = new TeamViewModel();
        public static TeamViewModel Instance { get { return _instance; } }
        public ObservableCollection<Pokemon> MyFavoriteList {
            get { return GetValue<ObservableCollection<Pokemon>>(); }
            set { SetValue(value); }
        }

        public TeamViewModel()
        {
            MyFavoriteList = new ObservableCollection<Pokemon>();
            InitTeam();
        }

        public async void InitTeam()
        {
            List<Pokemon> listOfPokemon = await App.FavoritePokemonRepo.GetAll();
            if (listOfPokemon.Count != 0) {
                foreach (Pokemon pokemon in listOfPokemon) {
                    if (pokemon.Team != 0) {
                        MyFavoriteList.Add(pokemon);
                    }
                }
            }
        }
    }
}
