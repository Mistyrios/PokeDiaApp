using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using PokeDiaApp.Models;
using PokeDiaApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private const Int32 TEAM = 1;
        private Pokemon myPokemon;
        public DetailsPage(Pokemon pokemon)
        {
            myPokemon = pokemon;
            InitializeComponent();
            BindingContext = pokemon;
        }

        private async void AddToTeamButtonClicked(object sender, EventArgs e)
        {
            Pokemon pokemon = new Pokemon();
            pokemon = myPokemon;
            pokemon.Team = TEAM;
            await App.FavoritePokemonRepo.AddPokemon(pokemon);
            List<Pokemon> favoritePokemons_bd = await App.FavoritePokemonRepo.GetAll();
            TeamViewModel.Instance.MyFavoriteList.Clear();
            foreach (var poke in favoritePokemons_bd) {
                TeamViewModel.Instance.MyFavoriteList.Add(poke);
            }
            await DisplayAlert("Add", App.FavoritePokemonRepo.MessageToShow, "OK");
        }
      
    }
}