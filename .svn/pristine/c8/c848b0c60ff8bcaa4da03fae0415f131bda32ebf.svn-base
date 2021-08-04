using Cgm.Ecoupon.Domain.Product.ProductCategoryDetails;
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
    public class ProductCategoryDetailsRepository : IProductCategoryDetailsRepository
    {
        private static readonly ILog Log =
           LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public async Task<bool> AddProductCategoryDetails(string productCategoryName, string productCategoryDescription, string userId, bool isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    ProductCategoryDetail lModel = new ProductCategoryDetail
                    {
                        Id = Guid.NewGuid(),
                        ProductCategoryName = productCategoryName,
                        ProductCategoryDescription = productCategoryDescription,
                        IsActive = isActive,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now
                    };

                    dbContext.ProductCategoryDetails.Add(lModel);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddProductCategoryDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProductCategoryDetails(Guid id, string productCategoryName, string productCategoryDescription, string userId, bool isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductCategoryDetails.FirstOrDefaultAsync(x => x.Id == id);
                    if (res == null)
                    {
                        return false;
                    }

                    res.ProductCategoryName = productCategoryName;
                    res.ProductCategoryDescription = productCategoryDescription;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    res.IsActive = isActive;
                    dbContext.ProductCategoryDetails.AddOrUpdate(res);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateProductCategoryDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<Tuple<int, string>> DeleteProductCategoryDetails(Guid id, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductCategoryDetails.FirstOrDefaultAsync(x => x.Id == id);
                    if (res == null)
                    {
                        return new Tuple<int, string>(300, "Record not found");
                    }

                    var resProdDetails = await dbContext.ProductDetails.FirstOrDefaultAsync(x => x.ProductCategoryId == id && x.IsActive == true);
                    if (resProdDetails != null)
                    {
                        return new Tuple<int, string>(300, res.ProductCategoryName + " already used so cannot delete");
                    }

                    res.IsActive = false;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    dbContext.ProductCategoryDetails.AddOrUpdate(res);

                    await dbContext.SaveChangesAsync();
                    return new Tuple<int, string>(200, "Record Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("DeleteProductCategoryDetails :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, ProductCategoryDetailsModel>> GetProductCategoryDetailsId(Guid id)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductCategoryDetails
                      .Select(z => new ProductCategoryDetailsModel
                      {
                          Id = z.Id,
                          ProductCategoryName = z.ProductCategoryName,
                          ProductCategoryDescription = z.ProductCategoryDescription,
                          IsActive = z.IsActive
                      }).FirstOrDefaultAsync(x => x.Id == id);

                    if (res == null)
                    {
                        return new Tuple<int, ProductCategoryDetailsModel>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, ProductCategoryDetailsModel>(200, res);
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetProductCategoryDetailsId :: 500 :: " + ex.Message);
                return new Tuple<int, ProductCategoryDetailsModel>(500, null);
            }
        }

        public async Task<Tuple<int, List<ProductCategoryDetailsModel>>> GetAllProductCategoryDetails(bool? isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    List<ProductCategoryDetailsModel> lstModels = new List<ProductCategoryDetailsModel>();
                    if (isActive == null)
                    {
                        lstModels = await dbContext.ProductCategoryDetails
                            .Select(z => new ProductCategoryDetailsModel
                            {
                                Id = z.Id,
                                ProductCategoryName = z.ProductCategoryName,
                                ProductCategoryDescription = z.ProductCategoryDescription,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                    }
                    else
                    {

                        lstModels = await dbContext.ProductCategoryDetails
                             .Where(x => x.IsActive == isActive)
                            .Select(z => new ProductCategoryDetailsModel
                            {
                                Id = z.Id,
                                ProductCategoryName = z.ProductCategoryName,
                                ProductCategoryDescription = z.ProductCategoryDescription,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                    }

                    if (lstModels.Count == 0)
                    {
                        return new Tuple<int, List<ProductCategoryDetailsModel>>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, List<ProductCategoryDetailsModel>>(200, lstModels);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllProductCategoryDetails :: 500 :: " + ex.Message);
                return new Tuple<int, List<ProductCategoryDetailsModel>>(500, null);
            }
        }

        public async Task<bool> ProductCategoryAlreadyExist(string productCategoryName)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductCategoryDetails.Where(x => x.ProductCategoryName == productCategoryName && x.IsActive == true).CountAsync();
                    if (res > 0) return true;
                    return false;

                }
            }
            catch (Exception ex)
            {
                Log.Error("ProductCategoryAlreadyExist :: 500 :: " + ex.Message);
                return true;
            }
        }

        public async Task<Tuple<int, string>> UploadExcel(List<ProductCategoryDetailsModel> objProductCategoryDetailsModel, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var productCategoryList = new List<ProductCategoryDetail>(); string ErrorMessage = "";

                    int rowIndex = 0;
                    foreach (var item in objProductCategoryDetailsModel)
                    {
                        rowIndex++; var proCatetory = new object();

                        if (string.IsNullOrEmpty(item.ProductCategoryName))
                            ErrorMessage += "In Row " + rowIndex + " Product Category Name should not be blank.\n";
                        else
                        {
                            proCatetory = await dbContext.ProductCategoryDetails.Where(x => x.IsActive == true && x.ProductCategoryName == item.ProductCategoryName).FirstOrDefaultAsync();
                            if (proCatetory != null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductCategoryName + " already exists.\n";
                        }

                        if (string.IsNullOrEmpty(item.ProductCategoryDescription))
                            ErrorMessage += "In Row " + rowIndex + " Product Category Description should not be blank.\n";


                        productCategoryList.Add(new ProductCategoryDetail
                        {
                            Id = Guid.NewGuid(),
                            ProductCategoryName = item.ProductCategoryName,
                            ProductCategoryDescription = item.ProductCategoryDescription,
                            IsActive = true,
                            CreatedBy = userId,
                            CreatedDate = DateTime.Now
                        });

                        var duplicateCategoryName = productCategoryList.GroupBy(x => x.ProductCategoryName).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        if (proCatetory == null)
                        {
                            if (duplicateCategoryName.Count > 0)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductCategoryName + " already exists.\n";
                                productCategoryList.Clear();
                            }
                        }
                    }

                    if (ErrorMessage == "")
                    {
                        dbContext.ProductCategoryDetails.AddRange(productCategoryList);
                        await dbContext.SaveChangesAsync();
                        return new Tuple<int, string>(200, "Product Category Created Successfully");
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
    }
}
