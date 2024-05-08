using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectASP.Models
{ 
        public class Cart
        {
            [Key]
            public int CartItemId { get; set; }

            [ForeignKey("Product")]
            public int ProductID { get; set; }

            [Required]
            public string UserId { get; set; } // User ID property

            [Required]
            public int Quantity { get; set; }

            // Navigation property
            public virtual Product Product { get; set; }
        }
    
}
