using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
