using Cgm.Ecoupon.Domain.Product.ProductbrandDetails;
using Cgm.Ecoupon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application.Impl
{
    public class ProductBrandDetailsService : IProductBrandDetailsService
    {
        private readonly IProductBrandDetailsRepository _productBrandDetailsRepository;

        public ProductBrandDetailsService(IProductBrandDetailsRepository productBrandDetailsRepository)
        {
            _productBrandDetailsRepository = productBrandDetailsRepository;
        }
        public async Task<bool> AddProductBrandDetails(string brandCode, string brandBName, string brandDescription, string alias, string userId, bool isActive)
        {
            return
                await
                    _productBrandDetailsRepository.AddProductBrandDetails(brandCode, brandBName, brandDescription, alias,
                        userId, isActive);
        }

        public async Task<bool> UpdateProductBrandDetails(Guid id, string brandCode, string brandBName, string brandDescription, string alias,
            string userId, bool isActive)
        {
            return
               await
                   _productBrandDetailsRepository.UpdateProductBrandDetails(id, brandCode, brandBName, brandDescription, alias,
                       userId, isActive);
        }

        public async Task<Tuple<int, string>> DeleteProductBrandDetails(Guid id, string userId)
        {
            return
               await
                   _productBrandDetailsRepository.DeleteProductBrandDetails(id, userId);
        }

        public async Task<Tuple<int, List<ProductBrandDetailModel>>> GetAllProductBrandDetails(bool? isActive)
        {
            return
              await
                  _productBrandDetailsRepository.GetAllProductBrandDetails(isActive);
        }

        public async Task<Tuple<int, ProductBrandDetailModel>> GetProductBrandDetailsById(Guid id)
        {
            return
              await
                  _productBrandDetailsRepository.GetProductBrandDetailsById(id);
        }

        public async Task<bool> ProductBrandAlreadyExist(string brandCode)
        {
            return
             await
                 _productBrandDetailsRepository.ProductBrandAlreadyExist(brandCode);
        }

        public async Task<bool> ProductBrandNameAlreadyExist(string brandName)
        {
            return
             await
                 _productBrandDetailsRepository.ProductBrandNameAlreadyExist(brandName);
        }

        public async Task<Tuple<int, string>> UploadExcel(List<ProductBrandDetailModel> objProductBrandDetailModel, string userId)
        {
            return
             await
                 _productBrandDetailsRepository.UploadExcel(objProductBrandDetailModel, userId);
        }
    }
}
