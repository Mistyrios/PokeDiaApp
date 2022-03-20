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
            pokemon.Team = Team.SelectedIndex;
            switch(Team.SelectedIndex){
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:

                    break;
                case 9:

                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                case 15:

                    break;
                case 16:

                    break;
                
            }
                
           
        }
    }
}