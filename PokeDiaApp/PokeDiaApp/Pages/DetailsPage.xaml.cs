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

        //This method allows you to add a pokemon to your team
        //She first checks if the team is full or not
        //If it's not the case, it retrieves the pokemon from the page
        //And add it to the team
        //If the team is full it sends back an error message
        private async void AddToTeamButtonClicked(object sender, EventArgs e)
        {
            if (TeamViewModel.Instance.MyFavoriteList.Count < 6) {
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
            else {
                await DisplayAlert("Error", "Your Team is Full !", "OK"); ;
            }
        }
      
    }
}