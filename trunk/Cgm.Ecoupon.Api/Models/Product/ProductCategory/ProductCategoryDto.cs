using System.Collections.Generic;

namespace Cgm.Ecoupon.Api.Models.Product.ProductCategory
{
    public class ProductCategoryDto
    {
        public System.Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }

    public class ProductCategoryAddDto
    {
        public System.Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }

    public class ProductCategoryDeleteDto
    {
        public System.Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }

    public class UploadProductCategoryDto
    {
        public List<ProductCategoryDto> ProductCategoryList { get; set; }
        public string UserId { get; set; }
    }
}