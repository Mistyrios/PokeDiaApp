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

        public static PokemonRepository PokemonRepo { get; private set; }
        public App()
        {
            InitializeComponent();
            PokemonRepo = new PokemonRepository(databasePath);
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
