using Cgm.Ecoupon.Api.Models.Product.ProductGroup;
using Cgm.Ecoupon.Api.Response;
using Cgm.Ecoupon.Application;
using Cgm.Ecoupon.Domain.Product.ProductGroupDetails;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cgm.Ecoupon.Api.Controllers
{
    public class ProductGroupController : BaseController
    {
        private static readonly ILog Log =
   LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IProductGroupDetailsService _productGroupDetailsService;

        public ProductGroupController(IProductGroupDetailsService productGroupDetailsService)
        {
            _productGroupDetailsService = productGroupDetailsService;
        }


        [HttpPost]
        [Route(Constants.Routes.Paths.AddProductGroup)]
        public async Task<IHttpActionResult> Add([FromBody] ProductGroupAddDto lModel)
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
                        _productGroupDetailsService.AddProductGroupDetails(lModel.ProductGroupName, lModel.ProductGroupDescription, lModel.UserId, lModel.IsActive);
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
                Log.Error("AddProductGroup :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UpdateProductGroup)]
        public async Task<IHttpActionResult> Update([FromBody] ProductGroupDto lModel)
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
                else if (lModel.ProductGroupId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid ProductGroupId or UserId"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _productGroupDetailsService.UpdateProductGroupDetails(lModel.ProductGroupId, lModel.ProductGroupName, lModel.ProductGroupDescription, lModel.UserId, lModel.IsActive);
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
                Log.Error("UpdateProductGroup :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.ProductGroupDelete)]
        public async Task<IHttpActionResult> ProductGroupDelete([FromBody] ProductGroupDeleteDto lModel)
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
                else if (lModel.ProductGroupId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
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
                        _productGroupDetailsService.DeleteProductGroupDetails(lModel.ProductGroupId, lModel.UserId);

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

                //if (res)
                //{
                //    var response = new CommonResponseModel<object>()
                //    {
                //        Code = 200,
                //        Message = "Success"
                //    };
                //    return Ok(response);
                //}
                //else
                //{
                //    var response = new CommonResponseModel<object>()
                //    {
                //        Code = 300,
                //        Message = "Data not saved, please contact admin"
                //    };
                //    return Ok(response);
                //}
            }
            catch (Exception ex)
            {
                Log.Error("DeleteProductGroup :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductGroupById)]
        public async Task<IHttpActionResult> GetProductGroupById(Guid id)
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
                        _productGroupDetailsService.GetProductGroupDetailsId(id);
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
                Log.Error("GetProductGroupById :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetAllProductGroup)]
        public async Task<IHttpActionResult> GetAllProductGroup(bool? isActive = null)
        {
            try
            {
                var res =
                    await
                        _productGroupDetailsService.GetAllProductGroupDetails(isActive);
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
                Log.Error("GetAllProductGroup :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.ProductGroupAlreadyExist)]
        public async Task<IHttpActionResult> ProductGroupAlreadyExist(string productGroupName)
        {
            try
            {
                var res =
                    await
                        _productGroupDetailsService.ProductGroupAlreadyExist(productGroupName);
                if (res)
                {
                    return Ok(new CommonResponseModel<object>()
                    {
                        Data = true,
                        Code = 200,
                        Message = "Data alredy exist"
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
                Log.Error("ProductGroupAlreadyExist :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UploadGroup)]
        public async Task<IHttpActionResult> UploadExcel([FromBody] UploadProductGroupDto lModel)
        {
            try
            {
                if (lModel.ProductGroupList == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                List<ProductGroupDetailsModel> lstGroupModels = lModel.ProductGroupList.Select(obj => new ProductGroupDetailsModel
                {
                    ProductGroupName = obj.ProductGroupName,
                    ProductGroupDescription = obj.ProductGroupDescription
                }).ToList();

                var res = await _productGroupDetailsService.UploadExcel(lstGroupModels, lModel.UserId);

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
