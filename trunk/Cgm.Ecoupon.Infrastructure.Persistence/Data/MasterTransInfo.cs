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
    
    public partial class MasterTransInfo
    {
        public System.Guid Id { get; set; }
        public string OfferId { get; set; }
        public string SourceNumber { get; set; }
        public string DestinationNumber { get; set; }
        public string Amount { get; set; }
        public string TransactionId { get; set; }
        public string TransactionDateTime { get; set; }
        public string OsType { get; set; }
        public string AgentType { get; set; }
        public string PreBalance { get; set; }
        public string PostBalance { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
