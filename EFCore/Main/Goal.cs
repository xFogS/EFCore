using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore._1_Work
{
    public class Goal
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }

        public int GameId { get; set; }
        public Game? Game { get; set; }

        public int Minutes { get; set; }
        public override string ToString()
        {
            return $"Min: {Minutes}";
        }
    }
}
