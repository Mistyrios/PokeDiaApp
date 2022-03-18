using System.Collections.Generic;
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
            PokeApiClient pokeClientPokemon = new PokeApiClient();

            List<Pokemon> listOfPokemon = await App.PokemonRepo.GetAll();
            if (listOfPokemon.Count != 0) {
                foreach (Pokemon pokemon in listOfPokemon) {
                    MyList.Add(pokemon);
                }
            }
            else {
                for (int i = 1; i <= 50; i++) {
                    PokeApiNet.Pokemon pokemon =
                        await Task.Run(() => pokeClientPokemon.GetResourceAsync<PokeApiNet.Pokemon>(i));
                    Pokemon mypokemon = new Pokemon();

                    mypokemon.Name = pokemon.Name;
                    char[] nameLetters = mypokemon.Name.ToCharArray();
                    nameLetters[0] = char.ToUpper(nameLetters[0]);
                    mypokemon.Name = new string(nameLetters);

                    mypokemon.Number = pokemon.Id;

                    mypokemon.UrlFront = pokemon.Sprites.FrontDefault;
                    mypokemon.UrlBack = pokemon.Sprites.BackDefault;
                    mypokemon.UrlShinyFront = pokemon.Sprites.FrontShiny;
                    mypokemon.UrlShinyBack = pokemon.Sprites.BackShiny;

                    mypokemon.Type1 = pokemon.Types[0].Type.Name;
                    mypokemon.colorType1 = ColorType.ColorDictionary[mypokemon.Type1.ToLower()];
                    char[] type1letters = mypokemon.Type1.ToCharArray();
                    type1letters[0] = char.ToUpper(type1letters[0]);
                    mypokemon.Type1 = new string(type1letters);
                    if (pokemon.Types.Count == 2) {
                        mypokemon.Type2 = pokemon.Types[1].Type.Name;
                        char[] type2letters = mypokemon.Type2.ToCharArray();
                        type2letters[0] = char.ToUpper(type2letters[0]);
                        mypokemon.Type2 = new string(type2letters);
                        mypokemon.Type2IsVisible = true;
                        mypokemon.colorType2 = ColorType.ColorDictionary[mypokemon.Type2.ToLower()];
                    }

                    if (i < 31) {
                        PokeApiNet.Characteristic characteristic = await Task.Run(() =>
                            pokeClientPokemon.GetResourceAsync<PokeApiNet.Characteristic>(i));
                        mypokemon.Description = characteristic.Descriptions[7].Description;
                    }
                    else {
                        mypokemon.Description = "No description for this Pokemon";
                    }

                    mypokemon.Height = (double)pokemon.Height / 10;
                    mypokemon.Weight = (double)pokemon.Weight / 10;

                    mypokemon.HP = (double) pokemon.Stats[0].BaseStat / 255;
                    mypokemon.Attack = (double) pokemon.Stats[1].BaseStat / 255;
                    mypokemon.Defense = (double) pokemon.Stats[2].BaseStat / 255;
                    mypokemon.SpecialAttack = (double) pokemon.Stats[3].BaseStat / 255;
                    mypokemon.SpecialDefense = (double) pokemon.Stats[4].BaseStat / 255;
                    mypokemon.Speed = (double) pokemon.Stats[5].BaseStat / 255;
                    await App.PokemonRepo.AddPokemon(mypokemon);
                    if (i <= 50) {
                        MyList.Add(mypokemon);
                    }
                    else {
                        MyList.Insert(0,mypokemon);
                    }
                }
            }
        }
    }
}