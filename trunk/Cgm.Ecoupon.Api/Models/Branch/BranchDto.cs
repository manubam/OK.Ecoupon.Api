using System;
using System.Collections.Generic;

namespace Cgm.Ecoupon.Api.Models.Branch
{
    public class BranchDto
    {
        public Guid Id { get; set; }
        public string BranchName { get; set; }
        public string BranchBName { get; set; }
        public string Description { get; set; }
        public string BDescription { get; set; }
        public bool IsActive { get; set; }
        public string CompanyName { get; set; }
        public string DivisionName { get; set; }
        public string TownShipName { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
    }

    public class AddBranchDto
    {
        public System.Guid CompanyId { get; set; }
        public System.Guid DivisionId { get; set; }
        public System.Guid TownShipId { get; set; }
        public Nullable<System.Guid> CityId { get; set; }
        public Nullable<System.Guid> DistrictId { get; set; }
        public string BranchName { get; set; }
        public string BranchBName { get; set; }
        public string Description { get; set; }
        public string BDescription { get; set; }
        public string CreatedUserId { get; set; }
        public List<BranchMobileNumberDtoAdd> BranchMobileNumberDtoList { get; set; }
    }

    public class UpdateBranchDto
    {
        public System.Guid BranchId { get; set; }
        public System.Guid CompanyId { get; set; }
        public System.Guid DivisionId { get; set; }
        public System.Guid TownShipId { get; set; }
        public Nullable<System.Guid> CityId { get; set; }
        public Nullable<System.Guid> DistrictId { get; set; }
        public string BranchName { get; set; }
        public string BranchBName { get; set; }
        public string Description { get; set; }
        public string BDescription { get; set; }
        public string CreatedUserId { get; set; }
        public List<BranchMobileNumberDtoUpdate> BranchMobileNumberDtoList { get; set; }
    }

    public class DeleteBranchDto
    {
        public System.Guid BranchId { get; set; }
        public string CreatedUserId { get; set; }
    }

    public class BranchExistDto
    {
        public System.Guid BranchId { get; set; }
        public System.Guid CompanyId { get; set; }
        public System.Guid DivisionId { get; set; }
        public System.Guid TownShipId { get; set; }
        public Nullable<System.Guid> CityId { get; set; }
        public Nullable<System.Guid> DistrictId { get; set; }
        public string BranchName { get; set; }
    }

    public class UploadBranchDetailsDto
    {
        public List<BranchDto> BranchDetailsList { get; set; }
        public string UserId { get; set; }
    }
}