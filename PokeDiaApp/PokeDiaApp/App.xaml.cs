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
        private string Favorite2databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB2");
        private string Favorite3databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB3");
        private string Favorite4databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB4");
        private string Favorite5databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB5");
        private string Favorite6databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB6");
        private string Favorite7databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB7");
        private string Favorite8databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB8");
        private string Favorite9databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB9");
        private string Favorite10databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB10");
        private string Favorite11databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB11");
        private string Favorite12databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB12");
        private string Favorite13databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB13");
        private string Favorite14databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB14");
        private string Favorite15databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB15");
        private string Favorite16databasePath = Path.Combine(FileSystem.AppDataDirectory, "FavoritePokemonDB16");
        public static PokemonRepository PokemonRepo { get; private set; }
        public static PokemonRepository FavoritePokemonRepo { get; private set; }
        public static PokemonRepository Favorite2PokemonRepo { get; private set; }
        public static PokemonRepository Favorite3PokemonRepo { get; private set; }
        public static PokemonRepository Favorite4PokemonRepo { get; private set; }
        public static PokemonRepository Favorite5PokemonRepo { get; private set; }
        public static PokemonRepository Favorite6PokemonRepo { get; private set; }
        public static PokemonRepository Favorite7PokemonRepo { get; private set; }
        public static PokemonRepository Favorite8PokemonRepo { get; private set; }
        public static PokemonRepository Favorite9PokemonRepo { get; private set; }
        public static PokemonRepository Favorite10PokemonRepo { get; private set; }
        public static PokemonRepository Favorite11PokemonRepo { get; private set; }
        public static PokemonRepository Favorite12PokemonRepo { get; private set; }
        public static PokemonRepository Favorite13PokemonRepo { get; private set; }
        public static PokemonRepository Favorite14PokemonRepo { get; private set; }
        public static PokemonRepository Favorite15PokemonRepo { get; private set; }
        public static PokemonRepository Favorite16PokemonRepo { get; private set; }

        //initialise the connection to databases
        public App()
        {
            InitializeComponent();
            PokemonRepo = new PokemonRepository(databasePath);
            FavoritePokemonRepo = new PokemonRepository(FavoritedatabasePath);
            Favorite2PokemonRepo = new PokemonRepository(Favorite2databasePath);
            Favorite3PokemonRepo = new PokemonRepository(Favorite3databasePath);
            Favorite4PokemonRepo = new PokemonRepository(Favorite4databasePath);
            Favorite5PokemonRepo = new PokemonRepository(Favorite5databasePath);
            Favorite6PokemonRepo = new PokemonRepository(Favorite6databasePath);
            Favorite7PokemonRepo = new PokemonRepository(Favorite7databasePath);
            Favorite8PokemonRepo = new PokemonRepository(Favorite8databasePath);
            Favorite9PokemonRepo = new PokemonRepository(Favorite9databasePath);
            Favorite10PokemonRepo = new PokemonRepository(Favorite10databasePath);
            Favorite11PokemonRepo = new PokemonRepository(Favorite11databasePath);
            Favorite12PokemonRepo = new PokemonRepository(Favorite12databasePath);
            Favorite13PokemonRepo = new PokemonRepository(Favorite13databasePath);
            Favorite14PokemonRepo = new PokemonRepository(Favorite14databasePath);
            Favorite15PokemonRepo = new PokemonRepository(Favorite15databasePath);
            Favorite16PokemonRepo = new PokemonRepository(Favorite16databasePath);
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
