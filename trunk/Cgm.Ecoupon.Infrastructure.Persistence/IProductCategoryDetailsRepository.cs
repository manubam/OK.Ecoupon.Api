using Cgm.Ecoupon.Domain.Product.ProductCategoryDetails;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Infrastructure.Persistence
{
    public interface IProductCategoryDetailsRepository
    {
        Task<bool> AddProductCategoryDetails(string productCategoryName, string productCategoryDescription, string userId, bool isActive);

        Task<bool> UpdateProductCategoryDetails(Guid id, string productCategoryName, string productCategoryDescription, string userId, bool isActive);

        Task<Tuple<int, string>> DeleteProductCategoryDetails(Guid id, string userId);

        Task<Tuple<int, ProductCategoryDetailsModel>> GetProductCategoryDetailsId(Guid id);

        Task<Tuple<int, List<ProductCategoryDetailsModel>>> GetAllProductCategoryDetails(bool? isActive);

        Task<bool> ProductCategoryAlreadyExist(string productCategoryName);

        Task<Tuple<int, string>> UploadExcel(List<ProductCategoryDetailsModel> objProductCategoryDetailsModel, string userId);
    }
}
