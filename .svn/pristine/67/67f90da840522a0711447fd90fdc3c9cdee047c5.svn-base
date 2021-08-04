using Cgm.Ecoupon.Domain.Product.ProductGroupDetails;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Infrastructure.Persistence
{
    public interface IProductGroupDetailsRepository
    {
        Task<bool> AddProductGroupDetails(string productGroupName, string productGroupDescription, string userId, bool isActive);

        Task<bool> UpdateProductGroupDetails(Guid id, string productGroupName, string productGroupDescription, string userId, bool isActive);

        Task<Tuple<int, string>> DeleteProductGroupDetails(Guid id, string userId);

        Task<Tuple<int, ProductGroupDetailsModel>> GetProductGroupDetailsId(Guid id);

        Task<Tuple<int, List<ProductGroupDetailsModel>>> GetAllProductGroupDetails(bool? isActive);

        Task<bool> ProductGroupAlreadyExist(string productGroupName);

        Task<Tuple<int, string>> UploadExcel(List<ProductGroupDetailsModel> objProductGroupDetailsModel, string userId);
    }
}
