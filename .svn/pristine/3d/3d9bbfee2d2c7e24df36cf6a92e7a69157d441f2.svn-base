using Cgm.Ecoupon.Api.Models.Branch;
using Cgm.Ecoupon.Api.Response;
using Cgm.Ecoupon.Application;
using Cgm.Ecoupon.Domain.Branch;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cgm.Ecoupon.Api.Controllers
{
    public class BranchController : BaseController
    {
        private static readonly ILog Log =
     LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetAllDivision)]
        public async Task<IHttpActionResult> GetAllDivision()
        {
            try
            {
                var res =
                    await
                        _branchService.GetAllDivisionList();

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetAllDivisionList :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetAllTownShip)]
        public async Task<IHttpActionResult> GetAllTownShip()
        {
            try
            {
                var res =
                    await
                        _branchService.GetAllTownShipList();

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetAllTownShip :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetTownShipByDivisionId)]
        public async Task<IHttpActionResult> GetTownShipByDivisionId(Guid divisionId)
        {
            try
            {
                var res =
                    await
                        _branchService.GetTownShipByDivisionId(divisionId);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetTownShipByDivisionId :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetCityByTownShipId)]
        public async Task<IHttpActionResult> GetCityByTownShipId(Guid townShipId)
        {
            try
            {
                var res =
                    await
                        _branchService.GetCityByTownShipId(townShipId);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetCityByTownShipId :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetDistrictByTownShipId)]
        public async Task<IHttpActionResult> GetDistrictByTownShipId(Guid townShipId)
        {
            try
            {
                var res =
                    await
                        _branchService.GetDistrictByTownShipId(townShipId);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetDistrictByTownShipId :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.AddBranch)]
        public async Task<IHttpActionResult> AddBranch([FromBody] AddBranchDto lDto)
        {
            try
            {
                if (lDto.BranchMobileNumberDtoList == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "branch phone number not found, please check your input",
                    };
                    return Ok(response);
                }
                else if (lDto.BranchMobileNumberDtoList.Count == 0)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "branch phone number not found, please check your input",
                    };
                    return Ok(response);
                }
                List<BranchMobileNumberModel> lstModels = lDto.BranchMobileNumberDtoList.Select(obj => new BranchMobileNumberModel
                {
                    BranchReceiverMobileNumber = obj.BranchReceiverMobileNumber,
                    BranchReceiverName = obj.BranchReceiverName
                }).ToList();
                var res =
                    await
                        _branchService.AddBranch(lDto.CompanyId, lDto.DivisionId, lDto.TownShipId, lDto.CityId, lDto.DistrictId, lDto.BranchName, lDto.BranchBName, lDto.Description, lDto.BDescription, lDto.CreatedUserId, lstModels);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                });

            }
            catch (Exception ex)
            {
                Log.Error("AddBranch :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UpdateBranch)]
        public async Task<IHttpActionResult> UpdateBranch([FromBody] UpdateBranchDto lDto)
        {
            try
            {
                if (lDto.BranchMobileNumberDtoList == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "branch phone number not found, please check your input",
                    };
                    return Ok(response);
                }
                else if (lDto.BranchMobileNumberDtoList.Count == 0)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "branch phone number not found, please check your input",
                    };
                    return Ok(response);
                }
                List<BranchMobileNumberModel> lstModels = lDto.BranchMobileNumberDtoList.Select(obj => new BranchMobileNumberModel
                {
                    BranchMobileNumberId = obj.BranchMobileNumberId,
                    BranchId = obj.BranchId,
                    BranchReceiverMobileNumber = obj.BranchReceiverMobileNumber,
                    BranchReceiverName = obj.BranchReceiverName,
                    IsActive = obj.IsActive
                }).ToList();

                var res =
                    await
                        _branchService.UpdateBranch(lDto.BranchId, lDto.CompanyId, lDto.DivisionId, lDto.TownShipId, lDto.CityId, lDto.DistrictId, lDto.BranchName, lDto.BranchBName, lDto.Description, lDto.BDescription, lDto.CreatedUserId, lstModels);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                });

            }
            catch (Exception ex)
            {
                Log.Error("UpdateBranch :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.DeleteBranch)]
        public async Task<IHttpActionResult> DeleteBranch([FromBody] DeleteBranchDto lDto)
        {
            try
            {
                var res =
                    await
                        _branchService.DeleteBranch(lDto.BranchId, lDto.CreatedUserId);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                });

            }
            catch (Exception ex)
            {
                Log.Error("DeleteBranch :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetAllBranch)]
        public async Task<IHttpActionResult> GetAllBranch(bool? isActive = null)
        {
            try
            {
                var res =
                    await
                        _branchService.GetAllBranch(isActive);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetAllBranch :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetBranchById)]
        public async Task<IHttpActionResult> GetBranchById(Guid branchId)
        {
            try
            {
                var res =
                    await
                        _branchService.GetBranchById(branchId);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetAllBranch :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.BranchAlreadyExist)]
        public async Task<IHttpActionResult> BranchAlreadyExist([FromBody] BranchExistDto lDto)
        {
            try
            {
                var res =
                    await
                        _branchService.BranchAlreadyExist(lDto.CompanyId, lDto.DivisionId, lDto.TownShipId, lDto.CityId, lDto.DistrictId, lDto.BranchName);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2
                });

            }
            catch (Exception ex)
            {
                Log.Error("BranchAlreadyExist :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetCustomer)]
        public async Task<IHttpActionResult> GetCustomer()
        {
            try
            {
                var res =
                    await
                        _branchService.GetCustomerList();

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GetAllDivisionList :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UploadBranch)]
        public async Task<IHttpActionResult> UploadExcel([FromBody] UploadBranchDetailsDto lModel)
        {
            try
            {
                if (lModel.BranchDetailsList == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                List<BranchModel> lstBranchModels = lModel.BranchDetailsList.Select(obj => new BranchModel
                {
                    BranchId = obj.Id,
                    CompanyName = obj.CompanyName,
                    DivisionName = obj.DivisionName,
                    TownShipName = obj.TownShipName,
                    CityName = obj.CityName,
                    DistrictName = obj.DistrictName,
                    BranchName = obj.BranchName,
                    BranchBName = obj.BranchBName,
                    Description = obj.Description,
                    BDescription = obj.BDescription

                }).ToList();

                var res = await _branchService.UploadExcel(lstBranchModels, lModel.UserId);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                });

            }
            catch (Exception ex)
            {
                Log.Error("UploadExcel :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GatBranchByOfferCode)]
        public async Task<IHttpActionResult> GatBranchByOfferCode(Guid offerid)
        {
            try
            {
                var res =
                    await
                        _branchService.GatBranchByOfferCode(offerid);

                return Ok(new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3
                });

            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByOfferCode :: 500 :: " + ex.Message);
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
