using Cgm.Ecoupon.Domain.Ecoupons;
using Cgm.Ecoupon.Infrastructure.Persistence.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Infrastructure.Persistence.Repositories
{
    public class EcouponRepository:IEcouponRepository
    {
        private static readonly ILog Log =
       LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<bool> ActivateCoupons(List<Guid> allocationIds, int couponDiscount,bool activate, string userId)
        {
            try
            {
                //1 - created/allocated , 2- activated , -1 deactivated
                using (var dbContext = new OfferManagementEntities1())
                {
                    var response = await dbContext.EcouponAllocationDetails.Where(x => allocationIds.Contains(x.Id)).ToListAsync();
                    if(activate)
                    {
                        foreach(var item in response)
                        {
                            item.IsActive = 2;
                            item.DiscountPercentage = couponDiscount;
                            item.ActivatedBy = userId;
                            item.ActivatedDate = DateTime.Now;
                        }
                        //var activationResponse = response.Select(c => { c.IsActive = 2;c.DiscountPercentage = couponDiscount; c.ActivatedDate = DateTime.Now; c.ActivatedBy = userId; return c; });
                        var ecouponActivation = await dbContext.EcouponNumbers.Where(x => allocationIds.Contains((Guid)x.EcouponAllocationId) && x.status == 1).ToListAsync();
                        foreach(var item in ecouponActivation)
                        {
                            item.status = 2;
                        }
                        
                        //var ecouponNumberResponse = ecouponActivation.Select(c=> { c.status = 2;return c; });
                    }
                    else
                    {
                        foreach(var item in response)
                        {
                            item.IsActive = -1;
                            item.DeactivatedDate = DateTime.Now;
                            item.DeactivatedBy = userId;
                        }
                        //var deactivationResponse = response.Select(c => { c.IsActive = -1; c.DeactivatedDate = DateTime.Now; c.DeactivatedBy = userId; return c; });
                    }
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("ActivateCoupons :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<Tuple<bool,Guid>> AddEcouponDetails(string EcouponName, string EcouponDescription, string BatchNo, uint Quantity, DateTime StartDate, DateTime EndDate, string userId)
        {
            try
            {
                var id = Guid.NewGuid();
                using (var dbContext = new OfferManagementEntities1())
                {
                    EcouponMetadata lModel = new EcouponMetadata
                    {
                        Id = id,
                        Name = EcouponName,
                        Description = EcouponDescription,
                        StartDate = StartDate,
                        EndDate = EndDate,
                        BatchNo = BatchNo,
                        Quantity = Quantity,
                        IsActive = true,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now
                    };

                    dbContext.EcouponMetadatas.Add(lModel);
                    await dbContext.SaveChangesAsync();
                    return new Tuple<bool,Guid>(true,id);
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddEcouponDetails :: 500 :: " + ex.Message);
                return new Tuple<bool, Guid>(false,new Guid());
            }
        }

        public async Task<bool> AddNumbers(List<string> ecouponNumbers, Guid item2)
        {
            try
            {
                //var EcouponNumberList = new List<EcouponNumber>();
                using (var dbContext = new OfferManagementEntities1())
                {
                    foreach (var item in ecouponNumbers)
                    {
                        var id = Guid.NewGuid();
                        EcouponNumber lModel = new EcouponNumber
                        {
                            Id = id,
                            EcouponMetadataId = item2,
                            status = 0,
                            EcouponNo = item,
                            CreatedDate = DateTime.Now
                        };
                        //EcouponNumberList.Add(lModel);
                        dbContext.EcouponNumbers.Add(lModel);
                    }
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddEcouponNumbers :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> AllocateEcoupons(Guid AllocationId,Guid ecouponMetadataId, Guid branchId, bool allocationType, uint allocatedQuantity, string user)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    //1 - created/allocated , 2- activated , -1 deactivated
                    EcouponAllocationDetail lModel = new EcouponAllocationDetail
                    {
                        Id = AllocationId,
                        EcouponMetadataId = ecouponMetadataId,
                        BranchId = branchId,
                        AllocationQuantity = allocatedQuantity,
                        AllocationType = allocationType,
                        CreatedBy = user,
                        IsActive = 1,
                        CreatedDate = DateTime.Now
                    };

                    dbContext.EcouponAllocationDetails.Add(lModel);

                    //0 - created, 1- allocated ,2 -activated , 3 - redeemed ,-1 - deactivated
                    var EcouponNumbers = await dbContext.EcouponNumbers.Where(x => x.EcouponMetadataId == ecouponMetadataId && x.status == 0).OrderBy(r => Guid.NewGuid()).Take((int)allocatedQuantity).ToListAsync();//.Select(c=> { c.EcouponAllocationId = AllocationId;c.status = 1; return c; });
                    if(EcouponNumbers.Count < allocatedQuantity)
                    {
                        return false;
                    }
                    foreach(var item in EcouponNumbers)
                    {
                        item.status = 1;
                        item.EcouponAllocationId = AllocationId;
                    }
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddEcouponDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<List<Guid>> GetAllocationIdsByBatchNo(string batchNo)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var ecouponMetadatas = await dbContext.EcouponMetadatas.Where(x => x.IsActive && x.BatchNo == batchNo).Select(x=>x.Id).ToListAsync();
                    var response = await dbContext.EcouponAllocationDetails.Where(x => ecouponMetadatas.Contains(x.EcouponMetadataId) && x.IsActive==1).Select(x=>x.Id).ToListAsync();
                    return response;
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetEcouponDetailsByName :: 500 :: " + ex.Message);
                return null;
            }
        }

        public async Task<List<Guid>> GetAllocationIdsByBranch(List<Guid> branchId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var response = await dbContext.EcouponAllocationDetails.Where(x => x.IsActive == 1 && branchId.Contains(x.BranchId)).Select(x => x.Id).ToListAsync();
                    return response;
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetEcouponDetailsByName :: 500 :: " + ex.Message);
                return null;
            }
        }

        public async Task<EcouponMetadataModel> GetEcouponDetailsByName(string EcouponName,  string BatchNo)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var response = await dbContext.EcouponMetadatas.FirstOrDefaultAsync(x => x.Name == EcouponName && x.BatchNo == BatchNo && x.IsActive);
                    var ecouponData = new EcouponMetadataModel()
                    {
                        Id = response.Id,
                        Name = response.Name,
                        Description = response.Description,
                        StartDate = response.StartDate,
                        EndDate = response.EndDate,
                        BatchNo = response.BatchNo,
                        Quantity = response.Quantity,
                        IsActive = response.IsActive,
                        CreatedBy = response.CreatedBy,
                        CreatedDate = response.CreatedDate
                    };
                    return ecouponData;
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetEcouponDetailsByName :: 500 :: " + ex.Message);
                return null;
            }
        }

        public async Task<Tuple<int, string,List<EcouponNumberModel>>> GetRedeemedEcoupons(string ecouponName, string batchNo, int offset, int limit)
        {
            try
            {
                var ecouponList = new List<EcouponNumberModel>();
                using (var dbContext = new OfferManagementEntities1())
                {
                    var response = await dbContext.EcouponNumbers.Include(x => x.EcouponMetadata).Where(x => x.EcouponMetadata.Name == ecouponName && x.EcouponMetadata.BatchNo == batchNo).OrderBy(x => x.CreatedDate).Skip(offset).Take(limit).ToListAsync();
                    foreach(var item in response)
                    {
                        var ecouponRedeemedNumber = new EcouponNumberModel()
                        {
                            Id = item.Id,
                            EcouponMetadataId = item.EcouponMetadataId,
                            EcouponAllocationId = item.EcouponAllocationId,
                            status = item.status,
                            EcouponNo = item.EcouponNo,
                            CreatedDate = item.CreatedDate
                        };
                        ecouponList.Add(ecouponRedeemedNumber);
                    }
                    return new Tuple<int, string, List<EcouponNumberModel>>(200, "Success", ecouponList);
                    
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetRedeemedEcoupons :: 500 :: " + ex.Message);
                return new Tuple<int, string, List<EcouponNumberModel>>(500, "System Error Contact Admin",null);
            }
        }

        public async Task<bool> validateEcoupon(string ecouponNumber, string accountNumber, double latitude, double longitude, string division, string district, string township, string city)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities1())
                {
                    var response = await dbContext.EcouponNumbers.Include(x => x.EcouponMetadata).FirstOrDefaultAsync(x => x.EcouponNo == ecouponNumber && x.status == 2 
                                                                   && x.EcouponAllocationId != null && x.EcouponMetadata.IsActive == true && 
                                                                   DateTime.Now > x.EcouponMetadata.StartDate && DateTime.Now < x.EcouponMetadata.EndDate);
                    if (response != null)
                    {

                        response.status = 3; 

                        var lModel = new EcouponRedeemInfo()
                        {
                            Id = Guid.NewGuid(),
                            EcouponNo = ecouponNumber,
                            EcouponNumberId = response.Id,
                            Latitude = latitude,
                            Longitude = longitude,
                            City = city,
                            Township = township,
                            Division = division,
                            District = district,
                            AccountNumber = accountNumber
                        };
                        dbContext.EcouponRedeemInfoes.Add(lModel);
                        await dbContext.SaveChangesAsync();
                        return true;
                    } 
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error("RedeemEcoupon :: 500 :: " + ex.Message);
                return false;
            }
        }
    }
}
