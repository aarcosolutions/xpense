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
        [Column(Order=1)]
        public long EmployeeId { get; set; }

        [Column(Order = 2)]
        public Guid Key { get; set; }

        [Column(Order = 3)]
        [Required]
        [MaxLength(15)]
        public string EmployeeNumber { get; set; }

        [Column(Order = 4)]
        [Required]
        [MaxLength(15)]
        public string Title { get; set; }

        [Column(Order = 5)]
        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }

        [Column(Order = 6)]
        public string MiddleName { get; set; }

        [Column(Order = 7)]
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }

        [Column(Order = 8)]
        [Required]
        [MaxLength(20)]
        public string NiNumber { get; set; }

        [Column(Order = 9)]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(Order = 10)]
        public long OrganisationId { get; set; }

        [Column(Order = 11)]
        public bool IsArchived { get; set; }

        public Organisation Organisation { get; set; }

        public ICollection<EmployeeContactDetail> ContactDetails { get; set; }

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
