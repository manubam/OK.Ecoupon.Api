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
    
    public partial class OfferBlockDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfferBlockDetail()
        {
            this.OfferBlockBranchDetails = new HashSet<OfferBlockBranchDetail>();
            this.OfferBlockCustomerDetails = new HashSet<OfferBlockCustomerDetail>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid CompanyId { get; set; }
        public System.Guid OfferDetailsId { get; set; }
        public System.DateTime BlockStartDateTime { get; set; }
        public System.DateTime BlockEndDateTime { get; set; }
        public int MediaTypeId { get; set; }
        public string MediaTypeName { get; set; }
        public string OfferBlockType { get; set; }
        public bool ApprovalFlag { get; set; }
        public int ApprovalReqFlag { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual CompanyDetail CompanyDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferBlockBranchDetail> OfferBlockBranchDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferBlockCustomerDetail> OfferBlockCustomerDetails { get; set; }
        public virtual OfferDetail OfferDetail { get; set; }
    }
}
