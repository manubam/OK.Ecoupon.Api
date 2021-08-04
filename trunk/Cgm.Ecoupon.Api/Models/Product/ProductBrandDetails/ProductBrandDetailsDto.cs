using System.Collections.Generic;

namespace Cgm.Ecoupon.Api.Models.Product.ProductBrandDetails
{
    public class ProductBrandDetailDto
    {
        public System.Guid ProductBrandId { get; set; }
        public string ProductBrandCode { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductBrandDescription { get; set; }
        public string ProductBrandAlieas { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }

    public class ProductBrandDetailAddDto
    {
        public string ProductBrandCode { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductBrandDescription { get; set; }
        public string ProductBrandAlieas { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }

    public class ProductBrandDetailDeleteDto
    {
        public System.Guid ProductBrandId { get; set; }
        public string UserId { get; set; }
    }

    public class UploadProductBrandDetailDto
    {
        public List<ProductBrandDetailDto> ProductBrandList { get; set; }
        public string UserId { get; set; }
    }
}