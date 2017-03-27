using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpense.DataModel
{
    public partial class Employee : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId { get; set; }

        public Guid Key { get; set; }

        [Required]
        [MaxLength(15)]
        public string EmployeeNumber { get; set; }

        [Required]
        [MaxLength(15)]
        public string Title { get; set; }

        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string NiNumber { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public long OrganisationId { get; set; }

        public bool IsArchived { get; set; }

        public virtual Organisation Organisation { get; set; }

        public virtual IEnumerable<EmployeeContactDetails> ContactDetails { get; set; }
    }
}
