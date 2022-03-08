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

        public DetailsPage(Pokemon pokemon)
        {
            InitializeComponent();
            BindingContext = pokemon;
        }
    }
}