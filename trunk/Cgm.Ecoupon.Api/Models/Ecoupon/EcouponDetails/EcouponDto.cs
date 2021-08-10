using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cgm.Ecoupon.Api.Models.Ecoupon.EcouponDetails
{
    public class EcouponDto
    {
        public Guid EcouponId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BatchNo { get; set; }
        public uint TotalQuantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
    }
    public class AddEcouponDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BatchNo { get; set; }
        public uint TotalQuantity { get; set; }
        public string UserId { get; set; }
    }

    public class AllocateEcouponDto
    {
        public string EcouponName { get; set; }
        public string BatchNo { get; set; }
        public uint AllocatedQuantity { get; set; }
        public bool AllocationType { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string Division { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Township { get; set; }
        public string UserId { get; set; }
    }

    public class ActivateEcouponDto
    {
        public string EcouponName { get; set; }
        public string BatchNo { get; set; }
        public int CouponDiscount { get; set; }
        public int ActivationType { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string Division { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Township { get; set; }
        public string UserId { get; set; }
        public bool Activate { get; set; }
    }
}