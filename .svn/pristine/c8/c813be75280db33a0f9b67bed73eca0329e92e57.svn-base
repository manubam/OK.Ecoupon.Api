using Cgm.Ecoupon.Domain.CompanyDetails;
using Cgm.Ecoupon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application.Impl
{
    public class CompanyDetailsService : ICompanyDetailsService
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository;

        public CompanyDetailsService(ICompanyDetailsRepository companyDetailsRepository)
        {
            _companyDetailsRepository = companyDetailsRepository;
        }
        public async Task<bool> AddCompanyDetails(string companyName, string companyBName, string companyDescription, string companyImageUrl,
            string userId, string backendMobileNumber, string backendMobileNumberPassword)
        {
            return
                await
                    _companyDetailsRepository.AddCompanyDetails(companyName, companyBName, companyDescription,
                        companyImageUrl, userId, backendMobileNumber, backendMobileNumberPassword);
        }

        public async Task<bool> UpdateCompanyDetails(Guid id, string companyName, string companyBName, string companyDescription,
            string companyImageUrl, string userId, Guid offerBackendNumberId, string backendMobileNumber, string backendMobileNumberPassword)
        {
            return
                await
                    _companyDetailsRepository.UpdateCompanyDetails(id, companyName, companyBName, companyDescription,
                        companyImageUrl, userId, offerBackendNumberId, backendMobileNumber, backendMobileNumberPassword);
        }

        public async Task<Tuple<int, string>> DeleteCompanyDetails(Guid id, string userId)
        {
            return
                await
                    _companyDetailsRepository.DeleteCompanyDetails(id, userId);
        }

        public async Task<Tuple<int, CompanyDetailsModel>> GetCompanyDetailsById(Guid id)
        {
            return
               await
                   _companyDetailsRepository.GetCompanyDetailsById(id);
        }

        public async Task<Tuple<int, List<CompanyDetailsModel>>> GetAllCompanyDetails(bool? isActive)
        {
            return
               await
                   _companyDetailsRepository.GetAllCompanyDetails(isActive);
        }

        public async Task<bool> CompanyAlreadyExist(string companyName)
        {
            return await
                _companyDetailsRepository.CompanyAlreadyExist(companyName);
        }

        public async Task<bool> CompanyNumberAlreadyExist(Guid offerBackendNumberId, string mobileNumber)
        {
            return await
                _companyDetailsRepository.CompanyNumberAlreadyExist(offerBackendNumberId, mobileNumber);
        }

        public async Task<Tuple<int, string>> UploadExcel(List<CompanyDetailsModel> objCompanyDetailsModel, string userId)
        {
            return
             await
                 _companyDetailsRepository.UploadExcel(objCompanyDetailsModel, userId);
        }

    }
}
