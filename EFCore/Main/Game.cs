using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore._1_Work
{
    public class Game
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        [Required]
        public int? TeamId1 { get; set; }

        [ForeignKey("TeamId1")]
        public Team? Team1 { get; set; }

        [Required]
        public int? TeamId2 { get; set; }

        [ForeignKey("TeamId2")]
        public Team? Team2 { get; set; }
        public List<Goal> Goals { get; set; } = [];

        public override string ToString()
        {
            return $"{Date} {Team1?.Name} - {Team2?.Name}";
        }
    }
}
