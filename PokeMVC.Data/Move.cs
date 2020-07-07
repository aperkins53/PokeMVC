using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Data
{
    public class Move
    {
        [Key]
        [Display(Name = "Move ID")]
        public int MoveId { get; set; }
        [Required]
        [Display(Name = "Move")]
        public string MoveName { get; set; }
        [Required]
        [Display(Name = "Power")]
        public int MovePower { get; set; }
        [Required]
        [Display(Name = "Accuracy")]
        public int MoveAccuracy { get; set; }
        [Required]
        [Display(Name = "PP")]
        public int MovePP { get; set; }
        [Display(Name = "Extra Effect")]
        public string ExtraEffect { get; set; }
    }
}
