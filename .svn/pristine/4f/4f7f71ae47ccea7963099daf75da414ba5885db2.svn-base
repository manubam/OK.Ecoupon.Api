using Cgm.Ecoupon.Domain.CompanyDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Application
{
    public interface ICompanyDetailsService
    {
        Task<bool> AddCompanyDetails(string companyName, string companyBName, string companyDescription,
          string companyImageUrl, string userId, string backendMobileNumber, string backendMobileNumberPassword);

        Task<bool> UpdateCompanyDetails(Guid id, string companyName, string companyBName, string companyDescription,
            string companyImageUrl, string userId, Guid offerBackendNumberId, string backendMobileNumber, string backendMobileNumberPassword);

        Task<Tuple<int, string>> DeleteCompanyDetails(Guid id, string userId);

        Task<Tuple<int, CompanyDetailsModel>> GetCompanyDetailsById(Guid id);

        Task<Tuple<int, List<CompanyDetailsModel>>> GetAllCompanyDetails(bool? isActive);

        Task<bool> CompanyAlreadyExist(string companyName);

        Task<bool> CompanyNumberAlreadyExist(Guid offerBackendNumberId, string mobileNumber);

        Task<Tuple<int, string>> UploadExcel(List<CompanyDetailsModel> objCompanyDetailsModel, string userId);
    }
}
