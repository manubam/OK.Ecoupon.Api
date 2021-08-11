namespace Cgm.Ecoupon.Api
{
    public class Constants
    {
        public static class Routes
        {
            public static class Paths
            {  
                #region Company Details

                public const string AddCompanyDetails = "CompanyDetails/Add";

                public const string UpdateCompanyDetails = "CompanyDetails/Update";

                public const string DeleteCompanyDetails = "CompanyDetails/Delete";

                public const string GetCompanyDetailsById = "CompanyDetails/GetCompanyDetailsById/{id}";

                public const string GetAllCompanyDetails = "CompanyDetails/GetAllCompanyDetails/{isActive?}";

                public const string CompanyAlreadyExist = "CompanyDetails/CompanyAlreadyExist/{companyName}";

                public const string CompanyNumberAlreadyExist = "CompanyDetails/CompanyNumberAlreadyExist";

                public const string UploadCompany = "CompanyDetails/UploadExcel";

                #endregion

                #region BranchDetails

                public const string GetAllDivision = "Branch/GetAllDivision"; 

                public const string GetAllTownShip = "Branch/GetAllTownShip";

                public const string GetTownShipByDivisionId = "Branch/GetTownShipByDivisionId/{divisionId}";

                public const string GetCityByTownShipId = "Branch/GetCityByTownShipId/{townShipId}";

                public const string GetDistrictByTownShipId = "Branch/GetDistrictByTownShipId/{townShipId}";

                public const string AddBranch = "Branch/AddBranch";

                public const string UpdateBranch = "Branch/UpdateBranch";

                public const string DeleteBranch = "Branch/DeleteBranch";

                public const string GetAllBranch = "Branch/GetAllBranch/{isActive?}";

                public const string GetBranchById = "Branch/GetBranchById/{branchId}";

                public const string BranchAlreadyExist = "Branch/BranchAlreadyExist";

                public const string GetCustomer = "Branch/GetCustomer";

                public const string UploadBranch = "Branch/UploadExcel";

                public const string GatBranchByOfferCode = "Branch/GatBranchByOfferCode/{offerid}";

                #endregion

                #region Product Group Details

                public const string AddProductGroup = "ProductGroup/Add";

                public const string UpdateProductGroup = "ProductGroup/Update";

                public const string ProductGroupDelete = "ProductGroup/Delete";

                public const string GetProductGroupById = "ProductGroup/GetProductGroupById/{id}";

                public const string GetAllProductGroup = "ProductGroup/GetAllProductGroup/{isActive?}";

                public const string ProductGroupAlreadyExist = "ProductGroup/ProductGroupAlreadyExist/{productGroupName}";

                public const string UploadGroup = "ProductGroup/UploadExcel";

                #endregion

                #region Product Category Details

                public const string AddProductCategory = "ProductCategory/Add";

                public const string UpdateProductCategory = "ProductCategory/Update";

                public const string ProductCategoryDelete = "ProductCategory/Delete";

                public const string GetProductCategoryById = "ProductCategory/GetProductCategoryById/{id}";

                public const string GetAllProductCategory = "ProductCategory/GetAllProductCategory/{isActive?}";

                public const string ProductCategoryAlreadyExist = "ProductCategory/ProductCategoryAlreadyExist/{productCategoryName}";

                public const string UploadCategory = "ProductCategory/UploadExcel";

                #endregion

                #region Product Brand Details

                public const string AddProductBrandDetails = "ProductBrandDetails/Add";

                public const string UpdateProductBrandDetails = "ProductBrandDetails/Update";

                public const string ProductBrandDetailsDelete = "ProductBrandDetails/ProductBrandDetailsDelete";

                public const string GetProductBrandDetailsById = "ProductBrandDetails/GetProductBrandDetailsById/{id}";

                public const string GetAllProductBrandDetails = "ProductBrandDetails/GetAllProductBrandDetails/{isActive?}";

                public const string ProductBrandAlreadyExist = "ProductBrandDetails/ProductBrandAlreadyExist/{brandCode}";

                public const string ProductBrandNameAlreadyExist = "ProductBrandDetails/ProductBrandNameAlreadyExist/{brandName}";

                public const string UploadBrand = "ProductBrandDetails/UploadExcel";

                #endregion

                #region Product Details

                public const string AddProduct = "Product/Add";

                public const string UpdateProduct = "Product/Update";

                public const string DeleteProduct = "Product/Delete";

                public const string GetProductById = "Product/GetProductById/{id}";

                public const string GetAllProduct = "Product/GetAllProduct/{isActive?}";

                public const string ProductAlreadyExist = "Product/ProductAlreadyExist/{productCode}";

                public const string UploadProduct = "Product/UploadExcel";

                public const string GetProductGroupByProductMapping = "Product/GetProductGroupByProductMapping";

                public const string GetProductBrandByProductMapping = "Product/GetProductBrandByProductMapping";

                public const string GetProductCategoryByProductMapping = "Product/GetProductCategoryByProductMapping";

                #endregion

                #region CompanyProductMappingDetails

                public const string AddCompanyAndProductMapping = "CompanyProductMapping/AddCompanyAndProductMapping";

                public const string UpdateCompanyAndProductMapping = "CompanyProductMapping/UpdateCompanyAndProductMapping";

                public const string GatBranchByCompanyId = "CompanyProductMapping/GatBranchByCompanyId/{id}";

                public const string GatProductByFilters = "CompanyProductMapping/GatProductByFilters";

                public const string GetCompanyAndProductMappingList = "CompanyProductMapping/GetCompanyAndProductMappingList";

                public const string GetCompanyAndProductMappingById = "CompanyProductMapping/GetCompanyAndProductMappingById/{id}";

                public const string GetProductGroupByCompanyIdandBranchId = "CompanyProductMapping/GetProductGroupByCompanyIdandBranchId";

                public const string GetProductGroupByCompanyId = "CompanyProductMapping/GetProductGroupByCompanyId/{companyid}";

                public const string GetProductBrandByCompanyId = "CompanyProductMapping/GetProductBrandByCompanyId/{companyid}";

                public const string GetProductCategoryByCompanyId = "CompanyProductMapping/GetProductCategoryByCompanyId/{companyid}";

                public const string GetProductDetailsByCompanyId = "CompanyProductMapping/GetProductDetailsByCompanyId/{companyid}";

                #endregion

                #region Ecoupons
                public const string AddEcoupon       = "Ecoupon/Add";
                public const string AllocateEcoupons = "Ecoupon/AllocateEcoupons";
                public const string ActivateEcoupons = "Ecoupon/ActivateEcoupons";
                public const string RedeemEcoupons   = "Ecoupon/RedeemEcoupons";
                public const string GetRedeemedEcoupons = "Ecoupon/GetRedeemEcoupons/{ecouponName}/{batchNo}/{offset}/{limit}";
                #endregion
            }
        }
    }
}