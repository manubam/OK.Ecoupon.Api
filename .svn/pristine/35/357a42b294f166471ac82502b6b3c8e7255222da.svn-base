using Cgm.Ecoupon.Domain.Product.ProductbrandDetails;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Infrastructure.Persistence
{
    public interface IProductBrandDetailsRepository
    {
        Task<bool> AddProductBrandDetails(string brandCode, string brandBName, string brandDescription, string alias,
            string userId, bool isActive);

        Task<bool> UpdateProductBrandDetails(Guid id, string brandCode, string brandBName, string brandDescription,
            string alias, string userId, bool isActive);

        Task<Tuple<int, string>> DeleteProductBrandDetails(Guid id, string userId);

        Task<Tuple<int, List<ProductBrandDetailModel>>> GetAllProductBrandDetails(bool? isActive);

        Task<Tuple<int, ProductBrandDetailModel>> GetProductBrandDetailsById(Guid id);

        Task<bool> ProductBrandAlreadyExist(string brandCode);

        Task<bool> ProductBrandNameAlreadyExist(string brandName);

        Task<Tuple<int, string>> UploadExcel(List<ProductBrandDetailModel> objProductBrandDetailModel, string userId);
    }
}
