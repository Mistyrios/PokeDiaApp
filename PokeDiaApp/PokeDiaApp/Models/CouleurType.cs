using System;
using System.Collections.Generic;
using System.Text;

namespace PokeDiaApp.Models
{
    public class CouleurType
    {
        public static readonly Dictionary<string, string> ColorDictionary = new Dictionary<string, string>
        {
            {"rock", "#b6a670" },
            {"ghost", "#7079b8"},
            {"steel", "#acadbb"},
            {"water", "#4d9ae7"},
            {"grass", "#7ab15e"},
            {"psychic", "#e873a2"},
            {"ice", "#7bc9e8"},
            {"dark", "#8b6b56"},
            {"fairy", "#dba6d7"},
            {"normal", "#a9aba0"},
            {"fighting", "#ab6954"},
            {"flying", "#6c96e5"},
            {"poison", "#a66c94"},
            {"ground", "#d1b266"},
            {"bug", "#afb14e"},
            {"fire", "#e6624f"},
            {"electric", "#ecc35d"},
            {"dragon", "#817bdf"}
        };
    }
}
