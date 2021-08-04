using Cgm.Ecoupon.Api.Models.CompanyProductMapping;
using Cgm.Ecoupon.Api.Response;
using Cgm.Ecoupon.Application;
using log4net;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cgm.Ecoupon.Api.Controllers
{
    public class CompanyProductMappingController : ApiController
    {
        private static readonly ILog Log =
      LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        private readonly ICompanyProductMappingService _companyProductMappingService;

        public CompanyProductMappingController(ICompanyProductMappingService companyProductMappingService)
        {
            _companyProductMappingService = companyProductMappingService;
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.AddCompanyAndProductMapping)]
        public async Task<IHttpActionResult> AddCompanyAndProductMapping([FromBody] AddCompanyAndProductMappingDto lModel)
        {
            try
            {
                Log.Debug("request : " + JsonConvert.SerializeObject(lModel));



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
                        _companyProductMappingService.AddCompanyAndProductMapping(lModel.CompanyId, lModel.BranchIdList,
                            lModel.ProductIdList, lModel.CreatedUserId);
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
                        Code = 300,
                        Message = res.Item2
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddCompanyAndProductMapping :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UpdateCompanyAndProductMapping)]
        public async Task<IHttpActionResult> UpdateCompanyAndProductMapping([FromBody] UpdateCompanyAndProductMappingDto lModel)
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
                        _companyProductMappingService.UpdateCompanyAndProductMapping(lModel.CompanyAndProductMappingId, lModel.ProductIdList,
                            lModel.CreatedUserId);
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
                        Code = 300,
                        Message = "Data not updated, please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateCompanyAndProductMapping :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GatBranchByCompanyId)]
        public async Task<IHttpActionResult> GatBranchByCompanyId(Guid id)
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
                        _companyProductMappingService.GatBranchByCompanyId(id);
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
                        Code = 300,
                        Message = "Please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("GatBranchByCompanyId :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.GatProductByFilters)]
        public async Task<IHttpActionResult> GatProductByFilters([FromBody] GatProductByFiltersDto lModel)
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
                        _companyProductMappingService.GatProductByFilters(lModel.ProductBrandListId, lModel.ProductBrandListId,
                            lModel.ProductCategoryListId);
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
                        Code = 300,
                        Message = "Please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("GatProductByFilters :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }


        [HttpGet]
        [Route(Constants.Routes.Paths.GetCompanyAndProductMappingList)]
        public async Task<IHttpActionResult> GetCompanyAndProductMappingList()
        {
            try
            {

                var res =
                      await
                          _companyProductMappingService.GetCompanyAndProductMappingList();
                if (res.Item1 == 200)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success",
                        Data = res.Item3

                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetCompanyAndProductMappingList :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }


        [HttpGet]
        [Route(Constants.Routes.Paths.GetCompanyAndProductMappingById)]
        public async Task<IHttpActionResult> GetCompanyAndProductMappingById(Guid id)
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
                        _companyProductMappingService.GetCompanyAndProductMappingById(id);
                if (res.Item1 == 200)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success",
                        Data = res.Item3

                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetCompanyAndProductMappingById :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }


        [HttpPost]
        [Route(Constants.Routes.Paths.GetProductGroupByCompanyIdandBranchId)]
        public async Task<IHttpActionResult> GetProductGroupByCompanyIdandBranchId([FromBody] GetProductGroupByCompanyAndBranchDto lModel)
        {
            try
            {
                if (lModel.CompanyId == Guid.NewGuid() && lModel.BranchId == Guid.NewGuid())
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
                        _companyProductMappingService.GetProductGroupByCompanyIdandBranchId(lModel.CompanyId, lModel.BranchId);

                var response1 = new CommonResponseModel<object>()
                {
                    Code = res.Item1,
                    Message = res.Item2,
                    Data = res.Item3

                };
                return Ok(response1);

            }
            catch (Exception ex)
            {
                Log.Error("GatProductGroupByCompanyIdandBranchId :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }


        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductGroupByCompanyId)]
        public async Task<IHttpActionResult> GetProductGroupByCompanyId(Guid companyid)
        {
            try
            {
                if (companyid == Guid.NewGuid())
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
                        _companyProductMappingService.GetProductGroupByCompanyId(companyid);
                if (res.Item1 == 200)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success",
                        Data = res.Item3

                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("GatProductGroupByCompanyId :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductBrandByCompanyId)]
        public async Task<IHttpActionResult> GetProductBrandByCompanyId(Guid companyid)
        {
            try
            {
                if (companyid == Guid.NewGuid())
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
                        _companyProductMappingService.GetProductBrandByCompanyId(companyid);
                if (res.Item1 == 200)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success",
                        Data = res.Item3

                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("GatProductGroupByCompanyId :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductCategoryByCompanyId)]
        public async Task<IHttpActionResult> GetProductCategoryByCompanyId(Guid companyid)
        {
            try
            {
                if (companyid == Guid.NewGuid())
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
                        _companyProductMappingService.GetProductCategoryByCompanyId(companyid);
                if (res.Item1 == 200)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success",
                        Data = res.Item3

                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("GatProductCategoryByCompanyId :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductDetailsByCompanyId)]
        public async Task<IHttpActionResult> GetProductDetailsByCompanyId(Guid companyid)
        {
            try
            {
                if (companyid == Guid.NewGuid())
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
                        _companyProductMappingService.GetProductDetailsByCompanyId(companyid);
                if (res.Item1 == 200)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 200,
                        Message = "Success",
                        Data = res.Item3

                    };
                    return Ok(response);
                }
                else
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Please contact admin"
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Log.Error("GatProductCategoryByCompanyId :: 500 :: " + ex.Message);
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
