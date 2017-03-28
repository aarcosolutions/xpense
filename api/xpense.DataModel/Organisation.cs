using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpense.DataModel
{
    public class Organisation : IAuditable
    {
        [Column(Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrganisationId { get; set; }

        [Column(Order = 2)]
        public Guid Key { get; set; }

        [Column(Order = 3)]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(Order = 4)]
        [Required]
        [MaxLength(10)]
        public string CompanyNumber { get; set; }

        [Column(Order = 5)]
        [MaxLength(500)]
        public string RegisteredAddress { get; set; }

        [Column(Order = 6)]
        public DateTime? IncorporationDate { get; set; }

        [Column(Order = 7)]
        [MaxLength(30)]
        public string PayeReference { get; set; }

        [Column(Order = 8)]
        [MaxLength(30)]
        public string PayeTaxOfficeReference { get; set; }

        [Column(Order = 9)]
        [MaxLength(10)]
        public string VatNumber { get; set; }

        [Column(Order = 10)]
        [MaxLength(15)]
        public string UniqueTaxpayerReference { get; set; }

        [Column(Order = 11)]
        public bool IsArchived { get; set; }

        [Column(Order = 12)]
        public DateTime DateCreated { get; set; }

        [Column(Order = 13)]
        public DateTime DateModified { get; set; }

        [Column(Order = 14)]
        public long? CreatedBy { get; set; }

        [Column(Order = 15)]
        public long? ModifiedBy { get; set; }
    }
}
