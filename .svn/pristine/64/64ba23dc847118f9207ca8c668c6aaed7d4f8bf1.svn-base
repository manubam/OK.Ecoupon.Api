using Cgm.Ecoupon.Domain.Product.ProductCategoryDetails;
using Cgm.Ecoupon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application.Impl
{
    public class ProductCategoryDetailsService : IProductCategoryDetailsService
    {
        private readonly IProductCategoryDetailsRepository _productCategoryDetailsRepository;

        public ProductCategoryDetailsService(IProductCategoryDetailsRepository productCategoryDetailsRepository)
        {
            _productCategoryDetailsRepository = productCategoryDetailsRepository;
        }
        public async Task<bool> AddProductCategoryDetails(string productCategoryName, string productCategoryDescription, string userId, bool isActive)
        {
            return
                await
                    _productCategoryDetailsRepository.AddProductCategoryDetails(productCategoryName,
                        productCategoryDescription, userId, isActive);
        }

        public async Task<bool> UpdateProductCategoryDetails(Guid id, string productCategoryName, string productCategoryDescription, string userId, bool isActive)
        {
            return
               await
                   _productCategoryDetailsRepository.UpdateProductCategoryDetails(id, productCategoryName,
                       productCategoryDescription, userId, isActive);
        }

        public async Task<Tuple<int, string>> DeleteProductCategoryDetails(Guid id, string userId)
        {
            return
               await
                   _productCategoryDetailsRepository.DeleteProductCategoryDetails(id, userId);
        }

        public async Task<Tuple<int, ProductCategoryDetailsModel>> GetProductCategoryDetailsId(Guid id)
        {
            return
               await
                   _productCategoryDetailsRepository.GetProductCategoryDetailsId(id);
        }

        public async Task<Tuple<int, List<ProductCategoryDetailsModel>>> GetAllProductCategoryDetails(bool? isActive)
        {
            return
               await
                   _productCategoryDetailsRepository.GetAllProductCategoryDetails(isActive);
        }

        public async Task<bool> ProductCategoryAlreadyExist(string companyName)
        {
            return
              await
                  _productCategoryDetailsRepository.ProductCategoryAlreadyExist(companyName);
        }

        public async Task<Tuple<int, string>> UploadExcel(List<ProductCategoryDetailsModel> objProductCategoryDetailsModel, string userId)
        {
            return
             await
                 _productCategoryDetailsRepository.UploadExcel(objProductCategoryDetailsModel, userId);
        }
    }
}
