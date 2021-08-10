using Cgm.Ecoupon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application.Impl
{
    public class EcouponService: IEcouponService
    {
        private readonly IEcouponRepository _ecouponRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly ICompanyDetailsRepository _companyDetailsRepository;
        private Random random;

        public EcouponService(IEcouponRepository ecouponRepository, IBranchRepository branchRepository, ICompanyDetailsRepository companyDetailsRepository)
        {
            _ecouponRepository = ecouponRepository;
            _branchRepository = branchRepository;
            _companyDetailsRepository = companyDetailsRepository;
            random = new Random();  

        }

        public async Task<bool> AddEcouponDetails(string EcouponName, string EcouponDescription, string BatchNo, uint Quantity, DateTime StartDate, DateTime EndDate, string userId)
        {
            var response = 
                await
                    _ecouponRepository.AddEcouponDetails(EcouponName, EcouponDescription, BatchNo, Quantity, StartDate, EndDate, userId);
            if (response.Item1)
            {
                var ecouponNumbers = await generateRandomEcouponNumbers(EcouponName, BatchNo, Quantity);
                var ecouponNumberResponse = await _ecouponRepository.AddNumbers(ecouponNumbers, response.Item2);
            }
            return response.Item1;
        }

        private async Task<List<string>> generateRandomEcouponNumbers(string ecouponName, string batchNo, uint quantity)
        {
            List<int> randomList = new List<int>();

            while(randomList.Count < quantity)
            {
                int MyNumber = random.Next(0, 999999);
                while (randomList.Contains(MyNumber))
                    MyNumber = random.Next(0, 999999);
                randomList.Add(MyNumber);
            }
            var ecouponCodes = randomList.Select(x => ecouponName.Substring(0,2) + batchNo.Substring(0,2)+x)
                        .ToList();
            return ecouponCodes;
        }

        public async  Task<bool> AllocateEcoupons(string ecouponName, string batchNo, uint allocatedQuantity, bool allocationType, string companyName, string branchName, string division, string district, string city, string township, string userId)
        {
            var ecouponData = await _ecouponRepository.GetEcouponDetailsByName(ecouponName, batchNo);
            if(ecouponData == null)
            {
                return false;
            }
            //true is for company branch and false for location based
            var EcouponAllocationId = Guid.NewGuid();
            if (allocationType)
            {
                var company = await _companyDetailsRepository.GetCompanyDetailsByName(companyName);
                if(company!= null)
                {
                    var branch = await _branchRepository.GetBranchByCompanyId(company.Id, branchName);
                    if (branch != null)
                    {
                        var response = await _ecouponRepository.AllocateEcoupons(EcouponAllocationId,ecouponData.Id, branch.BranchId, allocationType, allocatedQuantity, userId);
                        return response;
                    }
                }
                
                // get the branch id
            }else
            {
                return false;
                // get the location related details
            }
            return false;
        }

        public async Task<bool> ActivateEcoupons(string ecouponName, string batchNo, int couponDiscount, int activationType, string companyName, string branchName, string division, string district, string city, string township, string userId, bool activate)
        {
            List<Guid> AllocationIds = new List<Guid>();
            switch (activationType) {
                case 0:
                    AllocationIds = await GetAllocationIdsByBranch(companyName, branchName);
                    break;
                case 1:
                    AllocationIds = await GetAllocationIdsByLocation(division, district, city, township);
                    break;
                case 2:
                    AllocationIds = await GetAllocationIdsByBatchNo(batchNo);
                    break;
                default:
                    AllocationIds = await GetAllocationIdsByBranch(companyName, branchName);
                    break;
            }

            var response = await _ecouponRepository.ActivateCoupons(AllocationIds,couponDiscount, activate, userId);
            return response;
        }

        private async Task<List<Guid>> GetAllocationIdsByBatchNo(string batchNo)
        {
            return await _ecouponRepository.GetAllocationIdsByBatchNo(batchNo);
        }

        private Task<List<Guid>> GetAllocationIdsByLocation(string division, string district, string city, string township)
        {
            throw new NotImplementedException();
        }

        private async Task<List<Guid>> GetAllocationIdsByBranch(string companyName, string branchName)
        {
            throw new NotImplementedException();
        }
    }
}
