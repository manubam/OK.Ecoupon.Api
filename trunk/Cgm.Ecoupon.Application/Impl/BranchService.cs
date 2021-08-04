using Cgm.Ecoupon.Domain.Branch;
using Cgm.Ecoupon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application.Impl
{
    public class BranchService : IBranchService
    {
        private IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<Tuple<int, string, List<DivisionModel>>> GetAllDivisionList()
        {
            return await _branchRepository.GetAllDivisionList();
        }

        public async Task<Tuple<int, string, List<TownShipModel>>> GetAllTownShipList()
        {
            return await _branchRepository.GetAllTownShipList();
        }

        public async Task<Tuple<int, string, List<TownShipModel>>> GetTownShipByDivisionId(Guid divisionId)
        {
            return await _branchRepository.GetTownShipByDivisionId(divisionId);
        }

        public async Task<Tuple<int, string, List<CityModel>>> GetCityByTownShipId(Guid townShipId)
        {
            return await _branchRepository.GetCityByTownShipId(townShipId);
        }

        public async Task<Tuple<int, string, List<DistrictModel>>> GetDistrictByTownShipId(Guid townShipId)
        {
            return await _branchRepository.GetDistrictByTownShipId(townShipId);
        }

        public async Task<Tuple<int, string>> AddBranch(Guid companyId, Guid divisionId, Guid townShipId, Guid? cityId, Guid? districtId, string branchName,
            string branchBName, string description, string bDescription, string createdUserId, List<BranchMobileNumberModel> lstBranchMobileNumberModels)
        {
            return
                await
                    _branchRepository.AddBranch(companyId, divisionId, townShipId, cityId, districtId, branchName, branchBName,
                        description, bDescription, createdUserId, lstBranchMobileNumberModels);
        }

        public async Task<Tuple<int, string>> UpdateBranch(Guid branchId, Guid companyId, Guid divisionId, Guid townShipId, Guid? cityId, Guid? districtId,
            string branchName, string branchBName, string description, string bDescription, string createdUserId, List<BranchMobileNumberModel> lstBranchMobileNumberModels)
        {
            return
                 await
                     _branchRepository.UpdateBranch(branchId, companyId, divisionId, townShipId, cityId, districtId, branchName, branchBName,
                         description, bDescription, createdUserId, lstBranchMobileNumberModels);
        }

        public async Task<Tuple<int, string>> DeleteBranch(Guid branchId, string createdUserId)
        {
            return
                await
                    _branchRepository.DeleteBranch(branchId, createdUserId);
        }

        public async Task<Tuple<int, string, List<BranchModel>>> GetAllBranch(bool? isActive = null)
        {
            return
                await
                    _branchRepository.GetAllBranch(isActive);
        }

        public async Task<Tuple<int, string, BranchModel>> GetBranchById(Guid branchId)
        {
            return
               await
                   _branchRepository.GetBranchById(branchId);
        }

        public async Task<Tuple<int, string>> BranchAlreadyExist(Guid companyId, Guid divisionId, Guid townShipId, Guid? cityId, Guid? districtId,
            string branchName)
        {
            return
              await
                  _branchRepository.BranchAlreadyExist(companyId, divisionId, townShipId, cityId, districtId, branchName);
        }

        public async Task<Tuple<int, string, List<CustomerModel>>> GetCustomerList()
        {
            return await _branchRepository.GetCustomerList();
        }

        public async Task<Tuple<int, string>> UploadExcel(List<BranchModel> objBranchModel, string userId)
        {
            return
             await
                 _branchRepository.UploadExcel(objBranchModel, userId);
        }

        public async Task<Tuple<int, string, List<BranchModel>>> GatBranchByOfferCode(Guid offerid)
        {
            return await _branchRepository.GatBranchByOfferCode(offerid);
        }
    }
}
