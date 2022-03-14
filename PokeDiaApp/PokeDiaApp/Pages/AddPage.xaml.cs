using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        private Pokemon pokemon;

        public AddPage()
        {
            InitializeComponent();
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {
            pokemon = new Pokemon();
            //pokemon.Name = Name.Text;
            //pokemon.Type1 = FirstType.Text;
            //pokemon.Type2 = SecondType.Text;
            //pokemon.Description = Description.Text;
            //pokemon.Height = Height.Text;
            //pokemon.Weight = Weight.Text;
        }
    }
}