﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cgm.Ecoupon.Infrastructure.Persistence.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OfferManagementEntities : DbContext
    {
        public OfferManagementEntities()
            : base("name=OfferManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ApprovalRequestDetail> ApprovalRequestDetails { get; set; }
        public virtual DbSet<BranchDetail> BranchDetails { get; set; }
        public virtual DbSet<BranchMobileNumberDetail> BranchMobileNumberDetails { get; set; }
        public virtual DbSet<ChildTransInfo> ChildTransInfoes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CompanyAndProductMappingDetail> CompanyAndProductMappingDetails { get; set; }
        public virtual DbSet<CompanyAndProductMappingSummarry> CompanyAndProductMappingSummarries { get; set; }
        public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<MasterTransInfo> MasterTransInfoes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<OfferApprovalSetup> OfferApprovalSetups { get; set; }
        public virtual DbSet<OfferAutoPayDiscountDetail> OfferAutoPayDiscountDetails { get; set; }
        public virtual DbSet<OfferBackendNumber> OfferBackendNumbers { get; set; }
        public virtual DbSet<OfferBlockBranchDetail> OfferBlockBranchDetails { get; set; }
        public virtual DbSet<OfferBlockCustomerDetail> OfferBlockCustomerDetails { get; set; }
        public virtual DbSet<OfferBlockDetail> OfferBlockDetails { get; set; }
        public virtual DbSet<OfferConditiionalMappingBranchDetail> OfferConditiionalMappingBranchDetails { get; set; }
        public virtual DbSet<OfferConditionalMappingCustomerDetail> OfferConditionalMappingCustomerDetails { get; set; }
        public virtual DbSet<OfferConditionalMappingDetail> OfferConditionalMappingDetails { get; set; }
        public virtual DbSet<OfferConditionalMappingLocationDetail> OfferConditionalMappingLocationDetails { get; set; }
        public virtual DbSet<OfferConfiguration> OfferConfigurations { get; set; }
        public virtual DbSet<OfferConfigurationMobileNumberDetail> OfferConfigurationMobileNumberDetails { get; set; }
        public virtual DbSet<OfferDetail> OfferDetails { get; set; }
        public virtual DbSet<OfferDetailsHistory> OfferDetailsHistories { get; set; }
        public virtual DbSet<OfferDisplayAppVersionDetail> OfferDisplayAppVersionDetails { get; set; }
        public virtual DbSet<OfferDisplayAppVersionDetailsHistory> OfferDisplayAppVersionDetailsHistories { get; set; }
        public virtual DbSet<OfferDisplayDetail> OfferDisplayDetails { get; set; }
        public virtual DbSet<OfferDisplayDetailsHistory> OfferDisplayDetailsHistories { get; set; }
        public virtual DbSet<OfferDisplayLocationDetail> OfferDisplayLocationDetails { get; set; }
        public virtual DbSet<OfferDisplayLocationDetailsHistory> OfferDisplayLocationDetailsHistories { get; set; }
        public virtual DbSet<OfferDisplayMappingDetail> OfferDisplayMappingDetails { get; set; }
        public virtual DbSet<OfferDisplayMappingDetailsHistory> OfferDisplayMappingDetailsHistories { get; set; }
        public virtual DbSet<OfferDisplayTelcoDetail> OfferDisplayTelcoDetails { get; set; }
        public virtual DbSet<OfferListingType> OfferListingTypes { get; set; }
        public virtual DbSet<OfferOsDetail> OfferOsDetails { get; set; }
        public virtual DbSet<OfferShemeConfiguration> OfferShemeConfigurations { get; set; }
        public virtual DbSet<OfferShemeConfigurationHistory> OfferShemeConfigurationHistories { get; set; }
        public virtual DbSet<OfferShemeType> OfferShemeTypes { get; set; }
        public virtual DbSet<OfferTermsAndCondition> OfferTermsAndConditions { get; set; }
        public virtual DbSet<OfferTermsAndConditionHistory> OfferTermsAndConditionHistories { get; set; }
        public virtual DbSet<OfferTransactionType> OfferTransactionTypes { get; set; }
        public virtual DbSet<OfferType> OfferTypes { get; set; }
        public virtual DbSet<ProductBrandDetail> ProductBrandDetails { get; set; }
        public virtual DbSet<ProductCategoryDetail> ProductCategoryDetails { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductGroupDetail> ProductGroupDetails { get; set; }
        public virtual DbSet<TelcoInfo> TelcoInfoes { get; set; }
        public virtual DbSet<TownShip> TownShips { get; set; }
        public virtual DbSet<UOMMaster> UOMMasters { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccessRight> UserAccessRights { get; set; }
        public virtual DbSet<UserOfferTypeDetail> UserOfferTypeDetails { get; set; }
        public virtual DbSet<UserProductGroupDetail> UserProductGroupDetails { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    
        public virtual ObjectResult<GetAllApprovalRequestDetail_Result> GetAllApprovalRequestDetail(Nullable<System.Guid> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllApprovalRequestDetail_Result>("GetAllApprovalRequestDetail", userIdParameter);
        }
    
        public virtual ObjectResult<GetAssignOfferDetails_Result> GetAssignOfferDetails(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAssignOfferDetails_Result>("GetAssignOfferDetails", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetAutoPayDiscountFliterData_Result> GetAutoPayDiscountFliterData(string tYPE, string tYPEVALUE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var tYPEVALUEParameter = tYPEVALUE != null ?
                new ObjectParameter("TYPEVALUE", tYPEVALUE) :
                new ObjectParameter("TYPEVALUE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAutoPayDiscountFliterData_Result>("GetAutoPayDiscountFliterData", tYPEParameter, tYPEVALUEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetAutoPayReport_Result> GetAutoPayReport(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAutoPayReport_Result>("GetAutoPayReport", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetDashboardOfferTypeWise_Result> GetDashboardOfferTypeWise(string tYPE, Nullable<System.DateTime> dATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var dATEParameter = dATE.HasValue ?
                new ObjectParameter("DATE", dATE) :
                new ObjectParameter("DATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDashboardOfferTypeWise_Result>("GetDashboardOfferTypeWise", tYPEParameter, dATEParameter);
        }
    
        public virtual ObjectResult<GetOfferAssignCount_Result> GetOfferAssignCount(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOfferAssignCount_Result>("GetOfferAssignCount", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetOfferCountAmountWise_Result> GetOfferCountAmountWise(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOfferCountAmountWise_Result>("GetOfferCountAmountWise", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetOfferCountDayWise_Result> GetOfferCountDayWise(string tYPE, Nullable<int> yEAR, Nullable<int> mONTH)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var yEARParameter = yEAR.HasValue ?
                new ObjectParameter("YEAR", yEAR) :
                new ObjectParameter("YEAR", typeof(int));
    
            var mONTHParameter = mONTH.HasValue ?
                new ObjectParameter("MONTH", mONTH) :
                new ObjectParameter("MONTH", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOfferCountDayWise_Result>("GetOfferCountDayWise", tYPEParameter, yEARParameter, mONTHParameter);
        }
    
        public virtual ObjectResult<GetOfferCountMonthWise_Result> GetOfferCountMonthWise(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOfferCountMonthWise_Result>("GetOfferCountMonthWise", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetOfferCountOfferTypeWise_Result> GetOfferCountOfferTypeWise(string tYPE, Nullable<System.DateTime> dATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var dATEParameter = dATE.HasValue ?
                new ObjectParameter("DATE", dATE) :
                new ObjectParameter("DATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOfferCountOfferTypeWise_Result>("GetOfferCountOfferTypeWise", tYPEParameter, dATEParameter);
        }
    
        public virtual ObjectResult<GetOfferCountTownshipWise_Result> GetOfferCountTownshipWise(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOfferCountTownshipWise_Result>("GetOfferCountTownshipWise", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetOfferRedeemLocationDetail_Result> GetOfferRedeemLocationDetail(string tYPE, Nullable<System.DateTime> fROMDATE, Nullable<System.DateTime> tODATE, Nullable<System.Guid> cOMPANYID, Nullable<System.Guid> bRANCHID, Nullable<System.Guid> pRODUCTGROUPID, Nullable<System.Guid> oFFERTYPEID, string oKACCOUNTTYPE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var fROMDATEParameter = fROMDATE.HasValue ?
                new ObjectParameter("FROMDATE", fROMDATE) :
                new ObjectParameter("FROMDATE", typeof(System.DateTime));
    
            var tODATEParameter = tODATE.HasValue ?
                new ObjectParameter("TODATE", tODATE) :
                new ObjectParameter("TODATE", typeof(System.DateTime));
    
            var cOMPANYIDParameter = cOMPANYID.HasValue ?
                new ObjectParameter("COMPANYID", cOMPANYID) :
                new ObjectParameter("COMPANYID", typeof(System.Guid));
    
            var bRANCHIDParameter = bRANCHID.HasValue ?
                new ObjectParameter("BRANCHID", bRANCHID) :
                new ObjectParameter("BRANCHID", typeof(System.Guid));
    
            var pRODUCTGROUPIDParameter = pRODUCTGROUPID.HasValue ?
                new ObjectParameter("PRODUCTGROUPID", pRODUCTGROUPID) :
                new ObjectParameter("PRODUCTGROUPID", typeof(System.Guid));
    
            var oFFERTYPEIDParameter = oFFERTYPEID.HasValue ?
                new ObjectParameter("OFFERTYPEID", oFFERTYPEID) :
                new ObjectParameter("OFFERTYPEID", typeof(System.Guid));
    
            var oKACCOUNTTYPEParameter = oKACCOUNTTYPE != null ?
                new ObjectParameter("OKACCOUNTTYPE", oKACCOUNTTYPE) :
                new ObjectParameter("OKACCOUNTTYPE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOfferRedeemLocationDetail_Result>("GetOfferRedeemLocationDetail", tYPEParameter, fROMDATEParameter, tODATEParameter, cOMPANYIDParameter, bRANCHIDParameter, pRODUCTGROUPIDParameter, oFFERTYPEIDParameter, oKACCOUNTTYPEParameter);
        }
    
        public virtual ObjectResult<GetOfferReportDetail_Result> GetOfferReportDetail(string tYPE, Nullable<System.DateTime> fROMDATE, Nullable<System.DateTime> tODATE, Nullable<System.Guid> cOMPANYID, Nullable<System.Guid> bRANCHID, Nullable<System.Guid> pRODUCTGROUPID, Nullable<System.Guid> oFFERTYPEID, string oKACCOUNTTYPE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var fROMDATEParameter = fROMDATE.HasValue ?
                new ObjectParameter("FROMDATE", fROMDATE) :
                new ObjectParameter("FROMDATE", typeof(System.DateTime));
    
            var tODATEParameter = tODATE.HasValue ?
                new ObjectParameter("TODATE", tODATE) :
                new ObjectParameter("TODATE", typeof(System.DateTime));
    
            var cOMPANYIDParameter = cOMPANYID.HasValue ?
                new ObjectParameter("COMPANYID", cOMPANYID) :
                new ObjectParameter("COMPANYID", typeof(System.Guid));
    
            var bRANCHIDParameter = bRANCHID.HasValue ?
                new ObjectParameter("BRANCHID", bRANCHID) :
                new ObjectParameter("BRANCHID", typeof(System.Guid));
    
            var pRODUCTGROUPIDParameter = pRODUCTGROUPID.HasValue ?
                new ObjectParameter("PRODUCTGROUPID", pRODUCTGROUPID) :
                new ObjectParameter("PRODUCTGROUPID", typeof(System.Guid));
    
            var oFFERTYPEIDParameter = oFFERTYPEID.HasValue ?
                new ObjectParameter("OFFERTYPEID", oFFERTYPEID) :
                new ObjectParameter("OFFERTYPEID", typeof(System.Guid));
    
            var oKACCOUNTTYPEParameter = oKACCOUNTTYPE != null ?
                new ObjectParameter("OKACCOUNTTYPE", oKACCOUNTTYPE) :
                new ObjectParameter("OKACCOUNTTYPE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOfferReportDetail_Result>("GetOfferReportDetail", tYPEParameter, fROMDATEParameter, tODATEParameter, cOMPANYIDParameter, bRANCHIDParameter, pRODUCTGROUPIDParameter, oFFERTYPEIDParameter, oKACCOUNTTYPEParameter);
        }
    
        public virtual ObjectResult<GetOkDebitCreditCashback_Result> GetOkDebitCreditCashback(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOkDebitCreditCashback_Result>("GetOkDebitCreditCashback", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetOkDebitWalletNumber_Result> GetOkDebitWalletNumber(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOkDebitWalletNumber_Result>("GetOkDebitWalletNumber", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetOkDebitWalletNumberDetail_Result> GetOkDebitWalletNumberDetail(string tYPE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOkDebitWalletNumberDetail_Result>("GetOkDebitWalletNumberDetail", tYPEParameter);
        }
    
        public virtual ObjectResult<GetOkDebitWalletNumberSubDetail_Result> GetOkDebitWalletNumberSubDetail(string tYPE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOkDebitWalletNumberSubDetail_Result>("GetOkDebitWalletNumberSubDetail", tYPEParameter);
        }
    
        public virtual int GetOKDollarAccountNumberDetails(string tYPE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetOKDollarAccountNumberDetails", tYPEParameter, sTARTDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<GetOverAmountNoDiscount_Result> GetOverAmountNoDiscount(string tYPE, Nullable<System.DateTime> fROMDATE, Nullable<System.DateTime> tODATE, Nullable<System.Guid> cOMPANYID, Nullable<System.Guid> bRANCHID, Nullable<System.Guid> pRODUCTGROUPID, Nullable<System.Guid> oFFERTYPEID, string oKACCOUNTTYPE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            var fROMDATEParameter = fROMDATE.HasValue ?
                new ObjectParameter("FROMDATE", fROMDATE) :
                new ObjectParameter("FROMDATE", typeof(System.DateTime));
    
            var tODATEParameter = tODATE.HasValue ?
                new ObjectParameter("TODATE", tODATE) :
                new ObjectParameter("TODATE", typeof(System.DateTime));
    
            var cOMPANYIDParameter = cOMPANYID.HasValue ?
                new ObjectParameter("COMPANYID", cOMPANYID) :
                new ObjectParameter("COMPANYID", typeof(System.Guid));
    
            var bRANCHIDParameter = bRANCHID.HasValue ?
                new ObjectParameter("BRANCHID", bRANCHID) :
                new ObjectParameter("BRANCHID", typeof(System.Guid));
    
            var pRODUCTGROUPIDParameter = pRODUCTGROUPID.HasValue ?
                new ObjectParameter("PRODUCTGROUPID", pRODUCTGROUPID) :
                new ObjectParameter("PRODUCTGROUPID", typeof(System.Guid));
    
            var oFFERTYPEIDParameter = oFFERTYPEID.HasValue ?
                new ObjectParameter("OFFERTYPEID", oFFERTYPEID) :
                new ObjectParameter("OFFERTYPEID", typeof(System.Guid));
    
            var oKACCOUNTTYPEParameter = oKACCOUNTTYPE != null ?
                new ObjectParameter("OKACCOUNTTYPE", oKACCOUNTTYPE) :
                new ObjectParameter("OKACCOUNTTYPE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOverAmountNoDiscount_Result>("GetOverAmountNoDiscount", tYPEParameter, fROMDATEParameter, tODATEParameter, cOMPANYIDParameter, bRANCHIDParameter, pRODUCTGROUPIDParameter, oFFERTYPEIDParameter, oKACCOUNTTYPEParameter);
        }
    
        public virtual ObjectResult<GetTodayTotalAutoPayDiscountCount_Result> GetTodayTotalAutoPayDiscountCount(string tYPE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTodayTotalAutoPayDiscountCount_Result>("GetTodayTotalAutoPayDiscountCount", tYPEParameter);
        }
    
        public virtual ObjectResult<GetTodayTotalOkDollarOfferRedeemCount_Result> GetTodayTotalOkDollarOfferRedeemCount(string tYPE)
        {
            var tYPEParameter = tYPE != null ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTodayTotalOkDollarOfferRedeemCount_Result>("GetTodayTotalOkDollarOfferRedeemCount", tYPEParameter);
        }
    }
}
