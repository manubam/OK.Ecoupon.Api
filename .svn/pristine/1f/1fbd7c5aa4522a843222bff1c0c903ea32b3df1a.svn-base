using System;
using System.Collections.Generic;

namespace Cgm.Ecoupon.Api.Models.CompanyProductMapping
{
    public class CompanyAndProductMappingDto
    {
        public Guid CompanyId { get; set; }

        public List<Guid> BranchIdList { get; set; }

        public List<Guid> ProductIdList { get; set; }

        public string CreatedUserId { get; set; }
    }

    public class AddCompanyAndProductMappingDto
    {
        public Guid CompanyId { get; set; }

        public List<Guid> BranchIdList { get; set; }

        public List<Guid> ProductIdList { get; set; }

        public string CreatedUserId { get; set; }
    }

    public class UpdateCompanyAndProductMappingDto
    {
        public Guid CompanyAndProductMappingId { get; set; }
        public Guid CompanyId { get; set; }
        public List<Guid> BranchIdList { get; set; }

        public List<Guid> ProductIdList { get; set; }

        public string CreatedUserId { get; set; }
    }

    public class GatProductByFiltersDto
    {
        public List<Guid> ProductGroupListId { get; set; }

        public List<Guid> ProductBrandListId { get; set; }

        public List<Guid> ProductCategoryListId { get; set; }

    }

    public class GetProductGroupByCompanyAndBranchDto
    {
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
    }
}