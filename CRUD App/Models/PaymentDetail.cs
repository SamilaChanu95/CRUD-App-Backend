using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_App.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string CardOwnerName { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; } = string.Empty; 
        [Column(TypeName = "nvarchar(5)")]
        public string ExpirationDate { get; set; } =  string.Empty;
        [Column(TypeName = "nvarchar(3)")]
        public string SecurityCode { get; set; } = string.Empty;
    }
}
