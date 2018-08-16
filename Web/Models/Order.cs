using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        [Column("order_id")]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        [Column("description")]
        public string Description { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<OrderProduct> OrderProducts { get; set; }

        [NotMapped]
        public decimal OrderTotal { get; set; }
    }
}
