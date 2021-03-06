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
    
    public partial class OfferDetailsHistory
    {
        public System.Guid Id { get; set; }
        public System.Guid OfferDetailsId { get; set; }
        public System.Guid OfferListingTypeId { get; set; }
        public System.Guid CompanyId { get; set; }
        public System.Guid ProductGroupId { get; set; }
        public System.Guid ProductCategoryId { get; set; }
        public System.Guid ProductBrandId { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid OfferTypeId { get; set; }
        public string OfferCode { get; set; }
        public string OfferName { get; set; }
        public string OfferBName { get; set; }
        public string OfferDescription { get; set; }
        public string OfferBDescription { get; set; }
        public string OfferImageUrl { get; set; }
        public bool PayToAutoLoadFlag { get; set; }
        public bool IsActive { get; set; }
        public bool OfferApprovedFlag { get; set; }
        public string OfferApproverUserId { get; set; }
        public Nullable<System.DateTime> OfferApprovedDateTime { get; set; }
        public bool OfferRejectedFlag { get; set; }
        public string OfferRejectedUserId { get; set; }
        public string OfferRejectedDescription { get; set; }
        public Nullable<System.DateTime> OfferRejectedDateTime { get; set; }
        public int OfferTrackingSeqNo { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifedDate { get; set; }
    
        public virtual OfferDetail OfferDetail { get; set; }
    }
}
