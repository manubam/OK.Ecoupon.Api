using Cgm.Ecoupon.Domain.Ecoupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application
{
    public interface IEcouponService
    {
        Task<bool> AddEcouponDetails(string EcouponName, string EcouponDescription, string BatchNo, uint Quantity, DateTime StartDate, DateTime EndDate, string userId);
        Task<bool> AllocateEcoupons(string ecouponName, string batchNo, uint allocatedQuantity, bool allocationType, string companyName, string branchName, string division, string district, string city, string township, string userId);
        Task<bool> ActivateEcoupons(string ecouponName, string batchNo, int couponDiscount, int activationType, string companyName, string branchName, string division, string district, string city, string township, string userId, bool activate);
        Task<bool> RedeemEcoupons(string accountNumber, string ecouponNumber, double latitude, double longitude, string division, string district, string city, string township);
        Task<Tuple<int, string, List<EcouponNumberModel>>> GetRedeemedEcoupons(string ecouponName, string batchNo, int offset, int limit);
    }
}
