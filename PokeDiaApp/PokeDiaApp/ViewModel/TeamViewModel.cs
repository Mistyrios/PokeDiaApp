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

        //This method initializes the team by retrieving all the pokemons and storing them in a list
        //If the list is empty we do nothing
        //So for each pokemon we add it in our team
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
