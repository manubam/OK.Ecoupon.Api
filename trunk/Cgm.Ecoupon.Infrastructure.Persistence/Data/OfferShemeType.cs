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
    
    public partial class OfferShemeType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfferShemeType()
        {
            this.OfferShemeConfigurations = new HashSet<OfferShemeConfiguration>();
        }
    
        public System.Guid Id { get; set; }
        public string OfferShemeName { get; set; }
        public int DisplayOrderSeqNo { get; set; }
        public int ShemeId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferShemeConfiguration> OfferShemeConfigurations { get; set; }
    }
}
