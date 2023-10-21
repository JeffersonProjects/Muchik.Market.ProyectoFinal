using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace muchik.market.pay.domain.entities{
    public partial class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_operation")]
        public int Id_Operation { get; set; }
        [Column("id_invoice")]
        public int Id_Invoice { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}