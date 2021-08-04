using Cgm.Ecoupon.Domain.Product.ProductGroupDetails;
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
    //[assembly: log4net.Config.XmlConfigurator(Watch = true)]
    public class ProductGroupDetailsRepository : IProductGroupDetailsRepository
    {
        private static readonly ILog Log =
           LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public async Task<bool> AddProductGroupDetails(string productGroupName, string productGroupDescription, string userId, bool isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    ProductGroupDetail lModel = new ProductGroupDetail
                    {
                        Id = Guid.NewGuid(),
                        ProductGroupName = productGroupName,
                        ProductGroupDescription = productGroupDescription,
                        IsActive = isActive,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now
                    };

                    dbContext.ProductGroupDetails.Add(lModel);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddProductGroupDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProductGroupDetails(Guid id, string productGroupName, string productGroupDescription, string userId, bool isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductGroupDetails.FirstOrDefaultAsync(x => x.Id == id);
                    if (res == null)
                    {
                        return false;
                    }

                    res.ProductGroupName = productGroupName;
                    res.ProductGroupDescription = productGroupDescription;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    res.IsActive = isActive;
                    dbContext.ProductGroupDetails.AddOrUpdate(res);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateProductGroupDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<Tuple<int, string>> DeleteProductGroupDetails(Guid id, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductGroupDetails.FirstOrDefaultAsync(x => x.Id == id);
                    if (res == null)
                    {
                        return new Tuple<int, string>(300, "Record not found");
                    }

                    var resProdDetails = await dbContext.ProductDetails.FirstOrDefaultAsync(x => x.ProductGroupId == id && x.IsActive == true);
                    if (resProdDetails != null)
                    {
                        return new Tuple<int, string>(300, res.ProductGroupName + " already used so cannot delete");
                    }

                    res.IsActive = false;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    dbContext.ProductGroupDetails.AddOrUpdate(res);

                    await dbContext.SaveChangesAsync();
                    return new Tuple<int, string>(200, "Record Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("DeleteProductGroupDetails :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, ProductGroupDetailsModel>> GetProductGroupDetailsId(Guid id)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductGroupDetails
                      .Select(z => new ProductGroupDetailsModel
                      {
                          PoroductGroupId = z.Id,
                          ProductGroupName = z.ProductGroupName,
                          ProductGroupDescription = z.ProductGroupDescription,
                          IsActive = z.IsActive
                      }).FirstOrDefaultAsync(x => x.PoroductGroupId == id);

                    if (res == null)
                    {
                        return new Tuple<int, ProductGroupDetailsModel>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, ProductGroupDetailsModel>(200, res);
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetProductGroupDetailsId :: 500 :: " + ex.Message);
                return new Tuple<int, ProductGroupDetailsModel>(500, null);
            }
        }

        public async Task<Tuple<int, List<ProductGroupDetailsModel>>> GetAllProductGroupDetails(bool? isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    List<ProductGroupDetailsModel> lstModels = new List<ProductGroupDetailsModel>();
                    if (isActive == null)
                    {
                        lstModels = await dbContext.ProductGroupDetails
                            .Select(z => new ProductGroupDetailsModel
                            {
                                PoroductGroupId = z.Id,
                                ProductGroupName = z.ProductGroupName,
                                ProductGroupDescription = z.ProductGroupDescription,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                    }
                    else
                    {

                        lstModels = await dbContext.ProductGroupDetails
                             .Where(x => x.IsActive == isActive)
                            .Select(z => new ProductGroupDetailsModel
                            {
                                PoroductGroupId = z.Id,
                                ProductGroupName = z.ProductGroupName,
                                ProductGroupDescription = z.ProductGroupDescription,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                    }

                    if (lstModels.Count == 0)
                    {
                        return new Tuple<int, List<ProductGroupDetailsModel>>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, List<ProductGroupDetailsModel>>(200, lstModels);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllProductGroupDetails :: 500 :: " + ex.Message);
                return new Tuple<int, List<ProductGroupDetailsModel>>(500, null);
            }
        }

        public async Task<bool> ProductGroupAlreadyExist(string productGroupName)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.ProductGroupDetails.Where(x => x.ProductGroupName == productGroupName && x.IsActive == true).CountAsync();
                    if (res > 0) return true;
                    return false;

                }
            }
            catch (Exception ex)
            {
                Log.Error("ProductGroupAlreadyExist :: 500 :: " + ex.Message);
                return true;
            }
        }

        public async Task<Tuple<int, string>> UploadExcel(List<ProductGroupDetailsModel> objProductGroupDetailsModel, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var productGroupDetailList = new List<ProductGroupDetail>(); string ErrorMessage = "";

                    int rowIndex = 0;
                    foreach (var item in objProductGroupDetailsModel)
                    {
                        rowIndex++; var proGroup = new object();

                        if (string.IsNullOrEmpty(item.ProductGroupName))
                            ErrorMessage += "In Row " + rowIndex + " Product Group Name should not be blank.\n";
                        else
                        {
                            proGroup = await dbContext.ProductGroupDetails.Where(x => x.IsActive == true && x.ProductGroupName == item.ProductGroupName).FirstOrDefaultAsync();
                            if (proGroup != null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductGroupName + " already exists.\n";
                        }

                        if (string.IsNullOrEmpty(item.ProductGroupDescription))
                            ErrorMessage += "In Row " + rowIndex + " Product Group Description should not be blank.\n";


                        productGroupDetailList.Add(new ProductGroupDetail
                        {
                            Id = Guid.NewGuid(),
                            ProductGroupName = item.ProductGroupName,
                            ProductGroupDescription = item.ProductGroupDescription,
                            IsActive = true,
                            CreatedBy = userId,
                            CreatedDate = DateTime.Now
                        });

                        var duplicateGroupName = productGroupDetailList.GroupBy(x => x.ProductGroupName).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        if (proGroup == null)
                        {
                            if (duplicateGroupName.Count > 0)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.ProductGroupName + " already exists.\n";
                                productGroupDetailList.Clear();
                            }
                        }
                    }

                    if (ErrorMessage == "")
                    {
                        dbContext.ProductGroupDetails.AddRange(productGroupDetailList);
                        await dbContext.SaveChangesAsync();
                        return new Tuple<int, string>(200, "Product Group Created Successfully");
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
