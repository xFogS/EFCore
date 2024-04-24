using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers.Model
{
    [Table("WishList")]
    public class WishList
    {
        [Key]
        [Column(Order = 0)]
        public int CategoryId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int SubscriberId { get; set; }
    }
}
