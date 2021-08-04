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
    
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            this.UserAccessRights = new HashSet<UserAccessRight>();
        }
    
        public System.Guid ID { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string MenuToolTipName { get; set; }
        public string MenuDescription { get; set; }
        public string MenuPath { get; set; }
        public string MenuIconPath { get; set; }
        public string MenuImagePath { get; set; }
        public int MenuDisplayOrderSeq { get; set; }
        public Nullable<System.Guid> MenuParentItemId { get; set; }
        public string HreafLinkClass { get; set; }
        public string FaIconClass { get; set; }
        public string FaIconImage { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAccessRight> UserAccessRights { get; set; }
    }
}