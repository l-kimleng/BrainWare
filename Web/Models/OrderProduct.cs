using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("orderproduct")]
    public partial class OrderProduct
    {
        [Key]
        [Column("order_id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }
        public Order Order { get; set; }


        [Key]
        [Column("product_id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        public Product Product { get; set; }


        [Column("price", TypeName = "money")]
        public decimal? Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

    }
}
