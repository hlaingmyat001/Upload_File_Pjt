using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upload_File_Pjt.Models
{
    public class XMLUpload
    {
        [Key]
        public int xmlUpladId { get; set; }

        [Required]
        [Index("IX_TranId", 2, IsUnique = true)]
        public string tranId { get; set; }

        [Required]
        public decimal amount { get; set; }

        [Required]
        public string currencyCode { get; set; }

        [Required]
        public DateTime tranDate { get; set; }  

        [Required]
        public string status { get; set; }
    }
}
