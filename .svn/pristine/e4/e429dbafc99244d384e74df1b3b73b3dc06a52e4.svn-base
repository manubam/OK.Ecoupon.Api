using Cgm.Ecoupon.Domain.Product.ProductbrandDetails;
using Cgm.Ecoupon.Domain.Product.ProductCategoryDetails;
using Cgm.Ecoupon.Domain.Product.ProductDetails;
using Cgm.Ecoupon.Domain.Product.ProductGroupDetails;
using System;
using System.Collections.Generic;

namespace Cgm.Ecoupon.Domain.CompanyAndProductMapping
{
    public class CompanyAndProductMappingModel
    {
        public Guid CompanyAndProductMappingId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
        public Guid ProductMappingId { get; set; }
        public int ProductGroupCount { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public ProductMappingModel PrductMappingModel { get; set; }
    }

    public class ProductMappingModel
    {
        public List<ProductGroupDetailsModel> ProductGroupIdList { get; set; }

        public List<ProductCategoryDetailsModel> ProductCategoryList { get; set; }

        public List<ProductBrandDetailModel> ProductBrandIdList { get; set; }
        public List<ProductDetailsModel> ProductIdList { get; set; }


    }

    public class CompanyAndProductMapping
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
        public int ProductGroupCount { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public List<CompanyAndProductMappingDetails> CompanyAndProductMappingDetailList { get; set; }

        public List<CompanyAndProductMappingSummarryBranch> BranchList { get; set; }
    }

    public class CompanyAndProductMappingDetails
    {
        public Guid Id { get; set; }
        public Guid CompanyAndProductMappingSummarryId { get; set; }
        public Guid ProductGroupId { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid ProductBrandId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductGroupName { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductName { get; set; }

    }

    public class CompanyAndProductMappingSummarryBranch
    {
        public Guid BranchId { get; set; }
    }
}
