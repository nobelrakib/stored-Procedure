using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Ecommerce.Core.Entities;
namespace Ecommerce.Core.Entities
{
    public class Order2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public int CustomerId { get; set; }
        [ForeignKey("UserId")]
        public ExtendedIdentityUser User{ get; set; }
        public string UserId { get; set; }

    }
}
