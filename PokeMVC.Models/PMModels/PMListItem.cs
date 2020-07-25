using PokeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class PMListItem
    {
        [Display(Name = "Pokemon Id")]
        public int PMId { get; set; }
        [Display(Name = "Pokedex Number")]
        public int PMPokedexNumber { get; set; }
        public string Species { get; set; }
        [Display(Name = "Level")]
        public int PMLevel { get; set; }
        [Display(Name = "Primary Type")]
        public string PrimaryType { get; set; }
        [Display(Name = "Secondary Type")]
        public string SecondaryType { get; set; }
        public virtual ICollection<Move> Moves { get; set; }
    }
}
