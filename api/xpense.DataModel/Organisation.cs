using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpense.DataModel
{
    public class Organisation : BaseEntity
    {
        public Guid Key { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrganisationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string CompanyNumber { get; set; }

        [MaxLength(500)]
        public string RegisteredAddress { get; set; }

        public DateTime? IncorporationDate { get; set; }

        [MaxLength(30)]
        public string PayeReference { get; set; }

        [MaxLength(30)]
        public string PayeTaxOfficeReference { get; set; }

        [MaxLength(10)]
        public string VatNumber { get; set; }

        [MaxLength(15)]
        public string UniqueTaxpayerReference { get; set; }

        public bool IsArchived { get; set; }
    }
}
