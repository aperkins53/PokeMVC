using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class PMCreate
    {
        public int PokemonId { get; set; }
        public int MoveId { get; set; }
    }
}
