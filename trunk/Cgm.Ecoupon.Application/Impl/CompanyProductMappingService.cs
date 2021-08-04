using Cgm.Ecoupon.Domain.Branch;
using Cgm.Ecoupon.Domain.CompanyAndProductMapping;
using Cgm.Ecoupon.Domain.Product.ProductbrandDetails;
using Cgm.Ecoupon.Domain.Product.ProductCategoryDetails;
using Cgm.Ecoupon.Domain.Product.ProductDetails;
using Cgm.Ecoupon.Domain.Product.ProductGroupDetails;
using Cgm.Ecoupon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application.Impl
{
    public class CompanyProductMappingService : ICompanyProductMappingService
    {
        private ICompanyProductMappingRepository _companyProductMappingRepository;

        public CompanyProductMappingService(ICompanyProductMappingRepository companyProductMappingRepository)
        {
            _companyProductMappingRepository = companyProductMappingRepository;
        }
        public async Task<Tuple<int, string>> AddCompanyAndProductMapping(Guid companyId, List<Guid> branchIdList, List<Guid> productIdList, string createdUserId)
        {
            return
                await
                    _companyProductMappingRepository.AddCompanyAndProductMapping(companyId, branchIdList, productIdList,
                        createdUserId);
        }

        public async Task<Tuple<int, string>> UpdateCompanyAndProductMapping(Guid companyAndProductMappingId, List<Guid> productIdList, string createdUserId)
        {
            return
                await
                    _companyProductMappingRepository.UpdateCompanyAndProductMapping(companyAndProductMappingId,
                        productIdList, createdUserId);
        }

        public async Task<Tuple<int, string, List<BranchModel>>> GatBranchByCompanyId(Guid companyId)
        {
            return
                await
                    _companyProductMappingRepository.GatBranchByCompanyId(companyId);
        }

        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GatProductByFilters(List<Guid> productGroupListId, List<Guid> productBrandListId, List<Guid> productCategoryListId)
        {
            return
                await
                    _companyProductMappingRepository.GatProductByFilters(productGroupListId, productBrandListId,
                        productCategoryListId);
        }

        public async Task<Tuple<int, string, List<CompanyAndProductMapping>>> GetCompanyAndProductMappingList()
        {
            return
                await
                    _companyProductMappingRepository.GetCompanyAndProductMappingList();
        }

        public async Task<Tuple<int, string, CompanyAndProductMapping>> GetCompanyAndProductMappingById(Guid id)
        {
            return
              await
                  _companyProductMappingRepository.GetCompanyAndProductMappingById(id);
        }

        public async Task<Tuple<int, string, List<ProductGroupDetailsModel>>> GetProductGroupByCompanyIdandBranchId(Guid companyId, Guid branchId)
        {
            return
                        await
                            _companyProductMappingRepository.GetProductGroupByCompanyIdandBranchId(companyId, branchId);
        }

        public async Task<Tuple<int, string, List<ProductGroupDetailsModel>>> GetProductGroupByCompanyId(Guid companyId)
        {
            return
                        await
                            _companyProductMappingRepository.GetProductGroupByCompanyId(companyId);
        }

        public async Task<Tuple<int, string, List<ProductBrandDetailModel>>> GetProductBrandByCompanyId(Guid companyId)
        {
            return
                        await
                            _companyProductMappingRepository.GetProductBrandByCompanyId(companyId);
        }

        public async Task<Tuple<int, string, List<ProductCategoryDetailsModel>>> GetProductCategoryByCompanyId(Guid companyId)
        {
            return
                        await
                            _companyProductMappingRepository.GetProductCategoryByCompanyId(companyId);
        }

        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductDetailsByCompanyId(Guid companyId)
        {
            return
                        await
                            _companyProductMappingRepository.GetProductDetailsByCompanyId(companyId);
        }

    }
}
