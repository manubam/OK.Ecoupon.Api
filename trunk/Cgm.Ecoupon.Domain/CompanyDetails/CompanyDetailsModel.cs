using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Domain.CompanyDetails
{
    public class CompanyDetailsModel
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyBName { get; set; }

        public string CompanyDescription { get; set; }

        public string CompanyImageUrl { get; set; }

        public bool IsActive { get; set; }
        public string BackendMobileNumber { get; set; }
        public string BackendMobileNumberPassword { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<OfferBackendNumberModel> OfferBackendNumberModelList { get; set; }
    }
}
