using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace PokeDiaApp
{
    public class Pokemon
    {
        public String Name { get; set; }

        public String Url { get; set; }

        public String Type1 { get; set; }

        public String Type2 { get; set; }

        public String Number { get; set; }

        public String UrlShiny { get; set; }

        public Boolean Type2IsVisible { get; set; }

        public String colorType1 { get; set; }

        public String colorType2 { get; set; }

        public String Description { get; set; }

        public String Height { get; set; }
        
        public String Weight { get; set; }
        public double HP { get; set; }
        public double Attack { get; set; }
        public double Defense   { get; set; }
        public double SpecialDefense { get; set; }
        public double SpecialAttack { get; set; }
        public double Speed { get; set; }
    }
}
