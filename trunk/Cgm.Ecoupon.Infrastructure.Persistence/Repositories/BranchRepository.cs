using Cgm.Ecoupon.Domain.Branch;
using Cgm.Ecoupon.Infrastructure.Persistence.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Cgm.Ecoupon.Infrastructure.Persistence.Repositories
{
    
    public class BranchRepository : IBranchRepository
    {
        private static readonly ILog Log =
          LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public async Task<Tuple<int, string, List<DivisionModel>>> GetAllDivisionList()
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await dbContext.Divisions
                        .Where(x => x.Is_Active == true)
                        .Select(z => new DivisionModel
                        {
                            DivisionId = z.ID,
                            Name = z.Name,
                            BName = z.BName,
                            Code = z.Code
                        }).OrderBy(z => z.Name).ToListAsync();
                    if (res != null)
                    {
                        if (res.Count > 0)
                        {
                            return new Tuple<int, string, List<DivisionModel>>(200, "Success", res);
                        }
                    }
                    return new Tuple<int, string, List<DivisionModel>>(300, "No Data Found", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllDivisionList :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<DivisionModel>>(500, "System Error Contact Admin",
                    new List<DivisionModel>());
            }
        }

        public async Task<Tuple<int, string, List<TownShipModel>>> GetAllTownShipList()
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await dbContext.TownShips
                        .Where(x => x.Is_Active == true)
                        .Select(z => new TownShipModel()
                        {
                            TownShipId = z.ID,
                            DivisionId = z.DivisionID,
                            Name = z.Name,
                            BurmeseName = z.BurmeseName,
                            Code = z.Code
                        }).OrderBy(z => z.Name).ToListAsync();
                    if (res != null)
                    {
                        if (res.Count > 0)
                        {
                            return new Tuple<int, string, List<TownShipModel>>(200, "Success", res);
                        }
                    }
                    return new Tuple<int, string, List<TownShipModel>>(300, "No Data Found", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllTownShipList :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<TownShipModel>>(500, "System Error Contact Admin",
                    new List<TownShipModel>());
            }
        }

        public async Task<Tuple<int, string, List<TownShipModel>>> GetTownShipByDivisionId(Guid divisionId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await dbContext.TownShips
                        .Where(x => x.Is_Active == true && x.DivisionID == divisionId)
                        .Select(z => new TownShipModel()
                        {
                            TownShipId = z.ID,
                            DivisionId = z.DivisionID,
                            Name = z.Name,
                            BurmeseName = z.BurmeseName,
                            Code = z.Code
                        }).OrderBy(z => z.Name).ToListAsync();
                    if (res != null)
                    {
                        if (res.Count > 0)
                        {
                            return new Tuple<int, string, List<TownShipModel>>(200, "Success", res);
                        }
                    }
                    return new Tuple<int, string, List<TownShipModel>>(300, "No Data Found", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetTownShipByDivisionId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<TownShipModel>>(500, "System Error Contact Admin",
                    new List<TownShipModel>());
            }
        }

        public async Task<Tuple<int, string, List<CityModel>>> GetCityByTownShipId(Guid townShipId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await dbContext.Cities
                        .Where(x => x.IsActive == true && x.TownShipId == townShipId)
                        .Select(z => new CityModel()
                        {
                            CityId = z.Id,
                            TownShipId = z.TownShipId,
                            Name = z.Name,
                            BurmeseName = z.BurmeseName,
                            Code = z.Code
                        }).OrderBy(z => z.Name).ToListAsync();
                    if (res != null)
                    {
                        if (res.Count > 0)
                        {
                            return new Tuple<int, string, List<CityModel>>(200, "Success", res);
                        }
                    }
                    return new Tuple<int, string, List<CityModel>>(300, "No Data Found", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetCityByTownShipId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<CityModel>>(500, "System Error Contact Admin",
                    new List<CityModel>());
            }
        }

        public async Task<Tuple<int, string, List<DistrictModel>>> GetDistrictByTownShipId(Guid townShipId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await dbContext.Districts
                        .Where(x => x.IsActive == true && x.TownShipId == townShipId)
                        .Select(z => new DistrictModel()
                        {
                            DistrictId = z.Id,
                            TownShipId = z.TownShipId,
                            Name = z.Name,
                            BurmeseName = z.BurmeseName,
                            Code = z.Code
                        }).OrderBy(z => z.Name).ToListAsync();
                    if (res != null)
                    {
                        if (res.Count > 0)
                        {
                            return new Tuple<int, string, List<DistrictModel>>(200, "Success", res);
                        }
                    }
                    return new Tuple<int, string, List<DistrictModel>>(300, "No Data Found", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetDistrictByTownShipId :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<DistrictModel>>(500, "System Error Contact Admin",
                    new List<DistrictModel>());
            }
        }
        public async Task<Tuple<int, string>> AddBranch(Guid companyId, Guid divisionId, Guid townShipId, Guid? cityId, Guid? districtId, string branchName, string branchBName, string description, string bDescription, string createdUserId, List<BranchMobileNumberModel> lstBranchMobileNumberModels)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var resIsValidBranch =
                        await BranchAlreadyExist(companyId, divisionId, townShipId, cityId, districtId, branchBName);

                    if (resIsValidBranch.Item1 != 200) return resIsValidBranch;

                    BranchDetail lBranchDetail = new BranchDetail
                    {
                        Id = Guid.NewGuid(),
                        CompanyId = companyId,
                        DivisionId = divisionId,
                        TownShipId = townShipId,
                        CityId = cityId,
                        DistrictId = districtId,
                        BranchName = branchName,
                        BranchBName = branchBName,
                        Description = description,
                        BDescription = bDescription,
                        IsActive = true,
                        CreatedBy = createdUserId,
                        CreatedDate = DateTime.Now
                    };
                    dbContext.BranchDetails.Add(lBranchDetail);

                    foreach (var branchMobileNumberDetail in lstBranchMobileNumberModels.Select(obj => new BranchMobileNumberDetail
                    {
                        Id = Guid.NewGuid(),
                        BranchId = lBranchDetail.Id,
                        BranchReceiverName = obj.BranchReceiverName,
                        BranchReceiverMobileNumber = obj.BranchReceiverMobileNumber,
                        IsActive = true,
                        CreatedBy = createdUserId,
                        CreatedDate = DateTime.Now
                    }))
                    {
                        dbContext.BranchMobileNumberDetails.Add(branchMobileNumberDetail);
                    }
                    await dbContext.SaveChangesAsync();

                    return new Tuple<int, string>(200, "Branch Created Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddBranch :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, string>> UpdateBranch(Guid branchId, Guid companyId, Guid divisionId, Guid townShipId, Guid? cityId, Guid? districtId, string branchName, string branchBName, string description, string bDescription, string createdUserId, List<BranchMobileNumberModel> lstBranchMobileNumberModels)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await dbContext.BranchDetails.Where(x => x.Id == branchId).FirstOrDefaultAsync();
                    if (res == null) return new Tuple<int, string>(300, "Invalid branchId");

                    var resIsValidBranch =
                        await IsValidBranchForUpdate(branchId, companyId, divisionId, townShipId, cityId, districtId, branchBName);

                    if (resIsValidBranch.Item1 != 200) return resIsValidBranch;

                    res.CompanyId = companyId;
                    res.DivisionId = divisionId;
                    res.TownShipId = townShipId;
                    res.CityId = cityId;
                    res.DistrictId = districtId;
                    res.BranchName = branchName;
                    res.BranchBName = branchBName;
                    res.Description = description;
                    res.BDescription = bDescription;
                    res.ModifiedBy = createdUserId;
                    res.ModifiedDate = DateTime.Now;
                    dbContext.BranchDetails.AddOrUpdate(res);
                    await dbContext.SaveChangesAsync();

                    var resbranchMobileNumberList = await dbContext.BranchMobileNumberDetails.Where(x => x.BranchId == branchId).ToListAsync();

                    foreach (var item in resbranchMobileNumberList)
                    {
                        item.IsActive = false;
                        dbContext.BranchMobileNumberDetails.AddOrUpdate(item);
                    }
                    await dbContext.SaveChangesAsync();

                    foreach (var item in lstBranchMobileNumberModels)
                    {
                        bool existFlag = resbranchMobileNumberList.Any(obj => obj.Id == item.BranchMobileNumberId);
                        if (existFlag == true)
                        {
                            var resItem =
                                await
                                    dbContext.BranchMobileNumberDetails.Where(x => x.Id == item.BranchMobileNumberId)
                                        .FirstOrDefaultAsync();
                            if (resItem != null)
                            {
                                resItem.BranchReceiverMobileNumber = item.BranchReceiverMobileNumber;
                                resItem.BranchReceiverName = item.BranchReceiverName;
                                resItem.IsActive = item.IsActive;
                                resItem.ModifiedBy = createdUserId;
                                resItem.ModifiedDate = DateTime.Now;
                                dbContext.BranchMobileNumberDetails.AddOrUpdate(resItem);
                            }
                            await dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            var resItem = new BranchMobileNumberDetail
                            {
                                Id = Guid.NewGuid(),
                                BranchId = item.BranchId,
                                BranchReceiverName = item.BranchReceiverName,
                                BranchReceiverMobileNumber = item.BranchReceiverMobileNumber,
                                IsActive = true,
                                CreatedBy = createdUserId,
                                CreatedDate = DateTime.Now
                            };
                            dbContext.BranchMobileNumberDetails.Add(resItem);
                            await dbContext.SaveChangesAsync();
                        }
                    }

                    return new Tuple<int, string>(200, "Branch Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateBranch :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, string>> DeleteBranch(Guid branchId, string createdUserId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await dbContext.BranchDetails.Where(x => x.Id == branchId).FirstOrDefaultAsync();
                    if (res == null) return new Tuple<int, string>(300, "Invalid branchId");

                    var resCompAndProd = await dbContext.CompanyAndProductMappingSummarries.FirstOrDefaultAsync(x => x.BranchId == branchId && x.IsActive == true);
                    if (resCompAndProd != null)
                    {
                        return new Tuple<int, string>(300, res.BranchName + " already used so cannot delete");
                    }

                    res.IsActive = false;
                    res.ModifiedBy = createdUserId;
                    res.ModifiedDate = DateTime.Now;
                    dbContext.BranchDetails.AddOrUpdate(res);

                    var resbranchMobileNumberList = await dbContext.BranchMobileNumberDetails.Where(x => x.IsActive == true && x.BranchId == branchId).ToListAsync();

                    foreach (var item in resbranchMobileNumberList)
                    {
                        item.IsActive = false;
                        item.ModifiedBy = createdUserId;
                        item.ModifiedDate = DateTime.Now;
                        dbContext.BranchMobileNumberDetails.AddOrUpdate(item);
                    }
                    await dbContext.SaveChangesAsync();

                    return new Tuple<int, string>(200, "Branch Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("DeleteBranch :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, string, List<BranchModel>>> GetAllBranch(bool? isActive = null)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    if (isActive != null)
                    {
                        var res = await dbContext.BranchDetails.Where(x => x.IsActive == isActive)
                            .Select(z => new BranchModel
                            {
                                BranchId = z.Id,
                                CompanyId = z.CompanyId,
                                DivisionId = z.DivisionId,
                                TownShipId = z.TownShipId,
                                CityId = z.CityId,
                                DistrictId = z.DistrictId,
                                BranchName = z.BranchName,
                                BranchBName = z.BranchBName,
                                Description = z.Description,
                                BDescription = z.BDescription,
                                CompanyName = z.CompanyDetail.CompanyName,
                                DivisionName = z.Division.Name,
                                TownShipName = z.TownShip.Name,
                                CityName = z.City.Name,
                                DistrictName = z.District.Name,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                        foreach (var obj in res)
                        {
                            var resObj =
                                await dbContext.BranchMobileNumberDetails.Where(x => x.BranchId == obj.BranchId && x.IsActive == true)
                                    .Select(z => new BranchMobileNumberModel
                                    {
                                        BranchMobileNumberId = z.Id,
                                        BranchId = z.BranchId,
                                        BranchReceiverMobileNumber = z.BranchReceiverMobileNumber,
                                        BranchReceiverName = z.BranchReceiverName,
                                        IsActive = z.IsActive
                                    }).ToListAsync();
                            obj.BranchMobileNumberModelsList = resObj;
                        }
                        return new Tuple<int, string, List<BranchModel>>(200, "Success", res);
                    }
                    else
                    {
                        var res = await dbContext.BranchDetails
                           .Select(z => new BranchModel
                           {
                               BranchId = z.Id,
                               CompanyId = z.CompanyId,
                               DivisionId = z.DivisionId,
                               TownShipId = z.TownShipId,
                               CityId = z.CityId,
                               DistrictId = z.DistrictId,
                               BranchName = z.BranchName,
                               BranchBName = z.BranchBName,
                               Description = z.Description,
                               BDescription = z.BDescription,
                               CompanyName = z.CompanyDetail.CompanyName,
                               DivisionName = z.Division.Name,
                               TownShipName = z.TownShip.Name,
                               CityName = z.City.Name,
                               DistrictName = z.District.Name,
                               IsActive = z.IsActive,
                               CreatedDate = z.CreatedDate
                           }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                        foreach (var obj in res)
                        {
                            var resObj =
                                await dbContext.BranchMobileNumberDetails.Where(x => x.BranchId == obj.BranchId && x.IsActive == true)
                                    .Select(z => new BranchMobileNumberModel
                                    {
                                        BranchMobileNumberId = z.Id,
                                        BranchId = z.BranchId,
                                        BranchReceiverMobileNumber = z.BranchReceiverMobileNumber,
                                        BranchReceiverName = z.BranchReceiverName,
                                        IsActive = z.IsActive
                                    }).ToListAsync();
                            obj.BranchMobileNumberModelsList = resObj;
                        }
                        return new Tuple<int, string, List<BranchModel>>(200, "Success", res);
                    }


                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllBranch :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<BranchModel>>(500, "System Error Contact Admin", new List<BranchModel>());
            }
        }

        public async Task<Tuple<int, string, BranchModel>> GetBranchById(Guid branchId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await dbContext.BranchDetails.Where(x => x.Id == branchId)
                        .Select(z => new BranchModel
                        {
                            BranchId = z.Id,
                            CompanyId = z.CompanyId,
                            DivisionId = z.DivisionId,
                            TownShipId = z.TownShipId,
                            CityId = z.CityId,
                            DistrictId = z.DistrictId,
                            BranchName = z.BranchName,
                            BranchBName = z.BranchBName,
                            Description = z.Description,
                            BDescription = z.BDescription,
                            CompanyName = z.CompanyDetail.CompanyName,
                            DivisionName = z.Division.Name,
                            TownShipName = z.TownShip.Name,
                            CityName = z.City.Name,
                            DistrictName = z.District.Name,
                            IsActive = z.IsActive
                        }).FirstOrDefaultAsync();
                    if (res != null)
                    {
                        var resObj =
                               await dbContext.BranchMobileNumberDetails.Where(x => x.BranchId == res.BranchId && x.IsActive == true)
                                   .Select(z => new BranchMobileNumberModel
                                   {
                                       BranchMobileNumberId = z.Id,
                                       BranchId = z.BranchId,
                                       BranchReceiverMobileNumber = z.BranchReceiverMobileNumber,
                                       BranchReceiverName = z.BranchReceiverName,
                                       IsActive = z.IsActive
                                   }).ToListAsync();
                        res.BranchMobileNumberModelsList = resObj;
                        return new Tuple<int, string, BranchModel>(200, "Success", res);
                    }
                    else
                    {
                        return new Tuple<int, string, BranchModel>(300, "Invalid BranchId", new BranchModel());
                    }


                }
            }
            catch (Exception ex)
            {
                Log.Error("GetBranchById :: 500 :: " + ex.Message);
                return new Tuple<int, string, BranchModel>(500, "System Error Contact Admin", new BranchModel());
            }
        }


        public async Task<Tuple<int, string>> BranchAlreadyExist(Guid companyId, Guid divisionId, Guid townShipId,
            Guid? cityId, Guid? districtId, string branchName)
        {

            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await dbContext.BranchDetails.Where(x => x.IsActive == true
                                                                       && x.CompanyId == companyId &&
                                                                       x.DivisionId == divisionId &&
                                                                       x.TownShipId == townShipId &&
                                                                       x.CityId == cityId &&
                                                                       x.DistrictId == districtId &&
                                                                       x.BranchName == branchName).CountAsync();
                    if (res == 0)
                        return new Tuple<int, string>(200, "Data Does not exis");


                    return new Tuple<int, string>(300, "Data Already Exist");
                }
            }
            catch (Exception ex)
            {
                Log.Error("BranchAlreadyExist :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, string>> IsValidBranchForUpdate(Guid branchId, Guid companyId, Guid divisionId, Guid townShipId,
       Guid? cityId, Guid? districtId, string branchName)
        {

            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await dbContext.BranchDetails.Where(x => x.IsActive == true
                                                                       && x.CompanyId == companyId &&
                                                                       x.DivisionId == divisionId &&
                                                                       x.TownShipId == townShipId && x.CityId == cityId &&
                                                                       x.DistrictId == districtId &&
                                                                       x.BranchBName == branchName
                                                                       && x.Id != branchId).CountAsync();
                    if (res == 0)
                        return new Tuple<int, string>(200, "Valid Data");


                    return new Tuple<int, string>(300, "Data Already Exist");
                }
            }
            catch (Exception ex)
            {
                Log.Error("IsValidBranchForUpdate :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }

        public async Task<Tuple<int, string, List<CustomerModel>>> GetCustomerList()
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {

                    var res = await dbContext.Customers
                        .Where(x => x.IsActive == true)
                        .Select(z => new CustomerModel
                        {
                            Id = z.Id,
                            OkAccountNumber = z.OkAccountNumber,
                            CustomerName = z.CustomerName,
                            IsActive = z.IsActive,
                            CreatedDate = z.CreatedDate
                        }).OrderBy(z => z.CreatedDate).ToListAsync();
                    if (res != null)
                    {
                        if (res.Count > 0)
                        {
                            return new Tuple<int, string, List<CustomerModel>>(200, "Success", res);
                        }
                    }
                    return new Tuple<int, string, List<CustomerModel>>(300, "No Data Found", res);

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetCustomerList :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<CustomerModel>>(500, "System Error Contact Admin",
                    new List<CustomerModel>());
            }
        }

        public async Task<Tuple<int, string>> UploadExcel(List<BranchModel> objBranchModel, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var branchList = new List<BranchDetail>(); string ErrorMessage = ""; int rowIndex = 0;

                    foreach (var item in objBranchModel)
                    {
                        rowIndex++; var branch = new object();

                        if (string.IsNullOrEmpty(item.BranchName))
                            ErrorMessage += "In Row " + rowIndex + " Branch Name is required.\n";

                        if (string.IsNullOrEmpty(item.Description))
                            ErrorMessage += "In Row " + rowIndex + " Branch Description is required.\n";

                        if (string.IsNullOrEmpty(item.CompanyName))
                            ErrorMessage += "In Row " + rowIndex + " Company Name is required.\n";
                        else
                        {
                            var company = await dbContext.CompanyDetails.Where(x => x.IsActive == true && x.CompanyName == item.CompanyName).FirstOrDefaultAsync();
                            if (company == null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.CompanyName + " does not exists.\n";
                            else
                                item.CompanyId = company.Id;
                        }

                        if (string.IsNullOrEmpty(item.DivisionName))
                            ErrorMessage += "In Row " + rowIndex + " Division Name is required.\n";
                        else
                        {
                            var division = await dbContext.Divisions.Where(x => x.Is_Active == true && x.Name == item.DivisionName).FirstOrDefaultAsync();
                            if (division == null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.DivisionName + " does not exists.\n";
                            else
                                item.DivisionId = division.ID;

                            if (string.IsNullOrEmpty(item.TownShipName))
                                ErrorMessage += "In Row " + rowIndex + " TownShip Name is required.\n";
                            else
                            {
                                var township = await dbContext.TownShips.Where(x => x.Is_Active == true && x.Name == item.TownShipName).FirstOrDefaultAsync();
                                var townshipMapping = await dbContext.TownShips.Where(x => x.Is_Active == true && x.Name == item.TownShipName && x.DivisionID == division.ID).FirstOrDefaultAsync();

                                if (township == null)
                                    ErrorMessage += "In Row " + rowIndex + " " + item.TownShipName + " does not exists.\n";
                                else if (townshipMapping == null && township != null)
                                    ErrorMessage += "In Row " + rowIndex + " " + item.TownShipName + " does not come under " + item.DivisionName + ".\n";
                                else
                                    item.TownShipId = township.ID;

                                if (string.IsNullOrEmpty(item.CityName))
                                    ErrorMessage += "In Row " + rowIndex + " City Name is required.\n";
                                else
                                {
                                    var city = await dbContext.Cities.Where(x => x.IsActive == true && x.Name == item.CityName).FirstOrDefaultAsync();
                                    var cityMapping = await dbContext.Cities.Where(x => x.IsActive == true && x.Name == item.CityName && x.TownShipId == townshipMapping.ID).FirstOrDefaultAsync();

                                    if (city == null)
                                        ErrorMessage += "In Row " + rowIndex + " " + item.CityName + " does not exists.\n";
                                    else if (cityMapping == null && city != null)
                                        ErrorMessage += "In Row " + rowIndex + " " + item.CityName + " does not come under " + item.DivisionName + ".\n";
                                    else
                                        item.CityId = city.Id;
                                }

                                if (string.IsNullOrEmpty(item.DistrictName))
                                    ErrorMessage += "In Row " + rowIndex + " District Name is required.\n";
                                else
                                {
                                    var district = await dbContext.Districts.Where(x => x.IsActive == true && x.Name == item.DistrictName).FirstOrDefaultAsync();
                                    var districtMapping = await dbContext.Districts.Where(x => x.IsActive == true && x.Name == item.DistrictName && x.TownShipId == townshipMapping.ID).FirstOrDefaultAsync();

                                    if (district == null)
                                        ErrorMessage += "In Row " + rowIndex + " " + item.DistrictName + " does not exists.\n";
                                    else if (districtMapping == null && district != null)
                                        ErrorMessage += "In Row " + rowIndex + " " + item.DistrictName + " does not come under " + item.DivisionName + ".\n";
                                    else
                                        item.DistrictId = district.Id;
                                }
                            }
                        }

                        if (item.CompanyId != Guid.Empty && item.DivisionId != Guid.Empty && item.TownShipId != Guid.Empty && item.CityId != Guid.Empty && item.DistrictId != Guid.Empty && string.IsNullOrEmpty(item.BranchName))
                        {
                            branch = await dbContext.BranchDetails.Where(x => x.IsActive == true && x.DistrictId == item.DivisionId && x.TownShipId == item.TownShipId && x.CityId == item.CityId && x.DistrictId == item.DistrictId && x.BranchName == item.BranchName).FirstOrDefaultAsync();
                            if (branch != null)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.BranchName + " already exists.\n";
                            }
                        }

                        branchList.Add(new BranchDetail
                        {
                            Id = Guid.NewGuid(),
                            CompanyId = item.CompanyId,
                            DivisionId = item.DivisionId,
                            TownShipId = item.TownShipId,
                            CityId = item.CityId,
                            DistrictId = item.DistrictId,
                            BranchName = item.BranchName,
                            BranchBName = item.BranchBName,
                            Description = item.Description,
                            BDescription = item.BDescription,
                            IsActive = true,
                            CreatedBy = userId,
                            CreatedDate = DateTime.Now
                        });

                        var duplicateBranch = branchList.GroupBy(x => x.BranchName).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        if (branch == null)
                        {
                            if (duplicateBranch.Count > 0)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.BranchName + " already exists.\n";
                                branchList.Clear();
                            }
                        }

                    }

                    if (ErrorMessage == "")
                    {
                        dbContext.BranchDetails.AddRange(branchList);
                        await dbContext.SaveChangesAsync();
                        return new Tuple<int, string>(200, "Branch Created Successfully");
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

        public async Task<Tuple<int, string, List<BranchModel>>> GatBranchByOfferCode(Guid offerid)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var res = await dbContext.OfferDetails.Where(x => x.Id == offerid && x.IsActive == true).FirstOrDefaultAsync();

                    if (res != null)
                    {
                        var resBranchDetails =
                                       await
                                           dbContext.BranchDetails.Where(
                                               x => x.CompanyId == res.CompanyId && x.IsActive == true)
                                               .Select(z => new BranchModel
                                               {
                                                   BranchId = z.Id,
                                                   BranchName = z.BranchName,
                                                   IsActive = z.IsActive
                                               }).OrderBy(z => z.BranchName).Distinct().ToListAsync();

                        return new Tuple<int, string, List<BranchModel>>(200, "Success", resBranchDetails);
                    }

                    return new Tuple<int, string, List<BranchModel>>(300, "No Data Found", new List<BranchModel>());

                }
            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByOfferCode :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<BranchModel>>(500, "System Error", new List<BranchModel>());
            }
        }

        public async Task<BranchModel> GetBranchByCompanyId(Guid companyId,string branchName)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var response = await dbContext.BranchDetails.FirstOrDefaultAsync(x => x.CompanyId == companyId && x.BranchName == branchName);
                    var branchDetails = new BranchModel()
                    {
                        BranchId = response.Id,
                        CompanyId = response.CompanyId,
                        DivisionId = response.DivisionId,
                        TownShipId = response.TownShipId,
                        CityId = response.CityId,
                        DistrictId = response.DistrictId,
                        BranchName = response.BranchName,
                        BranchBName = response.BranchBName,
                        Description = response.Description,
                        BDescription = response.BDescription,
                        CompanyName = response.CompanyDetail.CompanyName,
                        DivisionName = response.Division.Name,
                        TownShipName = response.TownShip.Name,
                        CityName = response.City.Name,
                        DistrictName = response.District.Name,
                        IsActive = response.IsActive
                    };
                    return branchDetails;
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetBranchByCompanyId :: 500 :: " + ex.Message);
                return null;
            }
        }


        public async Task<List<Guid>> GetBranchByCompanyName(string companyName, string branchName)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var response = await dbContext.BranchDetails.Include(x => x.CompanyDetail).Where(x => x.CompanyDetail.CompanyName == companyName && x.BranchName == branchName && x.IsActive).Select(x=>x.Id).ToListAsync();
                    return response;

                }
            }
            catch (Exception ex)
            {
                Log.Error("GetBranchByCompanyName :: 500 :: " + ex.Message);
                return null;
            }
        }

        public async Task<List<Guid>> GetBranchByLocation(string division, string district, string city, string township)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var response = await dbContext.BranchDetails.Include(x=>x.District).Include(x=>x.Division).Include(x=>x.TownShip).Include(x=>x.City).Where(x => x.IsActive && x.Division.Name == division 
                                        && x.District.Name == district && x.TownShip.Name == township && x.City.Name == city).Select(x=>x.Id).ToListAsync();
                    return response;
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetEcouponDetailsByName :: 500 :: " + ex.Message);
                return null;
            }
        }
    }
}
