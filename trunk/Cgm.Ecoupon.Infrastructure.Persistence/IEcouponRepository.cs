using Cgm.Ecoupon.Domain.Ecoupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Infrastructure.Persistence
{
    public interface IEcouponRepository
    {
        Task<Tuple<bool,Guid>> AddEcouponDetails(string EcouponName, string EcouponDescription, string BatchNo, uint Quantity, DateTime StartDate, DateTime EndDate, string userId);
        Task<EcouponMetadataModel> GetEcouponDetailsByName(string EcouponName, string BatchNo);
        Task<bool> AllocateEcoupons(Guid AllocationId,Guid EcouponMetadataId, Guid branchId, bool allocationType, uint allocatedQuantity, string userId);
        Task<bool> AddNumbers(List<string> ecouponNumbers, Guid item2);
        Task<bool> ActivateCoupons(List<Guid> allocationIds, int couponDiscount,bool activate, string userId);
        Task<List<Guid>> GetAllocationIdsByBatchNo(string batchNo);
    }
}
