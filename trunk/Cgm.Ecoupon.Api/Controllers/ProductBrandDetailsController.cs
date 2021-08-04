using Cgm.Ecoupon.Api.Models.Product.ProductBrandDetails;
using Cgm.Ecoupon.Api.Response;
using Cgm.Ecoupon.Application;
using Cgm.Ecoupon.Domain.Product.ProductbrandDetails;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cgm.Ecoupon.Api.Controllers
{
    public class ProductBrandDetailsController : BaseController
    {
        private static readonly ILog Log =
         LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IProductBrandDetailsService _productBrandDetailsService;

        public ProductBrandDetailsController(IProductBrandDetailsService productBrandDetailsService)
        {
            _productBrandDetailsService = productBrandDetailsService;
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.AddProductBrandDetails)]
        public async Task<IHttpActionResult> Add([FromBody] ProductBrandDetailAddDto lModel)
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
                        _productBrandDetailsService.AddProductBrandDetails(lModel.ProductBrandCode, lModel.ProductBrandName,
                            lModel.ProductBrandDescription, lModel.ProductBrandAlieas, lModel.UserId, lModel.IsActive);
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
                Log.Error("AddProductBrandDetails :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UpdateProductBrandDetails)]
        public async Task<IHttpActionResult> Update([FromBody] ProductBrandDetailDto lModel)
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
                else if (lModel.ProductBrandId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid ProductBrandId or UserId"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _productBrandDetailsService.UpdateProductBrandDetails(lModel.ProductBrandId, lModel.ProductBrandCode, lModel.ProductBrandName,
                            lModel.ProductBrandDescription, lModel.ProductBrandAlieas, lModel.UserId, lModel.IsActive);
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
                Log.Error("UpdateProductBrandDetails :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.ProductBrandDetailsDelete)]
        public async Task<IHttpActionResult> ProductBrandDetailsDelete([FromBody] ProductBrandDetailDeleteDto lModel)
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
                else if (lModel.ProductBrandId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
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
                        _productBrandDetailsService.DeleteProductBrandDetails(lModel.ProductBrandId, lModel.UserId);

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
                Log.Error("DeleteProductBrandDetails :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductBrandDetailsById)]
        public async Task<IHttpActionResult> GetProductBrandDetailsById(Guid id)
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
                        _productBrandDetailsService.GetProductBrandDetailsById(id);
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
                Log.Error("GetProductBrandDetailsById :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetAllProductBrandDetails)]
        public async Task<IHttpActionResult> GetAllProductBrandDetails(bool? isActive = null)
        {
            try
            {
                var res =
                    await
                        _productBrandDetailsService.GetAllProductBrandDetails(isActive);
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
                Log.Error("GetAllProductBrandDetails :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.ProductBrandAlreadyExist)]
        public async Task<IHttpActionResult> ProductBrandAlreadyExist(string brandCode)
        {
            try
            {
                var res =
                    await
                        _productBrandDetailsService.ProductBrandAlreadyExist(brandCode);
                if (res)
                {
                    return Ok(new CommonResponseModel<object>()
                    {
                        Data = true,
                        Code = 200,
                        Message = brandCode + " Data alredy exist"
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
                Log.Error("ProductBrandAlreadyExist :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.ProductBrandNameAlreadyExist)]
        public async Task<IHttpActionResult> ProductBrandNameAlreadyExist(string brandName)
        {
            try
            {
                var res =
                    await
                        _productBrandDetailsService.ProductBrandNameAlreadyExist(brandName);
                if (res)
                {
                    return Ok(new CommonResponseModel<object>()
                    {
                        Data = true,
                        Code = 200,
                        Message = brandName + " Data alredy exist"
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
                Log.Error("ProductBrandAlreadyExist :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UploadBrand)]
        public async Task<IHttpActionResult> UploadExcel([FromBody] UploadProductBrandDetailDto lModel)
        {
            try
            {
                if (lModel.ProductBrandList == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                List<ProductBrandDetailModel> lstBrandModels = lModel.ProductBrandList.Select(obj => new ProductBrandDetailModel
                {
                    Id = obj.ProductBrandId,
                    ProductBrandCode = obj.ProductBrandCode,
                    ProductBrandName = obj.ProductBrandName,
                    ProductBrandDescription = obj.ProductBrandDescription,
                    ProductBrandAlieas = obj.ProductBrandAlieas
                }).ToList();

                var res = await _productBrandDetailsService.UploadExcel(lstBrandModels, lModel.UserId);

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
