using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class MoveEdit
    {
        public int MoveId { get; set; }
        public string MoveName { get; set; }
        public int MovePower { get; set; }
        public int MoveAccuracy { get; set; }
        public int MovePP { get; set; }
        public string ExtraEffect { get; set; }
    }
}
