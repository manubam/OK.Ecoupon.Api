using Cgm.Ecoupon.Domain.Product.ProductDetails;
using Cgm.Ecoupon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application.Impl
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly IProductDetailsRepository _productDetailsRepository;

        public ProductDetailsService(IProductDetailsRepository productDetailsRepository)
        {
            _productDetailsRepository = productDetailsRepository;
        }
        public async Task<bool> AddProductDetails(Guid productCategoryId, Guid productBrandId, Guid productGroupId, string productCode,
            string productName, string productDescription, string productImageUrl, string userId)
        {
            return
                await
                    _productDetailsRepository.AddProductDetails(productCategoryId, productBrandId, productGroupId,
                        productCode, productName, productDescription, productImageUrl, userId);
        }

        public async Task<bool> UpdateProductDetails(Guid id, Guid productCategoryId, Guid productBrandId, Guid productGroupId, string productCode,
            string productName, string productDescription, string productImageUrl, string userId)
        {
            return
                await
                    _productDetailsRepository.UpdateProductDetails(id, productCategoryId, productBrandId, productGroupId,
                        productCode, productName, productDescription, productImageUrl, userId);
        }

        public async Task<Tuple<int, string>> DeleteProductDetails(Guid id, string userId)
        {
            return await _productDetailsRepository.DeleteProductDetails(id, userId);
        }

        public async Task<Tuple<int, ProductDetailsModel>> GetProductDetailsId(Guid id)
        {
            return await _productDetailsRepository.GetProductDetailsId(id);
        }

        public async Task<Tuple<int, List<ProductDetailsModel>>> GetAllProductDetails(bool? isActive)
        {
            return await _productDetailsRepository.GetAllProductDetails(isActive);
        }

        public async Task<bool> ProductAlreadyExist(string productCode)
        {
            return await _productDetailsRepository.ProductAlreadyExist(productCode);
        }

        public async Task<Tuple<int, string>> UploadExcel(List<ProductDetailsModel> objProductDetailModel, string userId)
        {
            return
             await
                 _productDetailsRepository.UploadExcel(objProductDetailModel, userId);
        }

        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductGroupByProductMapping()
        {
            return await _productDetailsRepository.GetProductGroupByProductMapping();
        }
        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductBrandByProductMapping()
        {
            return await _productDetailsRepository.GetProductBrandByProductMapping();
        }
        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductCategoryByProductMapping()
        {
            return await _productDetailsRepository.GetProductCategoryByProductMapping();
        }

    }
}
