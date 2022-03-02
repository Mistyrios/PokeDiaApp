using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PokeApiNet;

namespace PokeDiaApp.ViewModel
{
    internal class ListViewModel : BaseViewModel
    {
        private static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance { get { return _instance; } }

        public ObservableCollection<Pokemon> MyList {
                    get { return GetValue<ObservableCollection<Pokemon>>();}
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
                mypokemon.Number = pokemon.Id;
                mypokemon.Url = pokemon.Sprites.FrontDefault;
                mypokemon.Type1 = pokemon.Types[0].Type.Name;
                if (pokemon.Types.Count == 2) {
                    mypokemon.Type2 = pokemon.Types[1].Type.Name;
                }
                MyList.Add(mypokemon);
            }

        }
    }
}
