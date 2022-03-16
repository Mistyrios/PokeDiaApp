using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using PokeDiaApp.Models;
using PokeDiaApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {

        public AddPage()
        {
            InitializeComponent();
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            Pokemon pokemon = new Pokemon();
            pokemon.Name = Name.Text;
            pokemon.Type1 = FirstType.SelectedItem.ToString();
            pokemon.colorType1 = ColorType.ColorDictionary[pokemon.Type1.ToLower()];
            pokemon.Description = Description.Text;
            pokemon.Height = Convert.ToDouble(Height.Text) / 10;
            pokemon.Weight = Convert.ToDouble(Weight.Text);
            pokemon.HP = Convert.ToDouble(HP.Text) / 100;
            pokemon.Attack = Convert.ToDouble(Attack.Text) / 100;
            pokemon.Defense = Convert.ToDouble(Defense.Text) / 100;
            pokemon.SpecialAttack = Convert.ToDouble(SpecialAttack.Text) / 100;
            pokemon.SpecialDefense = Convert.ToDouble(SpecialDefense.Text) / 100;
            pokemon.Speed = Convert.ToDouble(Speed.Text) / 100;
            pokemon.UrlFront = FrontDefault.Text;
            pokemon.UrlBack = BackDefault.Text;
            pokemon.UrlShinyFront = FrontShiny.Text;
            pokemon.UrlShinyBack = BackShiny.Text;
            if (SecondType.SelectedItem != null) {
                pokemon.Type2 = SecondType.SelectedItem.ToString();
                pokemon.Type2IsVisible = true;
                pokemon.colorType2 = ColorType.ColorDictionary[pokemon.Type2.ToLower()];
            }

            await App.PokemonRepo.AddPokemon(pokemon);
            List<Pokemon> pokemons_bd = await App.PokemonRepo.GetAll();
            ListViewModel.Instance.MyList.Clear();
            foreach (var poke in pokemons_bd) {
                ListViewModel.Instance.MyList.Add(poke);
            }
            await Navigation.PushAsync(new AddPage());
            await DisplayAlert("Ajout", App.PokemonRepo.MessageToShow, "OK");

        }
        private async void GetFrontDefault(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported) {
                await DisplayAlert("Impossible", "Votre appareil ne prend pas en charge cette fonctionnalité!", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            imageFrontDefault.Source = ImageSource.FromStream(() => file.GetStream());
            FrontDefault.Text = file.Path;
        }
        private async void GetBackDefault(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported) {
                await DisplayAlert("Impossible", "Votre appareil ne prend pas en charge cette fonctionnalité!", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            imageBackDefault.Source = ImageSource.FromStream(() => file.GetStream());
            BackDefault.Text = file.Path;
        }
        private async void GetFrontShiny(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported) {
                await DisplayAlert("Impossible", "Votre appareil ne prend pas en charge cette fonctionnalité!", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            imageFrontShiny.Source = ImageSource.FromStream(() => file.GetStream());
            FrontShiny.Text = file.Path;
        }
        private async void GetBackShiny(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported) {
                await DisplayAlert("Impossible", "Votre appareil ne prend pas en charge cette fonctionnalité!", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            imageBackShiny.Source = ImageSource.FromStream(() => file.GetStream());
            BackShiny.Text = file.Path;
        }
    }
}