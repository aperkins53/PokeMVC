using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class PokemonDetail
    {
        public int PokemonId { get; set; }
        public int PokedexNumber { get; set; }
        public string Species { get; set; }
        public string PrimaryType { get; set; }
        public string SecondaryType { get; set; }
        public string EvoCondition { get; set; }
        public string OriginalRegion { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsMythical { get; set; }
    }
}
