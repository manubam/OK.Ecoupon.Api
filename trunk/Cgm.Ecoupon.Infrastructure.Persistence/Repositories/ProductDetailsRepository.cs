using Cgm.Ecoupon.Domain.Product.ProductDetails;
using Cgm.Ecoupon.Infrastructure.Persistence.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Infrastructure.Persistence.Repositories
{
    public class ProductDetailsRepository : IProductDetailsRepository
    {
        private static readonly ILog Log =
       LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public async Task<bool> AddProductDetails(Guid productCategoryId, Guid productBrandId, Guid productGroupId, string productCode,
            string productName, string productDescription, string productImageUrl, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    ProductDetail lModel = new ProductDetail
                    {
                        Id = Guid.NewGuid(),
                        ProductCategoryId = productCategoryId,
                        ProductBrandId = productBrandId,
                        ProductGroupId = productGroupId,
                        ProductCode = productCode,
                        ProductName = productName,
                        ProductDescription = productDescription,
                        ProductImageUrl = productImageUrl,
                        IsActive = true,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now
                    };

                    dbContext.ProductDetails.Add(lModel);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddProductDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProductDetails(Guid id, Guid productCategoryId, Guid productBrandId, Guid productGroupId,
            string productCode, string productName, string productDescription, string productImageUrl, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await dbContext.ProductDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (res == null)
                    {
                        return false;
                    }
                    res.ProductCategoryId = productCategoryId;
                    res.ProductBrandId = productBrandId;
                    res.ProductGroupId = productGroupId;
                    res.ProductCode = productCode;
                    res.ProductName = productName;
                    res.ProductDescription = productDescription;
                    res.ProductImageUrl = productImageUrl;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;

                    dbContext.ProductDetails.AddOrUpdate(res);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateProductDetails :: 500 :: " + ex.Message);
                return false;
            }
        }


        public async Task<Tuple<int, string>> DeleteProductDetails(Guid id, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await dbContext.ProductDetails.FirstOrDefaultAsync(x => x.Id == id);
                    if (res == null)
                    {
                        return new Tuple<int, string>(300, "Record not found");
                    }

                    var resOfferDetails = await dbContext.OfferDetails.FirstOrDefaultAsync(x => x.ProductId == id && x.IsActive == true);
                    if (resOfferDetails != null)
                    {
                        return new Tuple<int, string>(300, res.ProductName + " already used so cannot delete");
                    }

                    res.IsActive = false;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    dbContext.ProductDetails.AddOrUpdate(res);

                    await dbContext.SaveChangesAsync();
                    return new Tuple<int, string>(200, "Record Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("DeleteProductDetails :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, ProductDetailsModel>> GetProductDetailsId(Guid id)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await (from pd in dbContext.ProductDetails
                                     join pc in dbContext.ProductCategoryDetails on pd.ProductCategoryId equals pc.Id
                                     join pb in dbContext.ProductBrandDetails on pd.ProductBrandId equals pb.Id
                                     join pg in dbContext.ProductGroupDetails on pd.ProductGroupId equals pg.Id
                                     where (pd.Id == id)
                                     select new ProductDetailsModel
                                     {
                                         ProductId = pd.Id,
                                         ProductCategoryId = pd.ProductCategoryId,
                                         ProductBrandId = pd.ProductBrandId,
                                         ProductGroupId = pd.ProductGroupId,
                                         ProductCategoryName = pc.ProductCategoryName,
                                         ProductBrandName = pb.ProductBrandName,
                                         ProductName = pd.ProductName,
                                         ProductCode = pd.ProductCode,
                                         ProductDescription = pd.ProductDescription,
                                         ProductImageUrl = pd.ProductImageUrl,
                                         IsActive = pd.IsActive
                                     }).FirstOrDefaultAsync();


                    if (res == null)
                    {
                        return new Tuple<int, ProductDetailsModel>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, ProductDetailsModel>(200, res);
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetProductDetailsId :: 500 :: " + ex.Message);
                return new Tuple<int, ProductDetailsModel>(500, null);
            }
        }

        public async Task<Tuple<int, List<ProductDetailsModel>>> GetAllProductDetails(bool? isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    if (isActive == true)
                    {
                        var res = await (from pd in dbContext.ProductDetails
                                         join pc in dbContext.ProductCategoryDetails on pd.ProductCategoryId equals pc.Id
                                         join pb in dbContext.ProductBrandDetails on pd.ProductBrandId equals pb.Id
                                         join pg in dbContext.ProductGroupDetails on pd.ProductGroupId equals pg.Id
                                         where (pd.IsActive == true && pc.IsActive == true && pb.IsActive == true && pg.IsActive == true)
                                         select new ProductDetailsModel
                                         {
                                             ProductId = pd.Id,
                                             ProductCategoryId = pd.ProductCategoryId,
                                             ProductBrandId = pd.ProductBrandId,
                                             ProductGroupId = pd.ProductGroupId,
                                             ProductCategoryName = pc.ProductCategoryName,
                                             ProductBrandName = pb.ProductBrandName,
                                             ProductName = pd.ProductName,
                                             ProductCode = pd.ProductCode,
                                             ProductDescription = pd.ProductDescription,
                                             ProductImageUrl = pd.ProductImageUrl,
                                             ProductGroupName = pg.ProductGroupName,
                                             IsActive = pd.IsActive,
                                             CreatedDate = pd.CreatedDate
                                         }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();


                        if (res == null)
                        {
                            return new Tuple<int, List<ProductDetailsModel>>(300, null);
                        }
                        else
                        {
                            return new Tuple<int, List<ProductDetailsModel>>(200, res);
                        }
                    }
                    else
                    {
                        var res = await (from pd in dbContext.ProductDetails
                                         join pc in dbContext.ProductCategoryDetails on pd.ProductCategoryId equals pc.Id
                                         join pb in dbContext.ProductBrandDetails on pd.ProductBrandId equals pb.Id
                                         join pg in dbContext.ProductGroupDetails on pd.ProductGroupId equals pg.Id
                                         select new ProductDetailsModel
                                         {
                                             ProductId = pd.Id,
                                             ProductCategoryId = pd.ProductCategoryId,
                                             ProductBrandId = pd.ProductBrandId,
                                             ProductGroupId = pd.ProductGroupId,
                                             ProductCategoryName = pc.ProductCategoryName,
                                             ProductBrandName = pb.ProductBrandName,
                                             ProductName = pd.ProductName,
                                             ProductCode = pd.ProductCode,
                                             ProductDescription = pd.ProductDescription,
                                             ProductImageUrl = pd.ProductImageUrl,
                                             IsActive = pd.IsActive,
                                             CreatedDate = pd.CreatedDate
                                         }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();


                        if (res == null)
                        {
                            return new Tuple<int, List<ProductDetailsModel>>(300, null);
                        }
                        else
                        {
                            return new Tuple<int, List<ProductDetailsModel>>(200, res);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllProductDetails :: 500 :: " + ex.Message);
                return new Tuple<int, List<ProductDetailsModel>>(500, null);
            }
        }

        public async Task<bool> ProductAlreadyExist(string productCode)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await dbContext.ProductDetails.Where(x => x.ProductCode == productCode && x.IsActive == true).CountAsync();
                    if (res > 0) return true;
                    return false;

                }
            }
            catch (Exception ex)
            {
                Log.Error("ProductAlreadyExist :: 500 :: " + ex.Message);
                return true;
            }
        }

        public async Task<Tuple<int, string>> UploadExcel(List<ProductDetailsModel> objProductDetailsModel, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var productList = new List<ProductDetail>(); string ErrorMessage = "";

                    int rowIndex = 0;
                    foreach (var item in objProductDetailsModel)
                    {
                        rowIndex++; var proCode = new object(); var proName = new object();

                        if (string.IsNullOrEmpty(item.ProductCode))
                            ErrorMessage += "In Row " + rowIndex + " Product Code should not be blank.\n";
                        else
                        {
                            proCode = await dbContext.ProductDetails.Where(x => x.IsActive == true && x.ProductCode == item.ProductCode).FirstOrDefaultAsync();
                            if (proCode != null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductCode + " already exists.\n";
                        }

                        if (string.IsNullOrEmpty(item.ProductName))
                            ErrorMessage += "In Row " + rowIndex + " Product Name should not be blank.\n";
                        //else
                        //{
                        //    proName = await dbContext.ProductDetails.Where(x => x.IsActive == true && x.ProductName == item.ProductName).FirstOrDefaultAsync();
                        //    if (proName != null)
                        //        ErrorMessage += "In Row " + rowIndex + " " + item.ProductName + " already exists.\n";
                        //}


                        if (string.IsNullOrEmpty(item.ProductBrandName))
                            ErrorMessage += "In Row " + rowIndex + " Product Brand Name should not be blank.\n";
                        else
                        {
                            var proBrand = await dbContext.ProductBrandDetails.Where(x => x.IsActive == true && x.ProductBrandName == item.ProductBrandName).FirstOrDefaultAsync();
                            if (proBrand == null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductBrandName + " does not exists.\n";
                            else
                                item.ProductBrandId = proBrand.Id;
                        }

                        if (string.IsNullOrEmpty(item.ProductCategoryName))
                            ErrorMessage += "In Row " + rowIndex + " Product Category should not be blank.\n";
                        else
                        {
                            var proCategory = await dbContext.ProductCategoryDetails.Where(x => x.IsActive == true && x.ProductCategoryName == item.ProductCategoryName).FirstOrDefaultAsync();
                            if (proCategory == null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductCategoryName + " does not exists.\n";
                            else
                                item.ProductCategoryId = proCategory.Id;
                        }

                        if (string.IsNullOrEmpty(item.ProductGroupName))
                            ErrorMessage += "In Row " + rowIndex + " Product Group Name should not be blank.\n";
                        else
                        {
                            var proGroup = await dbContext.ProductGroupDetails.Where(x => x.IsActive == true && x.ProductGroupName == item.ProductGroupName).FirstOrDefaultAsync();
                            if (proGroup == null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductGroupName + " does not exists.\n";
                            else
                                item.ProductGroupId = proGroup.Id;
                        }

                        if (string.IsNullOrEmpty(item.ProductDescription))
                            ErrorMessage += "In Row " + rowIndex + " Product Description should not be blank.\n";


                        productList.Add(new ProductDetail
                        {
                            Id = Guid.NewGuid(),
                            ProductCategoryId = item.ProductCategoryId,
                            ProductBrandId = item.ProductBrandId,
                            ProductGroupId = item.ProductGroupId,
                            ProductCode = item.ProductCode,
                            ProductName = item.ProductName,
                            ProductDescription = item.ProductDescription,
                            ProductImageUrl = item.ProductImageUrl,
                            IsActive = true,
                            CreatedBy = userId,
                            CreatedDate = DateTime.Now
                        });

                        var duplicateProductCode = productList.GroupBy(x => x.ProductCode).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        if (proCode == null)
                        {
                            if (duplicateProductCode.Count > 0)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductCode + " already exists.\n";
                                productList.Clear();
                            }
                        }

                        //var duplicateProductName = productList.GroupBy(x => x.ProductName).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        //if (proName == null)
                        //{
                        //    if (duplicateProductName.Count > 0)
                        //    {
                        //        ErrorMessage += "In Row " + rowIndex + " " + item.ProductName + " already exists.\n";
                        //        productList.Clear();
                        //    }
                        //}        

                    }

                    if (ErrorMessage == "")
                    {
                        dbContext.ProductDetails.AddRange(productList);
                        await dbContext.SaveChangesAsync();

                        return new Tuple<int, string>(200, "Product Details Created Successfully");
                    }
                    else
                    {
                        return new Tuple<int, string>(300, ErrorMessage);
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("UploadExcel :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductGroupByProductMapping()
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await (from pd in dbContext.ProductDetails
                                     join pg in dbContext.ProductGroupDetails on pd.ProductGroupId equals pg.Id
                                     where (pd.IsActive == true && pg.IsActive == true)
                                     select new ProductDetailsModel
                                     {
                                         ProductGroupId = pd.ProductGroupId,
                                         ProductGroupName = pg.ProductGroupName,
                                         IsActive = pd.IsActive
                                     }).OrderByDescending(zz => zz.ProductGroupName).Distinct().ToListAsync();

                    return new Tuple<int, string, List<ProductDetailsModel>>(200, "Success", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetProductGroupByProductMapping :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductDetailsModel>>(500, "System Error", new List<ProductDetailsModel>());
            }
        }

        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductBrandByProductMapping()
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await (from pd in dbContext.ProductDetails
                                     join pb in dbContext.ProductBrandDetails on pd.ProductBrandId equals pb.Id
                                     where (pd.IsActive == true && pb.IsActive == true)
                                     select new ProductDetailsModel
                                     {
                                         ProductBrandId = pd.ProductBrandId,
                                         ProductBrandName = pb.ProductBrandName,
                                         IsActive = pd.IsActive
                                     }).OrderByDescending(zz => zz.ProductBrandName).Distinct().ToListAsync();

                    return new Tuple<int, string, List<ProductDetailsModel>>(200, "Success", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetProductBrandByProductMapping :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductDetailsModel>>(500, "System Error", new List<ProductDetailsModel>());
            }
        }

        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductCategoryByProductMapping()
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await (from pd in dbContext.ProductDetails
                                     join pc in dbContext.ProductCategoryDetails on pd.ProductCategoryId equals pc.Id
                                     where (pd.IsActive == true && pc.IsActive == true)
                                     select new ProductDetailsModel
                                     {

                                         ProductCategoryId = pd.ProductCategoryId,
                                         ProductCategoryName = pc.ProductCategoryName,
                                         IsActive = pd.IsActive

                                     }).OrderByDescending(zz => zz.ProductCategoryName).Distinct().ToListAsync();

                    return new Tuple<int, string, List<ProductDetailsModel>>(200, "Success", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetProductCategoryByProductMapping :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductDetailsModel>>(500, "System Error", new List<ProductDetailsModel>());
            }
        }

    }
}
