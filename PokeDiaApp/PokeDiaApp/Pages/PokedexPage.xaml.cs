using System;
using System.Collections.ObjectModel;
using PokeDiaApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        public async void ShowDetails(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DetailsPage());
        }
    }
}