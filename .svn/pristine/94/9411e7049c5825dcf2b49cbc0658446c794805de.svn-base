using Cgm.Ecoupon.Domain.Product.ProductGroupDetails;
using Cgm.Ecoupon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application.Impl
{
    public class ProductGroupDetailsService : IProductGroupDetailsService
    {
        private readonly IProductGroupDetailsRepository _productGroupDetailsRepository;

        public ProductGroupDetailsService(IProductGroupDetailsRepository productGroupDetailsRepository)
        {
            _productGroupDetailsRepository = productGroupDetailsRepository;
        }
        public async Task<bool> AddProductGroupDetails(string productGroupName, string productGroupDescription, string userId, bool isActive)
        {
            return
                await
                    _productGroupDetailsRepository.AddProductGroupDetails(productGroupName,
                        productGroupDescription, userId, isActive);
        }

        public async Task<bool> UpdateProductGroupDetails(Guid id, string productGroupName, string productGroupDescription, string userId, bool isActive)
        {
            return
               await
                   _productGroupDetailsRepository.UpdateProductGroupDetails(id, productGroupName,
                       productGroupDescription, userId, isActive);
        }

        public async Task<Tuple<int, string>> DeleteProductGroupDetails(Guid id, string userId)
        {
            return
               await
                   _productGroupDetailsRepository.DeleteProductGroupDetails(id, userId);
        }

        public async Task<Tuple<int, ProductGroupDetailsModel>> GetProductGroupDetailsId(Guid id)
        {
            return
               await
                   _productGroupDetailsRepository.GetProductGroupDetailsId(id);
        }

        public async Task<Tuple<int, List<ProductGroupDetailsModel>>> GetAllProductGroupDetails(bool? isActive)
        {
            return
               await
                   _productGroupDetailsRepository.GetAllProductGroupDetails(isActive);
        }

        public async Task<bool> ProductGroupAlreadyExist(string companyName)
        {
            return
              await
                  _productGroupDetailsRepository.ProductGroupAlreadyExist(companyName);
        }

        public async Task<Tuple<int, string>> UploadExcel(List<ProductGroupDetailsModel> objProductGroupDetailsModel, string userId)
        {
            return
             await
                 _productGroupDetailsRepository.UploadExcel(objProductGroupDetailsModel, userId);
        }
    }
}
