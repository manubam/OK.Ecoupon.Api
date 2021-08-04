using System;

namespace Cgm.Ecoupon.Domain.CompanyAndProductMapping
{
    public class ProductMappingsModel
    {
        public System.Guid ProductId { get; set; }
        public System.Guid ProductCategoryId { get; set; }
        public System.Guid ProductBrandId { get; set; }
        public System.Guid ProductGroupId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductGroupName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
