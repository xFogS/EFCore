using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers.Model
{
    [Table("Subscriber")]
    public class Subscriber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public bool Gender { get; set; }

        public string Email { get; set; }

        public int CountryId { get; set; }
        public override string ToString()
        {
            return $"{Name} {BirthDay.ToShortDateString()} {Gender} {Email}";
        }
    }
}
