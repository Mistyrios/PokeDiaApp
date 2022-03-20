using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;


namespace PokeDiaApp
{
    [Table("PokemonDB")]
    public class Pokemon
    {
        [Unique, NotNull]
        public String Name { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Number { get; set; }
        public String UrlFront { get; set; }
        public String UrlBack { get; set; }
        public String UrlShinyFront { get; set; }
        public String UrlShinyBack { get; set; }
        public String Type1 { get; set; }
        public String Type2 { get; set; }
        public Boolean Type2IsVisible { get; set; }
        public String colorType1 { get; set; }
        public String colorType2 { get; set; }
        public String Description { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double HP { get; set; }
        public double Attack { get; set; }
        public double Defense   { get; set; }
        public double SpecialDefense { get; set; }
        public double SpecialAttack { get; set; }
        public double Speed { get; set; }
        public double Team { get; set; }
    }
}
