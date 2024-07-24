using Application.Features.CQRS.Handlers.AboutHandlers;
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
            });

            return services;
        }
    }
}
