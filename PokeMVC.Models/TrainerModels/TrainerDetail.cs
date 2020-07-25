using PokeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class TrainerDetail
    {
        [Display(Name = "Trainer ID")]
        public int TrainerId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Gym Leader")]
        public bool IsGymLeader { get; set; }
        [Display(Name = "Elite Four")]
        public bool IsEliteFour { get; set; }
        [Display(Name = "Champion")]
        public bool IsChampion { get; set; }


        [ForeignKey("Pokemon")]
        public int PokemonId { get; set; }
        public virtual Pokemon Pokemon { get; set; }
        public virtual ICollection<Pokemon> TrainerTeam { get; set; }
    }
}
