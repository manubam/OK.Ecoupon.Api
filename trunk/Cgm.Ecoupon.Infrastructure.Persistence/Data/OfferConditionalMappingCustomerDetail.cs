//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cgm.Ecoupon.Infrastructure.Persistence.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class OfferConditionalMappingCustomerDetail
    {
        public System.Guid Id { get; set; }
        public System.Guid OfferConditionalMappingId { get; set; }
        public System.Guid OfferConfigurationMobileNumberDetailsId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual OfferConditionalMappingDetail OfferConditionalMappingDetail { get; set; }
        public virtual OfferConfigurationMobileNumberDetail OfferConfigurationMobileNumberDetail { get; set; }
    }
}
