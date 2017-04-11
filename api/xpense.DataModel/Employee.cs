using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using xpense.Contract.Model;

namespace xpense.DataModel
{
    public partial class Employee : IAuditable
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
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public long OrganisationId { get; set; }
        public bool IsArchived { get; set; }
        public Organisation Organisation { get; set; }
        public ICollection<EmployeeContactDetail> ContactDetails { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
