using Cgm.Ecoupon.Domain.Branch;
using Cgm.Ecoupon.Domain.CompanyAndProductMapping;
using Cgm.Ecoupon.Domain.Product.ProductbrandDetails;
using Cgm.Ecoupon.Domain.Product.ProductCategoryDetails;
using Cgm.Ecoupon.Domain.Product.ProductDetails;
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
    public class CompanyProductMappingRepository : ICompanyProductMappingRepository
    {
        private static readonly ILog Log =
        LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<Tuple<int, string>> AddCompanyAndProductMapping(Guid companyId, List<Guid> branchIdList, List<Guid> productIdList, string createdUserId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    Guid[] branchIdArrayList = branchIdList.ToArray();

                    var resBranchList = await (from br in dbContext.BranchDetails
                                               where branchIdArrayList.Contains(br.Id)
                                               select br).ToListAsync();


                    if (resBranchList != null)
                    {
                        if (resBranchList.Count != branchIdArrayList.Count())
                        {
                            return new Tuple<int, string>(300, "Invalid branch id found, please check");
                        }
                    }
                    foreach (var branchId in branchIdList)
                    {
                        Guid[] productId = productIdList.ToArray();

                        var res = await (from pd in dbContext.ProductDetails
                                         where productId.Contains(pd.Id)
                                         select pd).ToListAsync();
                        if (res != null)
                        {
                            if (res.Count() == productIdList.Count)
                            {
                                var resAddCompanyAndProductMapping =
                                    await AddCompanyAndProductMappingSummarry(companyId, branchId, createdUserId);
                                if (resAddCompanyAndProductMapping.Item1 != 200) return new Tuple<int, string>(resAddCompanyAndProductMapping.Item1, resAddCompanyAndProductMapping.Item2);

                                return
                                    await
                                        AddCompanyAndProductMappingDetails(resAddCompanyAndProductMapping.Item3, res,
                                            createdUserId);
                            }
                            else
                            {
                                return new Tuple<int, string>(300, "Invalid Product id found");
                            }
                        }
                        else
                        {
                            return new Tuple<int, string>(300, "Invalid Product id");
                        }
                    }
                    return new Tuple<int, string>(300, "Invalid, please contact admin");
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddCompanyAndProductMapping :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error");
            }
        }

        public async Task<Tuple<int, string, Guid>> AddCompanyAndProductMappingSummarry(Guid companyId, Guid branchId, string createdUserId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyAndProductMappingSummarries.Where(x => x.IsActive == true
                                                                      && x.CompanyId == companyId &&
                                                                      x.BranchId == branchId).CountAsync();
                    if (res != 0)
                    {
                        return new Tuple<int, string, Guid>(300, "Data Already Exist", Guid.Empty);
                    }


                    CompanyAndProductMappingSummarry lDetail = new CompanyAndProductMappingSummarry
                    {
                        Id = Guid.NewGuid(),
                        CompanyId = companyId,
                        BranchId = branchId,
                        IsActive = true,
                        CreatedBy = createdUserId,
                        CreatedDate = DateTime.Now
                    };

                    dbContext.CompanyAndProductMappingSummarries.Add(lDetail);
                    await dbContext.SaveChangesAsync();
                    return new Tuple<int, string, Guid>(200, "Success", lDetail.Id);
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddCompanyAndProductMapping :: 500 :: " + ex.Message);
                return new Tuple<int, string, Guid>(500, "System Error", new Guid());
            }
        }


        public async Task<Tuple<int, string>> AddCompanyAndProductMappingDetails(Guid productMappingId, List<ProductDetail> productList, string createdUserId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    foreach (var obj in productList)
                    {
                        CompanyAndProductMappingDetail lDetail = new CompanyAndProductMappingDetail
                        {
                            Id = Guid.NewGuid(),
                            CompanyProductMappingId = productMappingId,
                            ProductGroupId = obj.ProductGroupId,
                            ProductCategoryId = obj.ProductCategoryId,
                            ProductBrandId = obj.ProductBrandId,
                            ProductId = obj.Id,
                            IsActive = true,
                            CreatedBy = createdUserId,
                            CreatedDate = DateTime.Now
                        };
                        dbContext.CompanyAndProductMappingDetails.Add(lDetail);
                    }

                    await dbContext.SaveChangesAsync();
                    return new Tuple<int, string>(200, "Company and Product Mapping Created Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddProductMapping :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error");
            }
        }

        public async Task<Tuple<int, string>> UpdateCompanyAndProductMapping(Guid companyAndProductMappingId, List<Guid> productIdList, string createdUserId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    Guid[] productId = productIdList.ToArray();

                    var res = await (from pd in dbContext.ProductDetails
                                     where productId.Contains(pd.Id)
                                     select pd).ToListAsync();
                    if (res != null)
                    {
                        if (res.Count() == productIdList.Count)
                        {
                            var resMappingSummary =
                               await dbContext.CompanyAndProductMappingSummarries.Where(
                                    x => x.Id == companyAndProductMappingId).FirstOrDefaultAsync();
                            if (resMappingSummary != null)
                            {
                                var resDeleteProductMappingSummarryDetails =
                              await DeleteProductMappingSummarryDetails(companyAndProductMappingId, createdUserId);

                                if (resDeleteProductMappingSummarryDetails.Item1 != 200)
                                    return resDeleteProductMappingSummarryDetails;
                                return
                                    await
                                        AddCompanyAndProductMappingDetails(companyAndProductMappingId, res,
                                            createdUserId);
                            }
                            else
                            {
                                return new Tuple<int, string>(300, "Invalid CompanyAndProductMappingId");
                            }

                        }
                        else
                        {
                            return new Tuple<int, string>(300, "Invalid Product id found");
                        }
                    }
                    else
                    {
                        return new Tuple<int, string>(300, "Invalid Product id");
                    }


                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateCompanyAndProductMapping :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error");
            }
        }

        public async Task<Tuple<int, string>> DeleteProductMappingSummarryDetails(Guid id, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var resMappingDetails =
                                   await
                                       dbContext.CompanyAndProductMappingDetails.Where(
                                           x => x.CompanyProductMappingId == id).ToListAsync();
                    if (resMappingDetails != null)
                    {
                        foreach (var obj in resMappingDetails)
                        {
                            obj.IsActive = false;
                            obj.ModifiedBy = userId;
                            obj.ModifiedDate = DateTime.Now;
                            dbContext.CompanyAndProductMappingDetails.AddOrUpdate(obj);
                        }
                        await dbContext.SaveChangesAsync();
                    }
                    return new Tuple<int, string>(200, "Success");
                }
            }
            catch (Exception ex)
            {
                Log.Error("DeleteProductMappingSummarryDetails :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error");
            }
        }

        public async Task<Tuple<int, string, List<BranchModel>>> GatBranchByCompanyId(Guid companyId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var resMappingDetails =
                                   await
                                       dbContext.BranchDetails.Where(
                                           x => x.Id == companyId && x.IsActive == true)
                                           .Select(z => new BranchModel
                                           {
                                               BranchId = z.Id,
                                               CompanyId = z.CompanyId,
                                               BranchBName = z.BranchBName,
                                               BranchName = z.BranchName,
                                               Description = z.Description,
                                               BDescription = z.BDescription
                                           }).OrderBy(z => z.BranchName).ToListAsync();

                    if (resMappingDetails.Count > 0)
                    {
                        return new Tuple<int, string, List<BranchModel>>(200, "Success", resMappingDetails);
                    }
                    else
                    {
                        return new Tuple<int, string, List<BranchModel>>(300, "No Data Found", new List<BranchModel>());
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByCompanyId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<BranchModel>>(500, "System Error", new List<BranchModel>());
            }
        }

        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GatProductByFilters(List<Guid> productGroupListId, List<Guid> productBrandListId, List<Guid> productCategoryListId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    Guid[] productGroupArrayListId = productGroupListId.ToArray();
                    Guid[] productBrandArrayListId = productBrandListId.ToArray();
                    Guid[] productCategoryArrayListId = productCategoryListId.ToArray();

                    var resProducts = await (from pd in dbContext.ProductDetails
                                             where productGroupArrayListId.Contains(pd.ProductGroupId)
                                             && productBrandArrayListId.Contains(pd.ProductBrandId)
                                             && productCategoryArrayListId.Contains(pd.ProductCategoryId)
                                             && pd.IsActive == true && pd.ProductGroupDetail.IsActive == true && pd.ProductBrandDetail.IsActive == true && pd.ProductCategoryDetail.IsActive == true
                                             select new ProductDetailsModel { ProductId = pd.Id, ProductName = pd.ProductName, IsActive = pd.IsActive }).ToListAsync();

                    if (resProducts.Count > 0)
                    {
                        return new Tuple<int, string, List<ProductDetailsModel>>(200, "Success", resProducts);
                    }
                    else
                    {
                        return new Tuple<int, string, List<ProductDetailsModel>>(300, "No Data Found",
                            new List<ProductDetailsModel>());
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GatProductByFilters :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductDetailsModel>>(500, "System Error", new List<ProductDetailsModel>());
            }
        }


        //public async Task<Tuple<int, string, List<ProductMappingModel>>> GetDashBordProdMapInfo(int status)
        //{
        //    try
        //    {
        //        using (var dbContext = new OfferManagementEntities())
        //        {
        //            var response =
        //                await dbContext.CompanyAndProductMappingSummarries.Where(x => x.IsActive == true).ToListAsync();

        //            //Get all the stories 



        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("GetDashBordProdMapInfo :: 500 :: " + ex.Message);
        //        return new Tuple<int, string, List<ProductMappingModel>>(500, "System Error", new List<ProductMappingModel>());
        //    }
        //} 

        public async Task<Tuple<int, string, List<CompanyAndProductMapping>>> GetCompanyAndProductMappingList()
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var resMappingDetails =
                                   await
                                       dbContext.CompanyAndProductMappingSummarries.Where(
                                           x => x.IsActive == true)
                                           .Select(z => new CompanyAndProductMapping
                                           {
                                               Id = z.Id,
                                               CompanyId = z.CompanyId,
                                               BranchId = z.BranchId,
                                               CompanyName = z.CompanyDetail.CompanyName,
                                               BranchName = z.BranchDetail.BranchName
                                           }).OrderBy(z => z.CompanyName).ToListAsync();
                    if (resMappingDetails.Count > 0)
                    {
                        foreach (var item in resMappingDetails)
                        {
                            var res =
                                await
                                    dbContext.CompanyAndProductMappingDetails.Where(
                                        x => x.IsActive == true && x.CompanyProductMappingId == item.Id).Select(z => new CompanyAndProductMappingDetails
                                        {
                                            Id = z.Id,
                                            CompanyAndProductMappingSummarryId = z.CompanyProductMappingId,
                                            ProductGroupId = z.ProductGroupId,
                                            ProductCategoryId = z.ProductCategoryId,
                                            ProductBrandId = z.ProductBrandId,
                                            ProductId = z.ProductId,
                                            ProductGroupName = z.ProductGroupDetail.ProductGroupName,
                                            ProductCategoryName = z.ProductCategoryDetail.ProductCategoryName,
                                            ProductBrandName = z.ProductBrandDetail.ProductBrandName,
                                            ProductName = z.ProductDetail.ProductName
                                        }).ToListAsync();
                            if (res != null)
                            {
                                item.ProductGroupCount = res.Count;
                                item.CompanyAndProductMappingDetailList = res;

                            }
                            //else
                            //{
                            //    item.ProductGroupCount = 0;
                            //    return new Tuple<int, string, List<CompanyAndProductMapping>>(200, "Success", resMappingDetails);
                            //}
                        }
                        return new Tuple<int, string, List<CompanyAndProductMapping>>(200, "Success", resMappingDetails);
                        //return new Tuple<int, string, List<CompanyAndProductMapping>>(300, "No Data Found", new List<CompanyAndProductMapping>());

                    }
                    else
                    {
                        return new Tuple<int, string, List<CompanyAndProductMapping>>(300, "No Data Found", new List<CompanyAndProductMapping>());
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetCompanyAndProductMappingSummarry :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<CompanyAndProductMapping>>(500, "System Error", new List<CompanyAndProductMapping>());
            }
        }

        public async Task<Tuple<int, string, CompanyAndProductMapping>> GetCompanyAndProductMappingById(Guid id)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var resMappingDetails =
                        await
                            dbContext.CompanyAndProductMappingSummarries.Where(
                                x => x.IsActive == true && x.Id == id)
                                .Select(z => new CompanyAndProductMapping
                                {
                                    Id = z.Id,
                                    CompanyId = z.CompanyId,
                                    BranchId = z.BranchId,
                                    CompanyName = z.CompanyDetail.CompanyBName,
                                    BranchName = z.BranchDetail.BranchBName
                                }).FirstOrDefaultAsync();
                    if (resMappingDetails != null)
                    {

                        var res =
                            await
                                dbContext.CompanyAndProductMappingDetails.Where(
                                    x => x.IsActive == true && x.CompanyProductMappingId == resMappingDetails.Id).Select(z => new CompanyAndProductMappingDetails
                                    {
                                        Id = z.Id,
                                        CompanyAndProductMappingSummarryId = z.CompanyProductMappingId,
                                        ProductGroupId = z.ProductGroupId,
                                        ProductCategoryId = z.ProductCategoryId,
                                        ProductBrandId = z.ProductBrandId,
                                        ProductId = z.ProductId,
                                        ProductGroupName = z.ProductGroupDetail.ProductGroupName,
                                        ProductCategoryName = z.ProductCategoryDetail.ProductCategoryName,
                                        ProductBrandName = z.ProductBrandDetail.ProductBrandName,
                                        ProductName = z.ProductDetail.ProductName
                                    }).ToListAsync();

                        var resBranch =
                                 await
                                     dbContext.CompanyAndProductMappingSummarries.Where(
                                         x => x.IsActive == true && x.CompanyId == resMappingDetails.CompanyId).Select(z => new CompanyAndProductMappingSummarryBranch
                                         {
                                             BranchId = z.BranchId
                                         }).ToListAsync();

                        if (res != null)
                        {
                            resMappingDetails.ProductGroupCount = res.Count;
                            resMappingDetails.CompanyAndProductMappingDetailList = res;
                            resMappingDetails.BranchList = resBranch;
                            return new Tuple<int, string, CompanyAndProductMapping>(200, "Success", resMappingDetails);
                        }
                        else
                        {
                            resMappingDetails.ProductGroupCount = 0;
                            return new Tuple<int, string, CompanyAndProductMapping>(200, "Success", resMappingDetails);
                        }

                    }
                    else
                    {
                        return new Tuple<int, string, CompanyAndProductMapping>(300, "No Data Found", new CompanyAndProductMapping());
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetCompanyAndProductMappingSummarry :: 500 :: " + ex.Message);
                return new Tuple<int, string, CompanyAndProductMapping>(500, "System Error", new CompanyAndProductMapping());
            }
        }

        public async Task<Tuple<int, string, List<ProductGroupDetailsModel>>> GetProductGroupByCompanyIdandBranchId(Guid companyId, Guid branchId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyAndProductMappingSummarries.Where(x => x.CompanyId == companyId && x.BranchId == branchId && x.IsActive == true).FirstOrDefaultAsync();

                    if (res != null)
                    {
                        var resMappingDetails =
                                       await
                                           dbContext.CompanyAndProductMappingDetails.Where(
                                               x => x.CompanyProductMappingId == res.Id && x.IsActive == true)
                                               .Select(z => new ProductGroupDetailsModel
                                               {
                                                   PoroductGroupId = z.ProductGroupId,
                                                   ProductGroupName = z.ProductGroupDetail.ProductGroupName,
                                                   ProductGroupDescription = z.ProductGroupDetail.ProductGroupDescription,
                                                   IsActive = z.IsActive
                                               }).OrderBy(z => z.ProductGroupName).Distinct().ToListAsync();

                        return new Tuple<int, string, List<ProductGroupDetailsModel>>(200, "Success", resMappingDetails);
                    }

                    return new Tuple<int, string, List<ProductGroupDetailsModel>>(300, "No Data Found", new List<ProductGroupDetailsModel>());

                }
            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByCompanyId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductGroupDetailsModel>>(500, "System Error", new List<ProductGroupDetailsModel>());
            }
        }

        public async Task<Tuple<int, string, List<ProductGroupDetailsModel>>> GetProductGroupByCompanyId(Guid companyId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyAndProductMappingSummarries.Where(x => x.CompanyId == companyId && x.IsActive == true).FirstOrDefaultAsync();

                    if (res != null)
                    {
                        var resMappingDetails =
                                       await
                                           dbContext.CompanyAndProductMappingDetails.Where(
                                               x => x.CompanyProductMappingId == res.Id && x.IsActive == true)
                                               .Select(z => new ProductGroupDetailsModel
                                               {
                                                   PoroductGroupId = z.ProductGroupId,
                                                   ProductGroupName = z.ProductGroupDetail.ProductGroupName,
                                                   ProductGroupDescription = z.ProductGroupDetail.ProductGroupDescription,
                                                   IsActive = z.IsActive
                                               }).OrderBy(z => z.ProductGroupName).Distinct().ToListAsync();

                        return new Tuple<int, string, List<ProductGroupDetailsModel>>(200, "Success", resMappingDetails);
                    }

                    return new Tuple<int, string, List<ProductGroupDetailsModel>>(300, "No Data Found", new List<ProductGroupDetailsModel>());

                }
            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByCompanyId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductGroupDetailsModel>>(500, "System Error", new List<ProductGroupDetailsModel>());
            }
        }

        public async Task<Tuple<int, string, List<ProductBrandDetailModel>>> GetProductBrandByCompanyId(Guid companyId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyAndProductMappingSummarries.Where(x => x.CompanyId == companyId && x.IsActive == true).FirstOrDefaultAsync();

                    if (res != null)
                    {
                        var resMappingDetails =
                                       await
                                           dbContext.CompanyAndProductMappingDetails.Where(
                                               x => x.CompanyProductMappingId == res.Id && x.IsActive == true)
                                               .Select(z => new ProductBrandDetailModel
                                               {
                                                   Id = z.ProductBrandId,
                                                   ProductBrandName = z.ProductBrandDetail.ProductBrandName,
                                                   IsActive = z.IsActive
                                               }).OrderBy(z => z.ProductBrandName).Distinct().ToListAsync();

                        return new Tuple<int, string, List<ProductBrandDetailModel>>(200, "Success", resMappingDetails);
                    }

                    return new Tuple<int, string, List<ProductBrandDetailModel>>(300, "No Data Found", new List<ProductBrandDetailModel>());

                }
            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByCompanyId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductBrandDetailModel>>(500, "System Error", new List<ProductBrandDetailModel>());
            }
        }

        public async Task<Tuple<int, string, List<ProductCategoryDetailsModel>>> GetProductCategoryByCompanyId(Guid companyId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyAndProductMappingSummarries.Where(x => x.CompanyId == companyId && x.IsActive == true).FirstOrDefaultAsync();

                    if (res != null)
                    {
                        var resMappingDetails =
                                       await
                                           dbContext.CompanyAndProductMappingDetails.Where(
                                               x => x.CompanyProductMappingId == res.Id && x.IsActive == true)
                                               .Select(z => new ProductCategoryDetailsModel
                                               {
                                                   Id = z.ProductCategoryId,
                                                   ProductCategoryName = z.ProductCategoryDetail.ProductCategoryName,
                                                   IsActive = z.IsActive
                                               }).OrderBy(z => z.ProductCategoryName).Distinct().ToListAsync();

                        return new Tuple<int, string, List<ProductCategoryDetailsModel>>(200, "Success", resMappingDetails);
                    }

                    return new Tuple<int, string, List<ProductCategoryDetailsModel>>(300, "No Data Found", new List<ProductCategoryDetailsModel>());

                }
            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByCompanyId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductCategoryDetailsModel>>(500, "System Error", new List<ProductCategoryDetailsModel>());
            }
        }

        public async Task<Tuple<int, string, List<ProductDetailsModel>>> GetProductDetailsByCompanyId(Guid companyId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyAndProductMappingSummarries.Where(x => x.CompanyId == companyId && x.IsActive == true).FirstOrDefaultAsync();

                    if (res != null)
                    {
                        var resMappingDetails =
                                       await
                                           dbContext.CompanyAndProductMappingDetails.Where(
                                               x => x.CompanyProductMappingId == res.Id && x.IsActive == true)
                                               .Select(z => new ProductDetailsModel
                                               {
                                                   ProductId = z.ProductId,
                                                   ProductName = z.ProductDetail.ProductName,
                                                   IsActive = z.IsActive
                                               }).OrderBy(z => z.ProductName).Distinct().ToListAsync();

                        return new Tuple<int, string, List<ProductDetailsModel>>(200, "Success", resMappingDetails);
                    }

                    return new Tuple<int, string, List<ProductDetailsModel>>(300, "No Data Found", new List<ProductDetailsModel>());

                }
            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByCompanyId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<ProductDetailsModel>>(500, "System Error", new List<ProductDetailsModel>());
            }
        }

    }
}
