using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class PokemonCreate
    {
        [Required]
        [Range(1, 892)]
        [Display(Name = "Pokedex Number")]
        public int PokedexNumber { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(11, ErrorMessage = "You have entered too many characters.")]
        public string Species { get; set; }
        public int Level { get; set; }
        [Required]
        [Display(Name = "Primary Type")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(8, ErrorMessage = "You have entered too many characters.")]
        public string PrimaryType { get; set; }
        [Display(Name = "Secondary Type")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(8, ErrorMessage = "You have entered too many characters.")]
        public string SecondaryType { get; set; }
        [Display(Name = "Evolution Condition")]
        public string EvoCondition { get; set; }
        [Required]
        [Display(Name = "OriginalRegion")]
        [MinLength(5, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(6, ErrorMessage = "You have entered too many characters.")]
        public string OriginalRegion { get; set; }
        [Required]
        [Display(Name = "Legendary")]
        public bool IsLegendary { get; set; }
        [Required]
        [Display(Name = "Mythical")]
        public bool IsMythical { get; set; }
    }
}
