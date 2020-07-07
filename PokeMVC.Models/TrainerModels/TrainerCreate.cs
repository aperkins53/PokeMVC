using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class TrainerCreate
    {
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
    }
}
