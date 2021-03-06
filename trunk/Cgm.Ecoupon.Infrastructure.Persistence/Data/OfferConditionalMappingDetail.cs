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
    
    public partial class OfferConditionalMappingDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfferConditionalMappingDetail()
        {
            this.OfferConditiionalMappingBranchDetails = new HashSet<OfferConditiionalMappingBranchDetail>();
            this.OfferConditionalMappingCustomerDetails = new HashSet<OfferConditionalMappingCustomerDetail>();
            this.OfferConditionalMappingLocationDetails = new HashSet<OfferConditionalMappingLocationDetail>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid OfferDetailsId { get; set; }
        public int MediaTypeId { get; set; }
        public string MappingTypeName { get; set; }
        public decimal CommanValue { get; set; }
        public string OfferType { get; set; }
        public string SchemeValue { get; set; }
        public int ApprovalReqFlag { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<double> MinimumPayableAmount { get; set; }
        public Nullable<double> MaximumPayableAmount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferConditiionalMappingBranchDetail> OfferConditiionalMappingBranchDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferConditionalMappingCustomerDetail> OfferConditionalMappingCustomerDetails { get; set; }
        public virtual OfferDetail OfferDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferConditionalMappingLocationDetail> OfferConditionalMappingLocationDetails { get; set; }
    }
}
