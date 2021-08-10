using Cgm.Ecoupon.Domain.Branch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Infrastructure.Persistence
{
    public interface IBranchRepository
    {
        Task<Tuple<int, string, List<DivisionModel>>> GetAllDivisionList();

        Task<Tuple<int, string, List<TownShipModel>>> GetAllTownShipList();

        Task<Tuple<int, string, List<TownShipModel>>> GetTownShipByDivisionId(Guid divisionId);

        Task<Tuple<int, string, List<CityModel>>> GetCityByTownShipId(Guid townShipId);

        Task<Tuple<int, string, List<DistrictModel>>> GetDistrictByTownShipId(Guid townShipId);

        Task<Tuple<int, string>> AddBranch(Guid companyId, Guid divisionId, Guid townShipId, Guid? cityId,
            Guid? districtId, string branchName, string branchBName, string description, string bDescription,
            string createdUserId, List<BranchMobileNumberModel> lstBranchMobileNumberModels);

        Task<Tuple<int, string>> UpdateBranch(Guid branchId, Guid companyId, Guid divisionId, Guid townShipId, Guid? cityId, Guid? districtId,
            string branchName, string branchBName, string description, string bDescription, string createdUserI, List<BranchMobileNumberModel> lstBranchMobileNumberModelsd);

        Task<Tuple<int, string>> DeleteBranch(Guid branchId, string createdUserId);

        Task<Tuple<int, string, List<BranchModel>>> GetAllBranch(bool? isActive = null);

        Task<Tuple<int, string, BranchModel>> GetBranchById(Guid branchId);

        Task<Tuple<int, string>> BranchAlreadyExist(Guid companyId, Guid divisionId, Guid townShipId,
            Guid? cityId, Guid? districtId, string branchName);

        Task<Tuple<int, string, List<CustomerModel>>> GetCustomerList();

        Task<Tuple<int, string>> UploadExcel(List<BranchModel> objBranchModel, string userId);

        Task<Tuple<int, string, List<BranchModel>>> GatBranchByOfferCode(Guid offerid);
        Task<BranchModel> GetBranchByCompanyId(Guid companyId, string branchName);
    }
}
