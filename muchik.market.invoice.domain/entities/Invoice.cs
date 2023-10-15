using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace muchik.market.invoice.domain.entities
{
    public partial class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Invoice { get; set; }       
        public decimal Amount { get; set; }
        public int State { get; set; }
    }
}