using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Main
{
    [NotMapped]
    public class TournamentTable
    {
        public string? Name { get; set; }
        public int WinGoal { get; set; }
        public int LoseGoal { get; set; }
        public int Wins { get; set; }
        public int Lose { get; set; }
        public int Draw { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return $"{Name?.PadRight(10)} |  {WinGoal}  |  {LoseGoal}  |  {Wins}  |  {Draw}  |  {Lose}  |  {Score}";
        }
    }
}
