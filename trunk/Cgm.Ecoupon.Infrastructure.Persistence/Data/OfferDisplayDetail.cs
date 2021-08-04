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
    
    public partial class OfferDisplayDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfferDisplayDetail()
        {
            this.OfferDisplayAppVersionDetails = new HashSet<OfferDisplayAppVersionDetail>();
            this.OfferDisplayDetailsHistories = new HashSet<OfferDisplayDetailsHistory>();
            this.OfferDisplayLocationDetails = new HashSet<OfferDisplayLocationDetail>();
            this.OfferDisplayMappingDetails = new HashSet<OfferDisplayMappingDetail>();
            this.OfferDisplayTelcoDetails = new HashSet<OfferDisplayTelcoDetail>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid OfferDetailsId { get; set; }
        public int MediaTypeId { get; set; }
        public string MediaTypeName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool OfferDisplayApprovedFlag { get; set; }
        public string OfferDisplayApproverUserId { get; set; }
        public Nullable<System.DateTime> OfferDisplayApprovedDateTime { get; set; }
        public bool OfferDisplayRejectedFlag { get; set; }
        public string OfferDisplayRejectedUserId { get; set; }
        public string OfferDisplayRejectedDescription { get; set; }
        public Nullable<System.DateTime> OfferDisplayRejectedDateTime { get; set; }
        public int OfferDisplayTrackingSeqNo { get; set; }
        public int ApprovalReqFlag { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual OfferDetail OfferDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferDisplayAppVersionDetail> OfferDisplayAppVersionDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferDisplayDetailsHistory> OfferDisplayDetailsHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferDisplayLocationDetail> OfferDisplayLocationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferDisplayMappingDetail> OfferDisplayMappingDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferDisplayTelcoDetail> OfferDisplayTelcoDetails { get; set; }
    }
}