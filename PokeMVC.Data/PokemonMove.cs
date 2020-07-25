using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Data
{
   public class PokemonMove
    {
        [Key]
        public int PokemonMoveId { get; set; }
        [ForeignKey("Pokemon")]
        public int PokemonId { get; set; }
        public virtual Pokemon Pokemon { get; set; }
        [ForeignKey("Move")]
        public int MoveId { get; set; }
        public virtual Move Move { get; set; }    
      
    }
}
