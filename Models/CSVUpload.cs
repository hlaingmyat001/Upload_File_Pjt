using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upload_File_Pjt.Models
{
    public class CSVUpload
    {
        [Key]
        public int csvUploadId { get; set; }
        [Required]
        [Index("IX_TrandsId", 2, IsUnique = true)]
        public string tranIdentificator { get; set; }

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
