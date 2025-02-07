using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass1.Models
{
    [Table("Goods")]
    public class Good
    {
        [Key]
        [StringLength(9, MinimumLength = 9)]
        public string MaHangHoa { get; set; } = string.Empty;

        [Required]
        public string TenHangHoa { get; set; } = string.Empty;

        [Required]
        public int SoLuong { get; set; }
    }
}
