using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpense.DataModel
{
    public class EmployeeContactDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeContactDetailId { get; set; }

        public long EmployeeId { get; set; }

        [Required]
        public int ContactType { get; set; }

        [Required]
        public Guid Key { get; set; }

        [Required]
        [MaxLength(255)]
        public string AddressLine1 { get; set; }

        [Required]
        [MaxLength(255)]
        public string AddressLine2 { get; set; }

        public long? CityId { get; set; }

        public long? CountyId { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        public long? CountryId { get; set; }

        [MaxLength(75)]
        public string Email { get; set; }

        [MaxLength(75)]
        public string Fax { get; set; }

        [MaxLength(75)]
        public string Phone1 { get; set; }

        [MaxLength(10)]
        public string Phone2 { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
