using System;

namespace Cgm.Ecoupon.Domain.Product.ProductbrandDetails
{
    public class ProductBrandDetailModel
    {
        public System.Guid Id { get; set; }
        public string ProductBrandCode { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductBrandDescription { get; set; }
        public string ProductBrandAlieas { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
