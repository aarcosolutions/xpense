using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpense.DataModel
{
    public class EmployeeContactDetail
    {
        [Column(Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeContactDetailId { get; set; }

        [Column(Order = 2)]
        [Required]
        public Guid Key { get; set; }

        [Column(Order = 3)]
        public long EmployeeId { get; set; }

        [Column(Order = 4)]
        [Required]
        public ContactType ContactType { get; set; }

        [Column(Order = 5)]
        [Required]
        [MaxLength(255)]
        public string AddressLine1 { get; set; }

        [Column(Order = 6)]
        [Required]
        [MaxLength(255)]
        public string AddressLine2 { get; set; }

        [Column(Order = 7)]
        public long? CityId { get; set; }

        [Column(Order = 8)]
        public long? CountyId { get; set; }

        [Column(Order = 9)]
        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [Column(Order = 10)]
        public long? CountryId { get; set; }

        [Column(Order = 11)]
        [MaxLength(75)]
        public string Email { get; set; }

        [Column(Order = 12)]
        [MaxLength(75)]
        public string Fax { get; set; }

        [Column(Order = 13)]
        [MaxLength(75)]
        public string Phone1 { get; set; }

        [Column(Order = 14)]
        [MaxLength(10)]
        public string Phone2 { get; set; }

        public Employee Employee { get; set; }
    }
}
