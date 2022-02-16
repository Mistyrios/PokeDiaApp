using System.Collections.ObjectModel;

namespace PokeDiaApp.ViewModel
{
    internal class ListeViewModel : BaseViewModel
    {
        private static ListeViewModel _instance = new ListeViewModel();
        public static ListeViewModel Instance { get { return _instance; } }

        public ObservableCollection<Pokemons> MyList {
                    get { return myList; }
                    set { myList = value; }
        }
 
        private ObservableCollection<Pokemons> myList;

        public ListeViewModel()
        {
             MyList = new ObservableCollection<Pokemons>();

                    for (int i = 1; i< 10; i++)
                    {
                        MyList.Add(new Pokemons() { Number = i, Name = "piplup" + i.ToString(), Type1 = "water" + i.ToString(), Type2 = "fire" + i.ToString(),Url1 = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/393.png" });
                    }

                    pokemonsList.ItemsSource = MyList;
        }

       
    }
}
