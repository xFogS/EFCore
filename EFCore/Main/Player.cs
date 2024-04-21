using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore._1_Work
{
    public class Player
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Number { get; set; }

        public string? Position { get; set; }

        public int? TeamId { get; set; }

        public Team? Team { get; set; }

        public override string ToString()
        {
            return $"{Name?.PadRight(20)} {Number.ToString().PadLeft(2)} {Position}   {Team?.Name}";
        }
    }
}
