using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokedexPage : ContentPage
    {
        private ObservableCollection<Pokemons> myList;

        private ObservableCollection<Pokemons> MyList
        {
            get { return myList; }
            set { myList = value; }
        }

        public PokedexPage()
        {
            InitializeComponent();
            BindingContext = this;

            MyList = new ObservableCollection<Pokemons>();

            for (int i = 1; i < 10; i++)
            {
                MyList.Add(new Pokemons() { Number = i, Name = "piplup" + i.ToString(), Type1 = "water" + i.ToString(), Type2 = "fire" + i.ToString(),Url1 = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/393.png" });
            }

            pokemonsList.ItemsSource = MyList;
        }

        async void ShowDetails(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DetailsPage());
        }

    }
}