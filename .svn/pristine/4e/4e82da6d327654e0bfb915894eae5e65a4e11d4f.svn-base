using Cgm.Ecoupon.Domain.CompanyDetails;
using Cgm.Ecoupon.Infrastructure.Persistence.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Cgm.Ecoupon.Infrastructure.Persistence.Repositories
{
    //[assembly: log4net.Config.XmlConfigurator(Watch = true)]
    public class CompanyDetailsRepository : ICompanyDetailsRepository
    {
        private static readonly ILog Log =
             LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<bool> AddCompanyDetails(string companyName, string companyBName, string companyDescription, string companyImageUrl, string userId, string backendMobileNumber, string backendMobileNumberPassword)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    //var alreadyExistsBackendNo = await dbContext.OfferBackendNumbers.FirstOrDefaultAsync(x => x.BackendMobileNumber == backendMobileNumber && x.IsActive == true);

                    CompanyDetail lCompanyDetail = new CompanyDetail
                    {
                        Id = Guid.NewGuid(),
                        CompanyName = companyName,
                        CompanyBName = companyBName,
                        CompanyImageUrl = companyImageUrl,
                        CompanyDescription = companyDescription,
                        IsActive = true,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now
                    };

                    dbContext.CompanyDetails.Add(lCompanyDetail);

                    OfferBackendNumber lOfferBackendNumber = new OfferBackendNumber
                    {
                        Id = Guid.NewGuid(),
                        CompanyId = lCompanyDetail.Id,
                        AliesName = lCompanyDetail.CompanyName,
                        BackendMobileNumber = backendMobileNumber,
                        BackendMobileNumberPassword = backendMobileNumberPassword,
                        IsActive = true,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now
                    };
                    dbContext.OfferBackendNumbers.Add(lOfferBackendNumber);

                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("AddCompanyDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateCompanyDetails(Guid id, string companyName, string companyBName, string companyDescription, string companyImageUrl, string userId, Guid offerBackendNumberId, string backendMobileNumber, string backendMobileNumberPassword)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyDetails.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
                    if (res == null)
                    {
                        return false;
                    }

                    res.CompanyName = companyName;
                    res.CompanyBName = companyBName;
                    res.CompanyImageUrl = companyImageUrl;
                    res.CompanyDescription = companyDescription;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    dbContext.CompanyDetails.AddOrUpdate(res);

                    var resbackend = await dbContext.OfferBackendNumbers.FirstOrDefaultAsync(x => x.Id == offerBackendNumberId && x.IsActive == true);
                    if (resbackend == null)
                    {
                        OfferBackendNumber lOfferBackendNumber = new OfferBackendNumber
                        {
                            Id = Guid.NewGuid(),
                            CompanyId = id,
                            AliesName = companyName,
                            BackendMobileNumber = backendMobileNumber,
                            BackendMobileNumberPassword = backendMobileNumberPassword,
                            IsActive = true,
                            CreatedBy = userId,
                            CreatedDate = DateTime.Now
                        };
                        dbContext.OfferBackendNumbers.Add(lOfferBackendNumber);
                        await dbContext.SaveChangesAsync();
                        return true;
                    }

                    resbackend.AliesName = companyName;
                    resbackend.BackendMobileNumber = backendMobileNumber;
                    resbackend.BackendMobileNumberPassword = backendMobileNumberPassword;
                    resbackend.ModifiedBy = userId;
                    resbackend.ModifiedDate = DateTime.Now;

                    dbContext.OfferBackendNumbers.AddOrUpdate(resbackend);

                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateCompanyDetails :: 500 :: " + ex.Message);
                return false;
            }
        }

        public async Task<Tuple<int, string>> DeleteCompanyDetails(Guid id, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {

                    var res = await dbContext.CompanyDetails.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
                    if (res == null)
                    {
                        return new Tuple<int, string>(300, "Record not found");
                    }

                    var resUser = await dbContext.Users.FirstOrDefaultAsync(x => x.CompanyId == id && x.IsActive == true);
                    if (resUser != null)
                    {
                        return new Tuple<int, string>(300, res.CompanyName + " already used so cannot delete");
                    }

                    res.IsActive = false;
                    res.ModifiedBy = userId;
                    res.ModifiedDate = DateTime.Now;
                    dbContext.CompanyDetails.AddOrUpdate(res);

                    var resItem = await dbContext.OfferBackendNumbers.FirstOrDefaultAsync(x => x.CompanyId == id && x.IsActive == true);
                    if (resItem == null)
                    {
                        return new Tuple<int, string>(300, "Record not found");
                    }

                    resItem.IsActive = false;
                    resItem.ModifiedBy = userId;
                    resItem.ModifiedDate = DateTime.Now;
                    dbContext.OfferBackendNumbers.AddOrUpdate(resItem);

                    await dbContext.SaveChangesAsync();
                    return new Tuple<int, string>(200, "Record Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateCompanyDetails :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }

        }

        public async Task<Tuple<int, List<CompanyDetailsModel>>> GetAllCompanyDetails(bool? isActive)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    List<CompanyDetailsModel> lstCompanyDetailsModels = new List<CompanyDetailsModel>();
                    if (isActive == null)
                    {
                        lstCompanyDetailsModels = await dbContext.CompanyDetails
                            .Select(z => new CompanyDetailsModel
                            {
                                Id = z.Id,
                                CompanyName = z.CompanyName,
                                CompanyBName = z.CompanyBName,
                                CompanyDescription = z.CompanyDescription,
                                CompanyImageUrl = z.CompanyImageUrl,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                    }
                    else
                    {
                        lstCompanyDetailsModels = await dbContext.CompanyDetails
                            .Where(x => x.IsActive == isActive)
                            .Select(z => new CompanyDetailsModel
                            {
                                Id = z.Id,
                                CompanyName = z.CompanyName,
                                CompanyBName = z.CompanyBName,
                                CompanyDescription = z.CompanyDescription,
                                CompanyImageUrl = z.CompanyImageUrl,
                                IsActive = z.IsActive,
                                CreatedDate = z.CreatedDate
                            }).OrderByDescending(zz => zz.CreatedDate).ToListAsync();
                    }



                    if (lstCompanyDetailsModels.Count == 0)
                    {
                        return new Tuple<int, List<CompanyDetailsModel>>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, List<CompanyDetailsModel>>(200, lstCompanyDetailsModels);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllCompanyDetails :: 500 :: " + ex.Message);
                return new Tuple<int, List<CompanyDetailsModel>>(500, null);
            }
        }

        public async Task<Tuple<int, CompanyDetailsModel>> GetCompanyDetailsById(Guid id)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyDetails
                        .Select(z => new CompanyDetailsModel
                        {
                            Id = z.Id,
                            CompanyName = z.CompanyName,
                            CompanyBName = z.CompanyBName,
                            CompanyDescription = z.CompanyDescription,
                            CompanyImageUrl = z.CompanyImageUrl,
                            IsActive = z.IsActive
                        }).FirstOrDefaultAsync(x => x.Id == id);

                    if (res != null)
                    {
                        var resObj =
                                    await dbContext.OfferBackendNumbers.Where(x => x.CompanyId == id && x.IsActive == true)
                                        .Select(z => new OfferBackendNumberModel
                                        {
                                            Id = z.Id,
                                            CompanyId = z.CompanyId,
                                            AliesName = z.AliesName,
                                            BackendMobileNumber = z.BackendMobileNumber,
                                            BackendMobileNumberPassword = z.BackendMobileNumberPassword,
                                            IsActive = z.IsActive
                                        }).ToListAsync();
                        res.OfferBackendNumberModelList = resObj;
                    }

                    if (res == null)
                    {
                        return new Tuple<int, CompanyDetailsModel>(300, null);
                    }
                    else
                    {
                        return new Tuple<int, CompanyDetailsModel>(200, res);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateCompanyDetails :: 500 :: " + ex.Message);
                return new Tuple<int, CompanyDetailsModel>(500, null);
            }
        }

        public async Task<bool> CompanyAlreadyExist(string companyName)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var res = await dbContext.CompanyDetails.Where(x => x.CompanyName == companyName && x.IsActive == true).CountAsync();
                    if (res > 0) return true;
                    return false;

                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateCompanyDetails :: 500 :: " + ex.Message);
                return true;
            }
        }

        public async Task<bool> CompanyNumberAlreadyExist(Guid offerBackendNumberId, string mobileNumber)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var existFlag = await dbContext.OfferBackendNumbers.FirstOrDefaultAsync(x => x.Id == offerBackendNumberId && x.IsActive == true);

                    if (existFlag == null)
                    {
                        var res = await dbContext.OfferBackendNumbers.Where(x => x.BackendMobileNumber == mobileNumber && x.IsActive == true).CountAsync();
                        if (res > 0) return true;
                        return false;
                    }
                    else if (existFlag != null)
                    {
                        var res = await dbContext.OfferBackendNumbers.Where(x => x.Id != offerBackendNumberId && x.BackendMobileNumber == mobileNumber && x.IsActive == true).CountAsync();
                        if (res > 0) return true;
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("MobileNoAlreadyExist :: 500 :: " + ex.Message);
                return true;
            }
        }

        public async Task<Tuple<int, string>> UploadExcel(List<CompanyDetailsModel> objCompanyDetailsModel, string userId)
        {
            try
            {
                using (var dbContext = new OfferManagementEntities())
                {
                    var companyList = new List<CompanyDetail>(); string ErrorMessage = ""; CommonFunction objCommonFunction = new CommonFunction();
                    var backendNumberList = new List<OfferBackendNumber>();

                    int rowIndex = 0;

                    foreach (var item in objCompanyDetailsModel)
                    {
                        rowIndex++; bool okAccNumber = false; string mobileValidate = string.Empty; var comName = new object(); var backendMobile = new object();

                        if (string.IsNullOrEmpty(item.CompanyName))
                            ErrorMessage += "In Row " + rowIndex + " Company Name should not be blank.\n";
                        else
                        {
                            comName = await dbContext.CompanyDetails.Where(x => x.IsActive == true && x.CompanyName == item.CompanyName).FirstOrDefaultAsync();
                            if (comName != null)
                                ErrorMessage += "In Row " + rowIndex + " " + item.CompanyName + " already exists.\n";
                        }

                        if (string.IsNullOrEmpty(item.CompanyBName))
                            ErrorMessage += "In Row " + rowIndex + " Company Burmese Name should not be blank.\n";

                        if (string.IsNullOrEmpty(item.CompanyDescription))
                            ErrorMessage += "In Row " + rowIndex + " Company Description should not be blank.\n";

                        if (string.IsNullOrEmpty(item.BackendMobileNumber))
                            ErrorMessage += "In Row " + rowIndex + " Backend MobileNumber should not be blank.\n";
                        else
                        {
                            if (Regex.IsMatch(item.BackendMobileNumber.ToString(), "[^0-9]"))
                            {
                                ErrorMessage += "In Row " + rowIndex + " Backend MobileNumber allows number only.\n";
                            }
                            else
                            {
                                var IsValidMob = objCommonFunction.CheckOperators(item.BackendMobileNumber);
                                if (IsValidMob.Result == "Invalid Mobile")
                                {
                                    ErrorMessage += "In Row " + rowIndex + " Backend MobileNumber is invalid.\n";
                                }
                                else
                                {
                                    backendMobile = await dbContext.OfferBackendNumbers.Where(x => x.IsActive == true && x.BackendMobileNumber == item.BackendMobileNumber).FirstOrDefaultAsync();
                                    if (backendMobile != null)
                                        ErrorMessage += "In Row " + rowIndex + " " + item.BackendMobileNumber + " already exists.\n";
                                    else
                                    {
                                        mobileValidate = objCommonFunction.OKdollarRegisterNumber(item.BackendMobileNumber.ToString(), okAccNumber);

                                        if (mobileValidate != "0")
                                        {
                                            string error = string.Empty;
                                            if (mobileValidate == "28")
                                                error = " Inactive Customer";
                                            else if (mobileValidate == "9")
                                                error = " Backend MobileNumber is not register";
                                            else //if (TelenorNumber == "905")
                                                error = " Invalid Request";

                                            ErrorMessage += "In Row " + rowIndex + " " + error;
                                        }
                                    }
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(item.BackendMobileNumberPassword))
                            ErrorMessage += "In Row " + rowIndex + " Backend MobileNumber Password should not be blank.\n";

                        Guid AutoCompanyId = Guid.Empty;
                        AutoCompanyId = Guid.NewGuid();

                        companyList.Add(new CompanyDetail
                        {
                            Id = AutoCompanyId,
                            CompanyName = item.CompanyName,
                            CompanyBName = item.CompanyBName,
                            CompanyDescription = item.CompanyDescription,
                            CompanyImageUrl = item.CompanyImageUrl,
                            IsActive = true,
                            CreatedBy = userId,
                            CreatedDate = DateTime.Now
                        });

                        //var comDetails = companyList.Find(x => x.CompanyName == item.CompanyName);                                              

                        var duplicateCompany = companyList.GroupBy(x => x.CompanyName).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        if (comName == null)
                        {
                            if (duplicateCompany.Count > 0)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.CompanyName + " already exists.\n";
                                companyList.Clear();
                            }
                        }

                        backendNumberList.Add(new OfferBackendNumber
                        {
                            Id = Guid.NewGuid(),
                            CompanyId = AutoCompanyId,
                            AliesName = item.CompanyName,
                            BackendMobileNumber = item.BackendMobileNumber,
                            BackendMobileNumberPassword = item.BackendMobileNumberPassword,
                            IsActive = true,
                            CreatedBy = userId,
                            CreatedDate = DateTime.Now
                        });

                        var duplicateMobile = backendNumberList.GroupBy(x => x.BackendMobileNumber).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

                        if (backendMobile == null)
                        {
                            if (duplicateMobile.Count > 0)
                            {
                                ErrorMessage += "In Row " + rowIndex + " " + item.BackendMobileNumber + " already exists.\n";
                                companyList.Clear();
                            }
                        }
                    }

                    if (ErrorMessage == "")
                    {
                        dbContext.CompanyDetails.AddRange(companyList);
                        dbContext.OfferBackendNumbers.AddRange(backendNumberList);
                        await dbContext.SaveChangesAsync();
                        return new Tuple<int, string>(200, "Company Created Successfully");
                    }
                    else
                    {
                        return new Tuple<int, string>(300, ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("UploadExcel :: 500 :: " + ex.Message);
                return new Tuple<int, string>(500, "System Error Contact Admin");
            }
        }


    }
}
