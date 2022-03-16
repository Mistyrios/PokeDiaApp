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
                MessageToShow = $"votre pokémon a bien été ajouté";
            }
            catch (Exception exception) {
                MessageToShow = $"votre pokémon n'a pas été ajouté veuillez réessayer \n [Erreur] : {exception.Message}";
            }
        }

        public async Task<List<Pokemon>> GetAll()
        {
            try {
                return await connection.Table<Pokemon>().ToListAsync();
            }
            catch (Exception ex) {
                MessageToShow = $"[ERREUR] :  {ex.Message}";
            }

            return new List<Pokemon>();
        }
    }
}