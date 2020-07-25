using PokeMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Models
{
    public class TrainerEdit
    {
        public int TrainerId { get; set; }
        public string Name { get; set; }
        public bool IsGymLeader { get; set; }
        public bool IsEliteFour { get; set; }
        public bool IsChampion { get; set; }
    }
}
