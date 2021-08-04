using System.Collections.Generic;

namespace Cgm.Ecoupon.Api.Models.Product.ProductDetails
{
    public class ProductDto
    {
        public System.Guid ProductId { get; set; }
        public System.Guid ProductCategoryId { get; set; }
        public System.Guid ProductBrandId { get; set; }
        public System.Guid ProductGroupId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductGroupName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }

    }

    public class AddProductDto
    {
        public System.Guid ProductCategoryId { get; set; }
        public System.Guid ProductBrandId { get; set; }
        public System.Guid ProductGroupId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public string UserId { get; set; }

    }

    public class DeleteProductDto
    {
        public System.Guid ProductId { get; set; }
        public string UserId { get; set; }

    }

    public class UploadProductDto
    {
        public List<ProductDto> ProductList { get; set; }
        public string UserId { get; set; }
    }
}