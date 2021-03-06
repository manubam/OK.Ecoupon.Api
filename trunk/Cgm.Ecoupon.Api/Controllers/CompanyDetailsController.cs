using Cgm.Ecoupon.Api.Models.CompanyDetails;
using Cgm.Ecoupon.Api.Response;
using Cgm.Ecoupon.Application;
using Cgm.Ecoupon.Domain.CompanyDetails;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cgm.Ecoupon.Api.Controllers
{
    public class CompanyDetailsController : BaseController
    {
        private static readonly ILog Log =
         LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        private readonly ICompanyDetailsService _companyDetaisService;

        public CompanyDetailsController(ICompanyDetailsService companyDetaisService)
        {
            _companyDetaisService = companyDetaisService;
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.AddCompanyDetails)]
        public async Task<IHttpActionResult> Add([FromBody] CompanyDetailsAddDto lModel)
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
                        _companyDetaisService.AddCompanyDetails(lModel.CompanyName, lModel.CompanyBName,
                            lModel.CompanyDescription, lModel.CompanyImageUrl, lModel.UserId, lModel.BackendMobileNumber, lModel.BackendMobileNumberPassword);
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
                Log.Error("AddCompanyDetails :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UpdateCompanyDetails)]
        public async Task<IHttpActionResult> Update([FromBody] CompanyDetailsDto lModel)
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
                else if (lModel.CompanyId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid CompanyId or UserId"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _companyDetaisService.UpdateCompanyDetails(lModel.CompanyId, lModel.CompanyName, lModel.CompanyBName,
                            lModel.CompanyDescription, lModel.CompanyImageUrl, lModel.UserId, lModel.OfferBackendNumberId, lModel.BackendMobileNumber, lModel.BackendMobileNumberPassword);
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
                Log.Error("UpdateCompanyDetails :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.DeleteCompanyDetails)]
        public async Task<IHttpActionResult> Delete([FromBody] CompanyDetailsDeleteDto lModel)
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
                else if (lModel.CompanyId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid CompanyId or UserId"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _companyDetaisService.DeleteCompanyDetails(lModel.CompanyId, lModel.UserId);
                if (res.Item1 == 200)
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
                        Code = res.Item1,
                        Message = res.Item2
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("DeleteCompanyDetails :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetCompanyDetailsById)]
        public async Task<IHttpActionResult> GetCompanyDetailsById(Guid id)
        {
            try
            {
                if (id == Guid.NewGuid())
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
                        _companyDetaisService.GetCompanyDetailsById(id);
                switch (res.Item1)
                {
                    case 200:
                        return Ok(new CommonResponseModel<object>()
                        {
                            Data = res.Item2,
                            Code = 200,
                            Message = "Success"
                        });
                    case 300:
                        return Ok(new CommonResponseModel<object>()
                        {
                            Code = 300,
                            Message = "Invalid CompanyId"
                        });

                    default:
                        return Ok(new CommonResponseModel<object>()
                        {
                            Code = 500,
                            Message = "system error, please contact admin"
                        });
                }

            }
            catch (Exception ex)
            {
                Log.Error("GetCompanyDetailsById :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetAllCompanyDetails)]
        public async Task<IHttpActionResult> GetAllCompanyDetails(bool? isActive = null)
        {
            try
            {
                var res =
                    await
                        _companyDetaisService.GetAllCompanyDetails(isActive);
                switch (res.Item1)
                {
                    case 200:
                        return Ok(new CommonResponseModel<object>()
                        {
                            Data = res.Item2,
                            Code = 200,
                            Message = "Success"
                        });
                    case 300:
                        return Ok(new CommonResponseModel<object>()
                        {
                            Code = 300,
                            Message = "Invalid CompanyId"
                        });

                    default:
                        return Ok(new CommonResponseModel<object>()
                        {
                            Code = 500,
                            Message = "system error, please contact admin"
                        });
                }

            }
            catch (Exception ex)
            {
                Log.Error("GetAllCompanyDetails :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.CompanyAlreadyExist)]
        public async Task<IHttpActionResult> CompanyAlreadyExist(string companyName)
        {
            try
            {
                var res =
                    await
                        _companyDetaisService.CompanyAlreadyExist(companyName);
                if (res)
                {
                    return Ok(new CommonResponseModel<object>()
                    {
                        Data = true,
                        Code = 200,
                        Message = "Data already exist"
                    });
                }
                else
                {
                    return Ok(new CommonResponseModel<object>()
                    {
                        Data = false,
                        Code = 200,
                        Message = "Data not exist"
                    });
                }

            }
            catch (Exception ex)
            {
                Log.Error("CompanyAlreadyExist :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.CompanyNumberAlreadyExist)]
        public async Task<IHttpActionResult> CompanyNumberAlreadyExist([FromBody] CompanyDetailsDto lModel)
        {
            try
            {
                var res =
                    await
                        _companyDetaisService.CompanyNumberAlreadyExist(lModel.OfferBackendNumberId, lModel.BackendMobileNumber);
                if (res)
                {
                    return Ok(new CommonResponseModel<object>()
                    {
                        Data = true,
                        Code = 200,
                        Message = "Company Number already exist"
                    });
                }
                else
                {
                    return Ok(new CommonResponseModel<object>()
                    {
                        Data = false,
                        Code = 200,
                        Message = "Data not exist"
                    });
                }

            }
            catch (Exception ex)
            {
                Log.Error("MobileNoAlreadyExist :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UploadCompany)]
        public async Task<IHttpActionResult> UploadExcel([FromBody] UploadCompanyDetailsDto lModel)
        {
            try
            {
                if (lModel.CompanyDetailsList == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                List<CompanyDetailsModel> lstCompanyModels = lModel.CompanyDetailsList.Select(obj => new CompanyDetailsModel
                {
                    Id = obj.CompanyId,
                    CompanyName = obj.CompanyName,
                    CompanyBName = obj.CompanyBName,
                    CompanyDescription = obj.CompanyDescription,
                    CompanyImageUrl = obj.CompanyImageUrl,
                    BackendMobileNumber = obj.BackendMobileNumber,
                    BackendMobileNumberPassword = obj.BackendMobileNumberPassword
                }).ToList();

                var res = await _companyDetaisService.UploadExcel(lstCompanyModels, lModel.UserId);

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
    }
}
