using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Data
{
    public class Trainer
    {
        [Key]
        [Display(Name = "Trainer ID")]
        public int TrainerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Gym Leader")]
        public bool IsGymLeader { get; set; }
        [Required]
        [Display(Name = "Elite Four")]
        public bool IsEliteFour { get; set; }
        [Required]
        [Display(Name = "Champion")]
        public bool IsChampion { get; set; }

        public virtual ICollection<Pokemon> TrainerPokemon { get; set; }
    }
}
