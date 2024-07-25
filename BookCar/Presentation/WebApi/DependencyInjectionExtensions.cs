using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Handlers.BrandHandlers;
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

            });

            return services;
        }
    }
}
