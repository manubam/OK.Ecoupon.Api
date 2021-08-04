using System.Collections.Generic;

namespace Cgm.Ecoupon.Api.Models.Product.ProductGroup
{
    public class ProductGroupDto
    {
        public System.Guid ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public string ProductGroupDescription { get; set; }
        public bool IsActive { get; set; }

        public string UserId { get; set; }
    }

    public class ProductGroupAddDto
    {
        public string ProductGroupName { get; set; }
        public string ProductGroupDescription { get; set; }
        public bool IsActive { get; set; }

        public string UserId { get; set; }
    }

    public class ProductGroupDeleteDto
    {
        public System.Guid ProductGroupId { get; set; }
        public string UserId { get; set; }
    }

    public class UploadProductGroupDto
    {
        public List<ProductGroupAddDto> ProductGroupList { get; set; }
        public string UserId { get; set; }
    }
}