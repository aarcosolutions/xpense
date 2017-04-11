using System;
using System.Collections.Generic;
using System.Text;

namespace xpense.DataModel.Dto
{
    public class OrganisationDto
    {
        public Guid Key { get; set; }
        public string CompanyNumber { get; set; }
        public string Name { get; set; }

        public string RegisteredAddress { get; set; }
        public DateTime? IncorporationDate { get; set; }
        public string PayeReference { get; set; }
        public string PayeTaxOfficeReference { get; set; }
        public string VatNumber { get; set; }
        public string UniqueTaxpayerReference { get; set; }
    }
}
