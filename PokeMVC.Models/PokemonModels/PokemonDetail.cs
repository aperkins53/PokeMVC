using PokeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class PokemonDetail
    {
        [Display(Name = "Pokemon ID")]
        public int PokemonId { get; set; }
        [Display(Name = "Pokedex Number")]
        public int PokedexNumber { get; set; }
        public string Species { get; set; }
        public int Level { get; set; }
        [Display(Name = "Primary Type")]
        public string PrimaryType { get; set; }
        [Display(Name = "Secondary Type")]
        public string SecondaryType { get; set; }
        [Display(Name = "Evolution Condition")]
        public string EvoCondition { get; set; }
        [Display(Name = "Original Region")]
        public string OriginalRegion { get; set; }
        [Display(Name = "Legendary")]
        public bool IsLegendary { get; set; }
        [Display(Name = "Mythical")]
        public bool IsMythical { get; set; }

        [ForeignKey("PokemonMove")]
        public int MoveId { get; set; }
        public virtual PokemonMove Move { get; set; }
        public List<MoveListItem> Moves { get; set; }
    }
}
