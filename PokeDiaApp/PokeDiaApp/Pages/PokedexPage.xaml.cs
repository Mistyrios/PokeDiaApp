using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokedexPage : ContentPage
    {
       

        public PokedexPage()
        {
           
        }

        async void ShowDetails(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DetailsPage());
        }

    }
}