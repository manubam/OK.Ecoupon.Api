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
    
    public partial class OfferShemeConfigurationHistory
    {
        public System.Guid Id { get; set; }
        public System.Guid OfferShemeConfigurationId { get; set; }
        public System.Guid OfferDetailsId { get; set; }
        public System.Guid OfferShemeTypeId { get; set; }
        public Nullable<decimal> MinimumAmount { get; set; }
        public Nullable<decimal> MaximumAmount { get; set; }
        public Nullable<decimal> PurchaseFixedAmount { get; set; }
        public string BuyingProductName { get; set; }
        public string BuyingUOM { get; set; }
        public Nullable<int> BuyingQuantity { get; set; }
        public string FreeProductName { get; set; }
        public string FreeUOM { get; set; }
        public Nullable<int> FreeQuantity { get; set; }
        public Nullable<decimal> FixedDiscountAmount { get; set; }
        public Nullable<decimal> FixedDiscountPercentage { get; set; }
        public int OfferShemeTrackingSeqNo { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
