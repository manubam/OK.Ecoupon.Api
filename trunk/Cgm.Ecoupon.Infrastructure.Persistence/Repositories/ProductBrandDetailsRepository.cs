using Cgm.Ecoupon.Domain.Product.ProductbrandDetails;
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
    public class ProductBrandDetailsRepository : IProductBrandDetailsRepository
    {
        private static readonly ILog Log =
         LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<bool> AddProductBrandDetails(string brandCode, string brandBName, string brandDescription, string alias, string userId, bool isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    ProductBrandDetail lmodel = new ProductBrandDetail
                    {
                        Id = Guid.NewGuid(),
                        ProductBrandCode = brandCode,
                        ProductBrandName = brandBName,
                        ProductBrandDescription = brandDescription,
                        ProductBrandAlieas = alias,
                        IsActive = isActive,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now
                    };

                    dbContext.ProductBrandDetails.Add(lmodel);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddProductBrandDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProductBrandDetails(Guid id, string brandCode, string brandBName, string brandDescription, string alias, string userId, bool isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductBrandDetails.FirstOrDefaultAsync(x => x.Id == id);
                    if (res == null)
                    {
                        return false;
                    }

                    res.ProductBrandCode = brandCode;
                    res.ProductBrandName = brandBName;
                    res.ProductBrandDescription = brandDescription;
                    res.ProductBrandAlieas = alias;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    res.IsActive = isActive;
                    dbContext.ProductBrandDetails.AddOrUpdate(res);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateProductBrandDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<Tuple<int, string>> DeleteProductBrandDetails(Guid id, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductBrandDetails.FirstOrDefaultAsync(x => x.Id == id);
                    if (res == null)
                    {
                        return new Tuple<int, string>(300, "Record not found");
                    }

                    var resProdDetails = await dbContext.ProductDetails.FirstOrDefaultAsync(x => x.ProductBrandId == id && x.IsActive == true);
                    if (resProdDetails != null)
                    {
                        return new Tuple<int, string>(300, res.ProductBrandName + " already used so cannot delete");
                    }

                    res.IsActive = false;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    dbContext.ProductBrandDetails.AddOrUpdate(res);

                    await dbContext.SaveChangesAsync();
                    return new Tuple<int, string>(200, "Record Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("DeleteProductBrandDetails :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, List<ProductBrandDetailModel>>> GetAllProductBrandDetails(bool? isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    List<ProductBrandDetailModel> lstModels = new List<ProductBrandDetailModel>();
                    if (isActive == null)
                    {
                        lstModels = await dbContext.ProductBrandDetails
                            .Select(z => new ProductBrandDetailModel
                            {
                                Id = z.Id,
                                ProductBrandCode = z.ProductBrandCode,
                                ProductBrandName = z.ProductBrandName,
                                ProductBrandDescription = z.ProductBrandDescription,
                                ProductBrandAlieas = z.ProductBrandAlieas,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                    }
                    else
                    {
                        lstModels = await dbContext.ProductBrandDetails
                            .Where(x => x.IsActive == isActive)
                            .Select(z => new ProductBrandDetailModel
                            {
                                Id = z.Id,
                                ProductBrandCode = z.ProductBrandCode,
                                ProductBrandName = z.ProductBrandName,
                                ProductBrandDescription = z.ProductBrandDescription,
                                ProductBrandAlieas = z.ProductBrandAlieas,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                    }



                    if (lstModels.Count == 0)
                    {
                        return new Tuple<int, List<ProductBrandDetailModel>>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, List<ProductBrandDetailModel>>(200, lstModels);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllProductBrandDetails :: 500 :: " + ex.Message);
                return new Tuple<int, List<ProductBrandDetailModel>>(500, null);
            }
        }

        public async Task<Tuple<int, ProductBrandDetailModel>> GetProductBrandDetailsById(Guid id)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductBrandDetails
                      .Select(z => new ProductBrandDetailModel
                      {
                          Id = z.Id,
                          ProductBrandCode = z.ProductBrandCode,
                          ProductBrandName = z.ProductBrandName,
                          ProductBrandDescription = z.ProductBrandDescription,
                          ProductBrandAlieas = z.ProductBrandAlieas,
                          IsActive = z.IsActive
                      }).FirstOrDefaultAsync(x => x.Id == id);

                    if (res == null)
                    {
                        return new Tuple<int, ProductBrandDetailModel>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, ProductBrandDetailModel>(200, res);
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetProductBrandDetailsById :: 500 :: " + ex.Message);
                return new Tuple<int, ProductBrandDetailModel>(500, null);
            }
        }

        public async Task<bool> ProductBrandAlreadyExist(string brandCode)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductBrandDetails.Where(x => x.ProductBrandCode == brandCode && x.IsActive == true).CountAsync();
                    if (res > 0) return true;
                    return false;

                }
            }
            catch (Exception ex)
            {
                Log.Error("ProductBrandAlreadyExist :: 500 :: " + ex.Message);
                return true;
            }
        }

        public async Task<bool> ProductBrandNameAlreadyExist(string brandName)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductBrandDetails.Where(x => x.ProductBrandName == brandName && x.IsActive == true).CountAsync();
                    if (res > 0) return true;
                    return false;

                }
            }
            catch (Exception ex)
            {
                Log.Error("ProductBrandAlreadyExist :: 500 :: " + ex.Message);
                return true;
            }
        }

        public async Task<Tuple<int, string>> UploadExcel(List<ProductBrandDetailModel> objProductBrandDetailModel, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var productBrandList = new List<ProductBrandDetail>(); string ErrorMessage = "";

                    int rowIndex = 0;
                    foreach (var item in objProductBrandDetailModel)
                    {
                        rowIndex++; var proBrandCode = new object(); var proBrandName = new object();

                        if (string.IsNullOrEmpty(item.ProductBrandCode))
                            ErrorMessage += "In Row " + rowIndex + " Product Brand Code should not be blank.\n";
                        else
                        {
                            proBrandCode = await dbContext.ProductBrandDetails.Where(x => x.IsActive == true && x.ProductBrandCode == item.ProductBrandCode).FirstOrDefaultAsync();
                            if (proBrandCode != null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductBrandCode + " already exists.\n";
                        }

                        if (string.IsNullOrEmpty(item.ProductBrandName))
                            ErrorMessage += "In Row " + rowIndex + " Product Brand Name should not be blank.\n";
                        else
                        {
                            proBrandName = await dbContext.ProductBrandDetails.Where(x => x.IsActive == true && x.ProductBrandName == item.ProductBrandName).FirstOrDefaultAsync();
                            if (proBrandName != null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductBrandName + " already exists.\n";
                        }

                        if (string.IsNullOrEmpty(item.ProductBrandDescription))
                            ErrorMessage += "In Row " + rowIndex + " Product Brand Description should not be blank.\n";

                        if (string.IsNullOrEmpty(item.ProductBrandAlieas))
                            ErrorMessage += "In Row " + rowIndex + " Product Brand Alieas should not be blank.\n";

                        productBrandList.Add(new ProductBrandDetail
                        {
                            Id = Guid.NewGuid(),
                            ProductBrandCode = item.ProductBrandCode,
                            ProductBrandName = item.ProductBrandName,
                            ProductBrandDescription = item.ProductBrandDescription,
                            ProductBrandAlieas = item.ProductBrandAlieas,
                            IsActive = true,
                            CreatedBy = userId,
                            CreatedDate = DateTime.Now
                        });

                        var duplicateBrandCode = productBrandList.GroupBy(x => x.ProductBrandCode).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        if (proBrandCode == null)
                        {
                            if (duplicateBrandCode.Count > 0)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductBrandCode + " already exists.\n";
                                productBrandList.Clear();
                            }
                        }

                        var duplicateBrandName = productBrandList.GroupBy(x => x.ProductBrandName).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        if (proBrandName == null)
                        {
                            if (duplicateBrandName.Count > 0)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductBrandName + " already exists.\n";
                                productBrandList.Clear();
                            }
                        }
                    }

                    if (ErrorMessage == "")
                    {
                        dbContext.ProductBrandDetails.AddRange(productBrandList);
                        await dbContext.SaveChangesAsync();

                        return new Tuple<int, string>(200, "Product Brand Created Successfully");
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
