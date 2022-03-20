using System;
using System.IO;
using PokeDiaApp.Repository;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDiaApp
{
    public partial class App : Application
    {
        private string databasePath = Path.Combine(FileSystem.AppDataDirectory, "PokemonDB");
        private string FavoritedatabasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB");

        public static PokemonRepository PokemonRepo { get; private set; }
        public static PokemonRepository FavoritePokemonRepo { get; private set; }

        //initialise the connection to databases
        public App()
        {
            InitializeComponent();
            PokemonRepo = new PokemonRepository(databasePath);
            FavoritePokemonRepo = new PokemonRepository(FavoritedatabasePath);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
