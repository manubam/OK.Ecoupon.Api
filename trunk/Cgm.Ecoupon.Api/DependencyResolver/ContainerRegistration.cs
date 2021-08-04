using Cgm.Ecoupon.Application;
using Cgm.Ecoupon.Application.Impl;
using Cgm.Ecoupon.Infrastructure.Persistence;
using Cgm.Ecoupon.Infrastructure.Persistence.Repositories;
using Unity;

namespace Cgm.Ecoupon.Api.DependencyResolver
{
    public static class ContainerRegistration
    {
        public static UnityContainer GetContinerForRegister()
        {
            var container = new UnityContainer();

            container.RegisterType<ICompanyDetailsService, CompanyDetailsService>();
            container.RegisterType<ICompanyDetailsRepository, CompanyDetailsRepository>();

            container.RegisterType<IBranchService, BranchService>();
            container.RegisterType<IBranchRepository, BranchRepository>();

            container.RegisterType<IProductGroupDetailsService, ProductGroupDetailsService>();
            container.RegisterType<IProductGroupDetailsRepository, ProductGroupDetailsRepository>();

            container.RegisterType<IProductCategoryDetailsService, ProductCategoryDetailsService>();
            container.RegisterType<IProductCategoryDetailsRepository, ProductCategoryDetailsRepository>();

            container.RegisterType<IProductBrandDetailsService, ProductBrandDetailsService>();
            container.RegisterType<IProductBrandDetailsRepository, ProductBrandDetailsRepository>();

            container.RegisterType<IProductDetailsService, ProductDetailsService>();
            container.RegisterType<IProductDetailsRepository, ProductDetailsRepository>();

            container.RegisterType<ICompanyProductMappingService, CompanyProductMappingService>();
            container.RegisterType<ICompanyProductMappingRepository, CompanyProductMappingRepository>();

            return container;
        }
    }
}