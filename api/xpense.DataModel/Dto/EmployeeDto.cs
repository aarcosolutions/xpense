using System;
using System.Collections.Generic;
using System.Text;

namespace xpense.DataModel.Dto
{
    public class EmployeeDto
    {
        public Guid Key { get; set; }
        public string EmployeeNumber { get; set; }
        public string FullName
        {
            get
            {
                return $"{Title} {FirstName} {MiddleName} {LastName}";
            }
        }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NiNumber { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public Guid OrganisationKey { get; set; }
        public bool IsArchived { get; set; }
    }
}
