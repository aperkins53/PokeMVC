using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class MoveDetail
    {
        [Display(Name = "Move ID")]
        public int MoveId { get; set; }
        [Display(Name = "Name")]
        public string MoveName { get; set; }
        [Display(Name = "Power")]
        public int MovePower { get; set; }
        [Display(Name = "Accuracy")]
        public int MoveAccuracy { get; set; }
        [Display(Name = "PP")]
        public int MovePP { get; set; }
        [Display(Name = "Extra Effect")]
        public string ExtraEffect { get; set; }
    }
}
