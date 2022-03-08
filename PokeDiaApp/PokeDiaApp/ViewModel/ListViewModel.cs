using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PokeApiNet;
using PokeDiaApp.Models;

namespace PokeDiaApp.ViewModel
{
    internal class ListViewModel : BaseViewModel
    {
        private static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance { get { return _instance; } }

        public ObservableCollection<Pokemon> MyList {
            get { return GetValue<ObservableCollection<Pokemon>>(); }
            set { SetValue(value); }
        }

        public ListViewModel()
        {
            MyList = new ObservableCollection<Pokemon>();

            InitList();
        }

        public async void InitList()
        {
            PokeApiClient pokeClient = new PokeApiClient();

            for (int i = 1; i <= 50; i++) {
                PokeApiNet.Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(i));
                Pokemon mypokemon = new Pokemon();
                mypokemon.Name = pokemon.Name;
                char[] nameLetters = mypokemon.Name.ToCharArray();
                nameLetters[0] = char.ToUpper(nameLetters[0]);
                mypokemon.Name = new string(nameLetters);
                mypokemon.Number = "No. " + pokemon.Id;
                mypokemon.Url = pokemon.Sprites.FrontDefault;
                mypokemon.Type1 = pokemon.Types[0].Type.Name;
                mypokemon.couleurType1 = CouleurType.ColorDictionary[mypokemon.Type1.ToLower()];
                char[] type1letters = mypokemon.Type1.ToCharArray();
                type1letters[0] = char.ToUpper(type1letters[0]);
                mypokemon.Type1 = new string(type1letters);
                if (pokemon.Types.Count == 2) {
                    mypokemon.Type2 = pokemon.Types[1].Type.Name;
                    char[] type2letters = mypokemon.Type2.ToCharArray();
                    type2letters[0] = char.ToUpper(type2letters[0]);
                    mypokemon.Type2 = new string(type2letters);
                    mypokemon.Type2IsVisible = true;
                    mypokemon.couleurType2 = CouleurType.ColorDictionary[mypokemon.Type2.ToLower()];
                }

                mypokemon.UrlShiny = pokemon.Sprites.FrontShiny;
                mypokemon.Species = pokemon.Weight.ToString();
                MyList.Add(mypokemon);
            }
        }
    }
}