using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers.Model
{
    [Table("SpecialOfer")]
    public class SpecialOfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CountryId { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
        public override string ToString()
        {
            return $"{DateStart.ToShortDateString()} {DateEnd.ToShortDateString()}";
        }
    }
}
