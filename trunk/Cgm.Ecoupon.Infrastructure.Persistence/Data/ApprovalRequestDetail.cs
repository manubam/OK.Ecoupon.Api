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
    
    public partial class ApprovalRequestDetail
    {
        public System.Guid Id { get; set; }
        public System.Guid TransactionId { get; set; }
        public System.Guid OfferTransactionTypeId { get; set; }
        public string Status { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string RequestedBy { get; set; }
        public System.DateTime RequestDate { get; set; }
        public string RejectedBy { get; set; }
        public Nullable<System.DateTime> RejectedDate { get; set; }
    
        public virtual OfferTransactionType OfferTransactionType { get; set; }
    }
}
