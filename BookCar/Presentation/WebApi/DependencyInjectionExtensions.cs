using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Handlers.CategoryHandlers;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Features.CQRS.Handlers.FeatureHandlers;
using Application.Features.CQRS.Handlers.FooterAddressHandlers;
using Application.Features.CQRS.Handlers.LocationHandlers;
using Application.Features.CQRS.Handlers.PricingHandlers;
using Application.Interfaces;
using Persistence.Context;
using Persistence.Repositories;
using System.Reflection;

namespace WebApi
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<CarBookContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateAboutCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateAboutCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveAboutCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAboutByIdQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAboutQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateBannerCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateBannerCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveBannerCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetBannerQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetBannerByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateBrandCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateBrandCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveBrandCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetBrandQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetBrandByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateCarCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateCarCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveCarCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarByIdQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarWithBrandQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateCategoryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveCategoryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCategoryQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCategoryByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateContactCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateContactCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveContactCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetContactQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetContactByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateFeatureCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateFeatureCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveFeatureCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetFeatureQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetFeatureByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateFooterAddressCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateFooterAddressCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveFooterAddressCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetLocationQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetFooterAddressByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateLocationCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateLocationCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveLocationCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetLocationQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetLocationByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreatePricingCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdatePricingCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemovePricingCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetPricingQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetPricingByIdQueryHandler).Assembly);

            });

            return services;
        }
    }
}
