using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeDiaApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamPage : ContentPage
    {
        public TeamPage()
        {
            InitializeComponent();
            BindingContext = TeamViewModel.Instance;
        }

        //This method allows you to empty your team after pressing the button in order to modify or reset it
        public void ClearAfterClick(object sender, EventArgs e)
        {
            App.FavoritePokemonRepo.Clear();
            TeamViewModel.Instance.MyFavoriteList.Clear();
        }
    }
}