using FluentValidation;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerApiTemplate.Application.Common;
using ServerApiTemplate.Application.Common.Behaviors;
using ServerApiTemplate.Application.Features.V1.Auth.Services;

namespace ServerApiTemplate.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        // Handler, validator, mapping được quét tự động — thêm feature mới KHÔNG cần đăng ký tay.
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);
        TypeAdapterConfig.GlobalSettings.Scan(assembly);

        services.Configure<AppOptions>(configuration.GetSection(AppOptions.SectionName));

        // Service dùng chung trong Application (đăng ký tay, Scoped).
        services.AddScoped<IAuthTokenIssuer, AuthTokenIssuer>();
        services.AddScoped<ICurrentUserDtoFactory, CurrentUserDtoFactory>();

        return services;
    }
}
