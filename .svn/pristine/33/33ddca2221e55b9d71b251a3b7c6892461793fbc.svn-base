using Cgm.Ecoupon.Api.Models.Product.ProductDetails;
using Cgm.Ecoupon.Api.Response;
using Cgm.Ecoupon.Application;
using Cgm.Ecoupon.Domain.Product.ProductDetails;
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
    public class ProductController : BaseController
    {
        private static readonly ILog Log =
    LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IProductDetailsService _productDetailsService;

        public ProductController(IProductDetailsService productDetailsService)
        {
            _productDetailsService = productDetailsService;
        }


        [HttpPost]
        [Route(Constants.Routes.Paths.AddProduct)]
        public async Task<IHttpActionResult> Add([FromBody] AddProductDto lModel)
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
                        _productDetailsService.AddProductDetails(lModel.ProductCategoryId, lModel.ProductBrandId, lModel.ProductGroupId, lModel.ProductCode, lModel.ProductName,
                        lModel.ProductDescription, lModel.ProductImageUrl,
                        lModel.UserId);
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
                Log.Error("AddProduct :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UpdateProduct)]
        public async Task<IHttpActionResult> Update([FromBody] ProductDto lModel)
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
                else if (lModel.ProductId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid ProductId or UserId"
                    };
                    return Ok(response);
                }

                var res =
                   await
                       _productDetailsService.UpdateProductDetails(lModel.ProductId, lModel.ProductCategoryId, lModel.ProductBrandId, lModel.ProductGroupId, lModel.ProductCode, lModel.ProductName, lModel.ProductDescription, lModel.ProductImageUrl, lModel.UserId);
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
                Log.Error("UpdateProduct :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.DeleteProduct)]
        public async Task<IHttpActionResult> DeleteProduct([FromBody] DeleteProductDto lModel)
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
                else if (lModel.ProductId == new Guid() || string.IsNullOrEmpty(lModel.UserId))
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid ProductId or UserId"
                    };
                    return Ok(response);
                }

                var res =
                    await
                        _productDetailsService.DeleteProductDetails(lModel.ProductId, lModel.UserId);
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
                Log.Error("DeleteProduct :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductById)]
        public async Task<IHttpActionResult> GetProductById(Guid id)
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
                        _productDetailsService.GetProductDetailsId(id);
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
                            Message = "Invalid ProductId"
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
                Log.Error("GetProductById :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetAllProduct)]
        public async Task<IHttpActionResult> GetAllProduct(bool? isActive = null)
        {
            try
            {
                var res =
                    await
                        _productDetailsService.GetAllProductDetails(isActive);
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
                Log.Error("GetAllProduct :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.ProductAlreadyExist)]
        public async Task<IHttpActionResult> ProductAlreadyExist(string productCode)
        {
            try
            {
                var res =
                    await
                        _productDetailsService.ProductAlreadyExist(productCode);
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
                Log.Error("ProductAlreadyExist :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpPost]
        [Route(Constants.Routes.Paths.UploadProduct)]
        public async Task<IHttpActionResult> UploadExcel([FromBody] UploadProductDto lModel)
        {
            try
            {
                if (lModel.ProductList == null)
                {
                    var response = new CommonResponseModel<object>()
                    {
                        Code = 300,
                        Message = "Invalid Input"
                    };
                    return Ok(response);
                }

                List<ProductDetailsModel> lstProductModels = lModel.ProductList.Select(obj => new ProductDetailsModel
                {
                    ProductId = obj.ProductId,
                    ProductCategoryName = obj.ProductCategoryName,
                    ProductBrandName = obj.ProductBrandName,
                    ProductGroupName = obj.ProductGroupName,
                    ProductCode = obj.ProductCode,
                    ProductName = obj.ProductName,
                    ProductDescription = obj.ProductDescription,
                    ProductImageUrl = obj.ProductImageUrl
                }).ToList();

                var res = await _productDetailsService.UploadExcel(lstProductModels, lModel.UserId);

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
        [Route(Constants.Routes.Paths.GetProductGroupByProductMapping)]
        public async Task<IHttpActionResult> GetProductGroupByProductMapping()
        {
            try
            {
                //if (companyid == Guid.NewGuid())
                //{
                //    var response = new CommonResponseModel<object>()
                //    {
                //        Code = 300,
                //        Message = "Invalid Input"
                //    };
                //    return Ok(response);
                //}

                var res =
                    await
                        _productDetailsService.GetProductGroupByProductMapping();
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
                Log.Error("GetProductGroupByProductMapping :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductBrandByProductMapping)]
        public async Task<IHttpActionResult> GetProductBrandByProductMapping()
        {
            try
            {
                //if (companyid == Guid.NewGuid())
                //{
                //    var response = new CommonResponseModel<object>()
                //    {
                //        Code = 300,
                //        Message = "Invalid Input"
                //    };
                //    return Ok(response);
                //}

                var res =
                    await
                        _productDetailsService.GetProductBrandByProductMapping();
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
                Log.Error("GetProductBrandByProductMapping :: 500 :: " + ex.Message);
                var response = new CommonResponseModel<object>()
                {
                    Code = 500,
                    Message = "system error, please contact admin",
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route(Constants.Routes.Paths.GetProductCategoryByProductMapping)]
        public async Task<IHttpActionResult> GetProductCategoryByProductMapping()
        {
            try
            {
                //if (companyid == Guid.NewGuid())
                //{
                //    var response = new CommonResponseModel<object>()
                //    {
                //        Code = 300,
                //        Message = "Invalid Input"
                //    };
                //    return Ok(response);
                //}

                var res =
                    await
                        _productDetailsService.GetProductCategoryByProductMapping();
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
                Log.Error("GetProductCategoryByProductMapping :: 500 :: " + ex.Message);
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
