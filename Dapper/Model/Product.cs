using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public int? SpecialOfferId { get; set; }
        public override string ToString()
        {
            return $"{Category.Name} {Name} {SpecialOfferId}";
        }
    }
}
