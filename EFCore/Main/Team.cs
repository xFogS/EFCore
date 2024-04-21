using EFCore._1_Work;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public List<Player>? Players { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name!.PadRight(5)} {City!.PadRight(5)}";
        }
    }
}
