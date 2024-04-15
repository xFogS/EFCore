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
        public int Wins { get; set; }
        public int Loss { get; set; }
        public int Draw { get; set;}
        //new
        public int goalsScored { get; set; }
        public int goalsLosses { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name!.PadRight(5)} {City!.PadRight(5)} {Wins} {Loss} " +
                $"{Draw} {goalsScored} {goalsLosses}";
        }
    }
}
