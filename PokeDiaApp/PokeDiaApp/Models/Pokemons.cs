using System;
using System.Collections.Generic;
using System.Text;

namespace PokeDiaApp
{
    internal class Pokemons
    {
        private String name;
        public String Name { get { return name; } set { name = value; } }

        private String url1;
        public String Url1 { get { return url1; } set { url1 = value; } }

        private String url2;
        public String Url2 { get { return url2; } set { url2 = value; } }


        private String type1;
        public String Type1 { get { return type1; } set { type1 = value; } }

        private String type2;
        public String Type2 { get { return type2; } set { type2 = value; } }

        private int number;
        public int Number { get { return number; } set { number = value; } }

        private String description;
        public String Description { get { return description; } set { description = value; } }

        private String evolution;
        public String Evolution { get { return evolution; } set { evolution = value; } }

        private String initial;
        public String InitialForm { get { return initial; } set { initial = value; } }

    }
}
