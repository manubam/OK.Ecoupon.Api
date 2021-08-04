using System;

namespace Cgm.Ecoupon.Domain.CompanyDetails
{
    public class OfferBackendNumberModel
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string AliesName { get; set; }
        public string BackendMobileNumber { get; set; }
        public string BackendMobileNumberPassword { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
