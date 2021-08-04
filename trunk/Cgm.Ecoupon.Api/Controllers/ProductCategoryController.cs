using Cgm.Ecoupon.Api.Models.Product.ProductCategory;
using Cgm.Ecoupon.Api.Response;
using Cgm.Ecoupon.Application;
using Cgm.Ecoupon.Domain.Product.ProductCategoryDetails;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cgm.Ecoupon.Api.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private static readonly ILog Log =
    LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IProductCategoryDetailsService _productCategoryDetailsService;

        public ProductCategoryController(IProductCategoryDetailsService productCategoryDetailsService)
        {
            _productCategoryDetailsService = productCategoryDetailsService;
        }


        [HttpPost]
        [Route(Constants.Routes.Paths.AddProductCategory)]
        public async Task<IHttpActionResult> Add([FromBody] ProductCategoryAddDto lModel)
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
                        _productCategoryDetailsService.AddProductCategoryDetails(lModel.ProductCategoryName, lModel.ProductCategoryDescription, lModel.UserId, lModel.IsActive);
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
                Log.Error("AddProductCategory :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UpdateProductCategory)]
        public async Task<IHttpActionResult> Update([FromBody] ProductCategoryDto lModel)
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
                else if (lModel.ProductCategoryId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid UpdateProductCategory or UserId"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _productCategoryDetailsService.UpdateProductCategoryDetails(lModel.ProductCategoryId, lModel.ProductCategoryName, lModel.ProductCategoryDescription, lModel.UserId, lModel.IsActive);
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
                Log.Error("UpdateProductCategory :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.ProductCategoryDelete)]
        public async Task<IHttpActionResult> ProductCategoryDelete([FromBody] ProductCategoryDeleteDto lModel)
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
                else if (lModel.ProductCategoryId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
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
                        _productCategoryDetailsService.DeleteProductCategoryDetails(lModel.ProductCategoryId, lModel.UserId);
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
                Log.Error("DeleteProductCategory :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductCategoryById)]
        public async Task<IHttpActionResult> GetProductCategoryById(Guid id)
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
                        _productCategoryDetailsService.GetProductCategoryDetailsId(id);
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
                            Message = "Invalid ProductCategoryId"
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
                Log.Error("GetProductCategoryById :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetAllProductCategory)]
        public async Task<IHttpActionResult> GetAllProductCategory(bool? isActive = null)
        {
            try
            {
                var res =
                    await
                        _productCategoryDetailsService.GetAllProductCategoryDetails(isActive);
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
                            Message = "Invalid Product Category Id"
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
                Log.Error("GetAllProductCategory :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.ProductCategoryAlreadyExist)]
        public async Task<IHttpActionResult> ProductCategoryAlreadyExist(string productCategoryName)
        {
            try
            {
                var res =
                    await
                        _productCategoryDetailsService.ProductCategoryAlreadyExist(productCategoryName);
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
                Log.Error("ProductCategoryAlreadyExist :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UploadCategory)]
        public async Task<IHttpActionResult> UploadExcel([FromBody] UploadProductCategoryDto lModel)
        {
            try
            {
                if (lModel.ProductCategoryList == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                List<ProductCategoryDetailsModel> lstCategoryModels = lModel.ProductCategoryList.Select(obj => new ProductCategoryDetailsModel
                {
                    Id = obj.ProductCategoryId,
                    ProductCategoryName = obj.ProductCategoryName,
                    ProductCategoryDescription = obj.ProductCategoryDescription
                }).ToList();

                var res = await _productCategoryDetailsService.UploadExcel(lstCategoryModels, lModel.UserId);

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
