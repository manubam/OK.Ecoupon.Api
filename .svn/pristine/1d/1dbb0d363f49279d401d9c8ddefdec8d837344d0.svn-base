using Cgm.Ecoupon.Domain.Product.ProductDetails;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application
{
    public interface IProductDetailsService
    {
        Task<bool> AddProductDetails(Guid productCategoryId, Guid productBrandId, Guid productGroupId, string productCode, string productName, string productDescription, string productImageUrl, string userId);

        Task<bool> UpdateProductDetails(Guid id, Guid productCategoryId, Guid productBrandId, Guid productGroupId, string productCode, string productName, string productDescription, string productImageUrl, string userId);

        Task<Tuple<int, string>> DeleteProductDetails(Guid id, string userId);

        Task<Tuple<int, ProductDetailsModel>> GetProductDetailsId(Guid id);

        Task<Tuple<int, List<ProductDetailsModel>>> GetAllProductDetails(bool? isActive);

        Task<bool> ProductAlreadyExist(string productCode);

        Task<Tuple<int, string>> UploadExcel(List<ProductDetailsModel> objProductDetailModel, string userId);

        Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductGroupByProductMapping();

        Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductBrandByProductMapping();

        Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductCategoryByProductMapping();
    }
}
