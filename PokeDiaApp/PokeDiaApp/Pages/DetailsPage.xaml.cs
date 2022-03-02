using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        
        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = this;

            Pokemons pokemonDeTest = new Pokemons() {
                Description = "test de description",
                Evolution = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/394.png",
                InitialForm = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/393.png",
                Name = "Piplup", Number = 393, Type1 = "Water", Type2 = "fire",
                Url1 = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/393.png",
                Url2 = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/394.png"
            };
    }
    }
}