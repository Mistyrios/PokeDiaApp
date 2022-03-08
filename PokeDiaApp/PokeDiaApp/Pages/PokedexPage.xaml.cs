using System;
using System.Collections.ObjectModel;
using PokeDiaApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace PokeDiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokedexPage : ContentPage
    {

        public PokedexPage()
        {
            InitializeComponent();
            BindingContext = ListViewModel.Instance;
        }
 
        async void Selection(object sender, SelectionChangedEventArgs e)
        {
            Pokemon selectedPokemon = (e.CurrentSelection.FirstOrDefault() as Pokemon);
            if (selectedPokemon == null) {
                return;
            }
            (sender as CollectionView).SelectedItem = null;
            await Navigation.PushAsync(new DetailsPage(selectedPokemon));
        }
    }
}