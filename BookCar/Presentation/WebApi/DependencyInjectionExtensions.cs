using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.AppUserHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Handlers.CarFeatureHandlers;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Handlers.CategoryHandlers;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Features.CQRS.Handlers.FeatureHandlers;
using Application.Features.CQRS.Handlers.FooterAddressHandlers;
using Application.Features.CQRS.Handlers.GetCarPricingHandlers;
using Application.Features.CQRS.Handlers.LocationHandlers;
using Application.Features.CQRS.Handlers.PricingHandlers;
using Application.Features.CQRS.Handlers.RentACarHandlers;
using Application.Features.CQRS.Handlers.ServiceHandlers;
using Application.Features.CQRS.Handlers.SocialMediaHandlers;
using Application.Features.CQRS.Handlers.StatisticsHandlers;
using Application.Features.CQRS.Handlers.TestimonialHandlers;
using Application.Interfaces;
using Application.Interfaces.AppUserInterfaces;
using Application.Interfaces.CarInterfaces;
using Application.Interfaces.RentACarInterfaces;
using Application.Interfaces.StatisticsInterfaces;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.AppUserRepositories;
using Persistence.Repositories.CarRepositories;
using Persistence.Repositories.RentACarRepositories;
using Persistence.Repositories.StatisticsRepositories;
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
            services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
            services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
            services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
            services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
            services.AddScoped(typeof(IAppUserRepository), typeof(AppUserRepository));
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
                cfg.RegisterServicesFromAssembly(typeof(GetLast5CarsWithBrandQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarPricingQueryHandler).Assembly);

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
                cfg.RegisterServicesFromAssembly(typeof(GetFooterAddressQueryHandler).Assembly);
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

                cfg.RegisterServicesFromAssembly(typeof(CreateServiceCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateServiceCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveServiceCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetServiceQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetServiceByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateSocialMediaCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateSocialMediaCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveSocialMediaCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetSocialMediaQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetSocialMediaByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateTestimonialCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateTestimonialCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveTestimonialCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetTestimonialQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetTestimonialByIdQueryHandler).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(GetCarCountQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetBrandNameByMaxCarQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAvgRentPriceForDailyQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAvgRentPriceForMonthlyQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAvgRentPriceForWeeklyQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetBrandCountQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarBrandAndModelByRentPriceDailyMaxQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarBrandAndModelByRentPriceDailyMinQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarCountByFuelDieselQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarCountByFuelElectricQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarCountByFuelGasolineQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarCountByKmSmallerThan1000QueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarCountByTransmissionIsAutoQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetLocationCountQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetRentACarQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCarFeatureByCarIdQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateCarFeatureAvailableChangeToTrueCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateCarFeatureAvailableChangeToFalseCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateCarFeatureByCarCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateAppUserCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCheckAppUserQueryHandler).Assembly);
            });

            return services;
        }
    }
}
