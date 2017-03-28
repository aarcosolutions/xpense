using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xpense.DataModel;

namespace xpense.Repository
{
    public static class DataInitialiser
    {
        public static void Initialise(XpenseDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            var organisations = GetOrganisations();
            var employees = GetEmployees(organisations);

            if(!context.Organisations.Any())
            {
                context.Organisations.AddRange(organisations);
            }

            if(!context.Employees.Any())
            {
                context.Employees.AddRange(employees);
            }

            if(context.ChangeTracker.HasChanges())
            {
                context.SaveChanges();
            }
        }

        private static IList<Employee> GetEmployees(IList<Organisation> org)
        {
            var employees = new Employee[]
            {
                new Employee
                {
                    Key=Guid.NewGuid(),
                    EmployeeNumber="EMP12343456",
                    FirstName="Jack",
                    LastName="Carling",
                    MiddleName="R",
                    IsArchived=false,
                    NiNumber="NI1234567",
                    StartDate=DateTime.Today.AddYears(-5),
                    Title="Mr",
                    Organisation = org.First(),
                    ContactDetails = new List<EmployeeContactDetail>
                    {
                        new EmployeeContactDetail
                        {
                            AddressLine1="LoremIpsum",
                            AddressLine2="LoremIpsum",
                            ContactType = ContactType.Home,
                            Email="Lorem@Ipsum.com",
                            Fax="123456778",
                            Key=Guid.NewGuid(),
                            Phone1="1234567",
                            Phone2="12345678",
                            PostCode="LoremIpsum"
                        }
                    }
                },
                new Employee
                {
                    Key=Guid.NewGuid(),
                    EmployeeNumber="EMP2343456",
                    FirstName="Lucy",
                    LastName="Williams",
                    MiddleName="J",
                    IsArchived=false,
                    NiNumber="NI234567",
                    StartDate=DateTime.Today.AddYears(-15),
                    Title="Mrs",
                    Organisation = org.First(),
                    ContactDetails = new List<EmployeeContactDetail>
                    {
                        new EmployeeContactDetail
                        {
                            AddressLine1="LoremIpsum",
                            AddressLine2="LoremIpsum",
                            ContactType = ContactType.Home,
                            Email="Lorem@Ipsum.com",
                            Fax="123456778",
                            Key=Guid.NewGuid(),
                            Phone1="1234567",
                            Phone2="12345678",
                            PostCode="LoremIpsum"
                        }
                    }
                },
                new Employee
                {
                    Key=Guid.NewGuid(),
                    EmployeeNumber="EMP92343456",
                    FirstName="Ashton",
                    LastName="Junior",
                    IsArchived=false,
                    NiNumber="NI9234567",
                    StartDate=DateTime.Today.AddYears(-8),
                    Title="Mr",
                    Organisation = org.Last(),
                    ContactDetails = new List<EmployeeContactDetail>
                    {
                        new EmployeeContactDetail
                        {
                            AddressLine1="LoremIpsum",
                            AddressLine2="LoremIpsum",
                            ContactType = ContactType.Home,
                            Email="Lorem@Ipsum.com",
                            Fax="123456778",
                            Key=Guid.NewGuid(),
                            Phone1="1234567",
                            Phone2="12345678",
                            PostCode="LoremIpsum"
                        }
                    }
                },
                new Employee
                {
                    Key=Guid.NewGuid(),
                    EmployeeNumber="EMP7343456",
                    FirstName="Terry",
                    LastName="Sutton",
                    MiddleName="A",
                    IsArchived=false,
                    NiNumber="NI834567",
                    StartDate=DateTime.Today.AddYears(-18),
                    Title="Mr",
                    Organisation = org.Last(),
                    ContactDetails = new List<EmployeeContactDetail>
                    {
                        new EmployeeContactDetail
                        {
                            AddressLine1="LoremIpsum",
                            AddressLine2="LoremIpsum",
                            ContactType = ContactType.Home,
                            Email="Lorem@Ipsum.com",
                            Fax="123456778",
                            Key=Guid.NewGuid(),
                            Phone1="1234567",
                            Phone2="12345678",
                            PostCode="LoremIpsum"
                        }
                    }
                }
            };
            return employees;
        }

        private static IList<Organisation> GetOrganisations()
        {
            var organisations = new Organisation[]
            {
                new Organisation
                {
                    CompanyNumber="A1234567",
                    IncorporationDate=DateTime.Now.AddYears(-30),
                    IsArchived=false,
                    Key=Guid.NewGuid(),
                    Name="TestOrg01",
                    PayeReference="P12343456",
                    PayeTaxOfficeReference="PTOR123456",
                    RegisteredAddress="LoremIpsumLoremIpsumLoremIpsumLoremIpsumLoremIpsum LoremIpsumLoremIpsumLoremIpsum",
                    UniqueTaxpayerReference="UTR1234567",
                    VatNumber="VAT1234567"
                },
                new Organisation
                {
                    CompanyNumber="A234567",
                    IncorporationDate=DateTime.Now.AddYears(-35),
                    IsArchived=false,
                    Key=Guid.NewGuid(),
                    Name="TestOrg02",
                    PayeReference="P2343456",
                    PayeTaxOfficeReference="PTOR23456",
                    RegisteredAddress="LoremIpsumLoremIpsumLoremIpsumLoremIpsumLoremIpsum LoremIpsumLoremIpsumLoremIpsum",
                    UniqueTaxpayerReference="UTR234567",
                    VatNumber="VAT1234567"
                }
            };

            return organisations;
        }
    }
}
