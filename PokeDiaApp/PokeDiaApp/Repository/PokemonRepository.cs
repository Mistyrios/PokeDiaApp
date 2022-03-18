using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PokeDiaApp.Repository
{
    public class PokemonRepository
    {
        private SQLiteAsyncConnection connection;
        public String MessageToShow { get; private set; }

        public PokemonRepository(String DataBasePath)
        {
            connection = new SQLiteAsyncConnection(DataBasePath);
            connection.CreateTableAsync<Pokemon>();
        }

        public async Task AddPokemon(Pokemon PokemonToAdd)
        {
            int result = 0;
            try {
                result = await connection.InsertAsync(PokemonToAdd);
                MessageToShow = $"Your pokemon has been added !";
            }
            catch (Exception exception) {
                MessageToShow = $"Your pokemon has not been added please try again \n [Error] :  {exception.Message}";
            }
        }

        public async Task<List<Pokemon>> GetAll()
        {
            try {
                return await connection.Table<Pokemon>().ToListAsync();
            }
            catch (Exception exception) {
                MessageToShow = $"Unable to display the list please try again \n [Error] :  {exception.Message}";
            }

            return new List<Pokemon>();
        }
    }
}