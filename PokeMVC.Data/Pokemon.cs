using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Data
{
    public class Pokemon
    {
        [Key]
        [Display(Name = "Pokemon ID")]
        public int PokemonId { get; set; }
        [Required]
        [Display(Name = "Pokedex Number")]
        public int PokedexNumber { get; set; }
        [Required]
        public string Species { get; set; }
        public int Level { get; set; }
        [Required]
        [Display(Name = "Primary Type")]
        public string PrimaryType { get; set; }
        [Display(Name = "Secondary Type")]
        public string SecondaryType { get; set; }
        [Display(Name = "Evolution Condition")]
        public string EvoCondition { get; set; }
        [Required]
        [Display(Name = "Original Region")]
        public string OriginalRegion { get; set; }
        [Required]
        [Display(Name = "Legendary")]
        public bool IsLegendary { get; set; }
        [Required]
        [Display(Name = "Mythical")]
        public bool IsMythical { get; set; }

        public virtual ICollection<PokemonMove> Moves { get; set; }
    }
}
