using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class PokemonEdit
    {
        public int PokemonId { get; set; }
        [Required]
        public int PokedexNumber { get; set; }
        [Required]
        public string Species { get; set; }
        public int Level { get; set; }
        [Required]
        public string PrimaryType { get; set; }
        public string SecondaryType { get; set; }
        public string EvoCondition { get; set; }
        [Required]
        public string OriginalRegion { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsMythical { get; set; }
    }
}
