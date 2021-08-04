using Cgm.Ecoupon.Domain.Branch;
using Cgm.Ecoupon.Domain.CompanyAndProductMapping;
using Cgm.Ecoupon.Domain.Product.ProductbrandDetails;
using Cgm.Ecoupon.Domain.Product.ProductCategoryDetails;
using Cgm.Ecoupon.Domain.Product.ProductDetails;
using Cgm.Ecoupon.Domain.Product.ProductGroupDetails;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application
{
    public interface ICompanyProductMappingService
    {
        Task<Tuple<int, string>> AddCompanyAndProductMapping(Guid companyId, List<Guid> branchIdList, List<Guid> productIdList,
           string createdUserId);

        Task<Tuple<int, string>> UpdateCompanyAndProductMapping(Guid companyAndProductMappingId,
            List<Guid> productIdList, string createdUserId);

        Task<Tuple<int, string, List<BranchModel>>> GatBranchByCompanyId(Guid companyId);

        Task<Tuple<int, string, List<ProductDetailsModel>>> GatProductByFilters(List<Guid> productGroupListId,
            List<Guid> productBrandListId, List<Guid> productCategoryListId);

        Task<Tuple<int, string, List<CompanyAndProductMapping>>> GetCompanyAndProductMappingList();

        Task<Tuple<int, string, CompanyAndProductMapping>> GetCompanyAndProductMappingById(Guid id);

        Task<Tuple<int, string, List<ProductGroupDetailsModel>>> GetProductGroupByCompanyIdandBranchId(Guid companyId, Guid branchId);

        Task<Tuple<int, string, List<ProductGroupDetailsModel>>> GetProductGroupByCompanyId(Guid companyId);

        Task<Tuple<int, string, List<ProductBrandDetailModel>>> GetProductBrandByCompanyId(Guid companyId);

        Task<Tuple<int, string, List<ProductCategoryDetailsModel>>> GetProductCategoryByCompanyId(Guid companyId);

        Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductDetailsByCompanyId(Guid companyId);
    }
}
