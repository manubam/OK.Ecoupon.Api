using Cgm.Ecoupon.Api.Models.Ecoupon.EcouponDetails;
using Cgm.Ecoupon.Api.Response;
using Cgm.Ecoupon.Application;
using log4net;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cgm.Ecoupon.Api.Controllers
{
    public class EcouponController : BaseController
    {
        private static readonly ILog Log =
        LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEcouponService _ecouponService;

        public EcouponController(IEcouponService ecouponService)
        {
            _ecouponService = ecouponService;
        }
        [HttpPost]
        [Route(Constants.Routes.Paths.AddEcoupon)]
        public async Task<IHttpActionResult> Add([FromBody] AddEcouponDto lModel)
        {
            try
            {
                if (lModel == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _ecouponService.AddEcouponDetails(lModel.Name,lModel.Description,lModel.BatchNo,
                        lModel.TotalQuantity,lModel.StartDate,lModel.EndDate,lModel.UserId);
                if (res)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success"
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Data not saved, please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddEcoupon :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.AllocateEcoupons)]
        public async Task<IHttpActionResult> AllocateEcoupons([FromBody] AllocateEcouponDto lModel)
        {
            try
            {
                if (lModel == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _ecouponService.AllocateEcoupons(lModel.EcouponName,lModel.BatchNo,lModel.AllocatedQuantity,lModel.AllocationType,
                        lModel.CompanyName, lModel.BranchName, lModel.Division, lModel.District, lModel.City, lModel.Township, lModel.UserId);
                if (res)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success"
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Data not saved, please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("AllocateEcoupon :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.ActivateEcoupons)]
        public async Task<IHttpActionResult> ActivateEcoupons([FromBody] ActivateEcouponDto lModel)
        {
            try
            {
                if (lModel == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _ecouponService.ActivateEcoupons(lModel.EcouponName, lModel.BatchNo, lModel.CouponDiscount, lModel.ActivationType,
                        lModel.CompanyName, lModel.BranchName, lModel.Division, lModel.District, lModel.City, lModel.Township, lModel.UserId, lModel.Activate);
                if (res)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success"
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Data not saved, please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("ActivateEcoupon :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.RedeemEcoupons)]
        public async Task<IHttpActionResult> RedeemEcoupons([FromBody] RedeemEcouponDto lModel)
        {
            try
            {
                //throw new NotImplementedException();
                if (lModel == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }
                var res =
                    await
                        _ecouponService.RedeemEcoupons(lModel.AccountNumber,lModel.EcouponNumber,lModel.Latitude,lModel.Longitude,lModel.Division,lModel.District
                        ,lModel.City,lModel.Township);
                if (res)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success"
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Data not saved, please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("RedeemEcoupon :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetRedeemedEcoupons)]
        public async Task<IHttpActionResult> GetRedeemedEcoupons(string ecouponName, string batchNo, int offset, int limit)
        {
            try
            {
                var res =
                    await
                        _ecouponService.GetRedeemedEcoupons(ecouponName, batchNo,offset,limit);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetRedeemedCoupons :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

    }
}
