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

        //First take all the data that was entered about the pokemon and
        //Add the pokemon in the database when the add button is clicked
        //there is a verification about type because one pokemon can have 2 or only one type.
        //Finally redirect to an other add page
        private async void AddButtonClicked(object sender, EventArgs e)
        {
            if (Convert.ToDouble(HP.Text) > 255) {
                await DisplayAlert("Add", "The hp of pokemon can't be higher than 255", "OK");
            }
            else {
                if (Convert.ToDouble(Attack.Text) > 255) {
                    await DisplayAlert("Add", "The attack of pokemon can't be higher than 255", "OK");
                }
                else {
                     if (Convert.ToDouble(Defense.Text) > 255) {
                        await DisplayAlert("Add", "The defense of pokemon can't be higher than 255", "OK");
                    }
                    else {
                         if (Convert.ToDouble(SpecialAttack.Text) > 255) {
                            await DisplayAlert("Add", "The special attack of pokemon can't be higher than 255", "OK");
                        }
                         else {
                            if (Convert.ToDouble(SpecialDefense.Text) > 255) {
                                await DisplayAlert("Add", "The special defense of pokemon can't be higher than 255", "OK");
                            } 
                            else {
                                if (Convert.ToDouble(Speed.Text) > 255) {
                                    await DisplayAlert("Add", "The speed of pokemon can't be higher than 255", "OK");
                                }
                                else {
                                    Pokemon pokemon = new Pokemon();
                                    pokemon.Name = Name.Text;
                                    pokemon.Type1 = FirstType.SelectedItem.ToString();
                                    pokemon.colorType1 = ColorType.ColorDictionary[pokemon.Type1.ToLower()];
                                    pokemon.Description = Description.Text;
                                    pokemon.Height = Convert.ToDouble(Height.Text) / 10;
                                    pokemon.Weight = Convert.ToDouble(Weight.Text);
                                    pokemon.HP = Convert.ToDouble(HP.Text) / 255;
                                    pokemon.Attack = Convert.ToDouble(Attack.Text) / 255;
                                    pokemon.Defense = Convert.ToDouble(Defense.Text) / 255;
                                    pokemon.SpecialAttack = Convert.ToDouble(SpecialAttack.Text) / 255;
                                    pokemon.SpecialDefense = Convert.ToDouble(SpecialDefense.Text) / 255;
                                    pokemon.Speed = Convert.ToDouble(Speed.Text) / 255;
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
                                    int i = 0;
                                    foreach (var poke in pokemons_bd) {
                                        ListViewModel.Instance.MyList.Insert(0, poke);
                                    }

                                    await Navigation.PushAsync(new AddPage());
                                    await DisplayAlert("Add", App.PokemonRepo.MessageToShow, "OK");
                                }
                            }
                        }
                    }
                }
            }
           
           
           
           
            
        }

        //this four methods verify that we can acces to the photos of the phone
        //if we can the user can select the photo that he want and add it for the pokemon
        //then add the path of the picture to a fake label to be able to get the path everywhere
        private async void GetFrontDefault(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported) {
                await DisplayAlert("Error", "Your device does not support this feature!", "OK");
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
                await DisplayAlert("Error", "Your device does not support this feature!", "OK");
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
                await DisplayAlert("Error", "Your device does not support this feature!", "OK");
                ;
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
                await DisplayAlert("Error", "Your device does not support this feature!", "OK");
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